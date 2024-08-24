using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class MonstersController : MonoBehaviour
{
    public MonsterData monsterData;

    NavMeshAgent agent;
    Animator anim;
    Entity entity;

    public List<Entity> allEntities;
    public Entity nearestEntity;
    float distance;
    float nearestDistance = 1000;
    float radius = 1000;
    [SerializeField] private float flowAttack = 3;

    [SerializeField]private bool isDestination = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        entity = GetComponent<Entity>();
    }

    private void Update()
    {

        FindAllEntity();
        FindNearestEntity();
        if (!IsNearestEntity())
        {
            ChangeMonsterState(State.Run);
            agent.SetDestination(nearestEntity.transform.position);
            Debug.Log($"continue moving");
        }
        if (flowAttack > 0)
            flowAttack -= Time.deltaTime;

        if (!entity.IsDead())
        {
            if (agent.isActiveAndEnabled)
            {
                if (nearestEntity != null && !isDestination)
                {
                    agent.destination = nearestEntity.transform.position;
                    isDestination = true;
                }
                if (agent.remainingDistance > 3f)
                {
                    ChangeMonsterState(State.Run);
                    isDestination = false;
                }
                else
                {
                    if (nearestEntity != null)
                    {
                        if (!nearestEntity.IsDead())
                        {

                            ChangeMonsterState(State.Attack);
                            if (flowAttack <= 0)
                            {
                                //flowAttack = monsterData.AttackSpeed;
                                flowAttack = 3;
                                //Damge to target code

                                nearestEntity.TakeDamage(monsterData.Damage);
                                nearestEntity.progressBar.SetCurrentHealth(nearestEntity.currentHealth);
                                return;
                            }
                        }
                        else
                        {
                            isDestination = false;
                        }

                    }
                }
            }
        }
        else
        {
            ChangeMonsterState(State.Dead);
            return;
        }

    }

    bool IsNearestEntity()
    {
        float distance = Vector3.Distance(transform.position, nearestEntity.transform.position);
        return (distance <= 3f);
    }

    void FindAllEntity()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var collider in colliders)
        {
            Entity entity = collider.GetComponent<Entity>();
            if (entity != null && entity.entityTag == EntityTag.Allie && !allEntities.Contains(entity))
            {
                allEntities.Add(entity);
            }
        }
    }

    void FindNearestEntity()
    {
        foreach (var entity in allEntities)
        {
            if (!entity.IsDead())
            {
                distance = Vector3.Distance(this.transform.position, entity.transform.position);

                if (distance < nearestDistance)
                {
                    nearestEntity = entity;
                    nearestDistance = distance;
                }
            }
            else
            {
                allEntities.Remove(entity);
                nearestDistance = 1000;
            }
        }

    }

    public void ChangeMonsterState(State state)
    {
        entity.currentState = state;

        switch (entity.currentState)
        {
            case State.Idle:
                anim.Play("Idle");
                break;
            case State.Run:
                anim.Play("Run");
                agent.isStopped = false;
                break;
            case State.Attack:
                agent.isStopped = true;
                if (flowAttack <= 0)
                {
                    string nameAnim;
                    int index = Random.Range(1, 3);
                    if (index == 1) nameAnim = "Attack01";
                    else nameAnim = "Attack02";
                    Debug.LogError($"call anim : {nameAnim}");
                    anim.Play(nameAnim);
                }
                break;
            case State.Dead:
                anim.Play("Dead");
                Destroy(gameObject, 2f);
                break;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
