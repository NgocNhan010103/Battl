using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EntityTag
{
    Allie,
    Enemy
}

public enum State
{
    Idle,
    Run,
    Jump,
    Attack,
    Hit,
    Dead
}

public class Entity : MonoBehaviour
{
    public EntityTag entityTag;
    public State currentState = State.Idle;

    [Header("Health")]
    public ProgressBar progressBar;
    [Space(10)]
    public int maxHealth;
    public int currentHealth;
    public int defense;

    [Space(20)]
    public bool isDead = false;


    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= (damage * (1 - defense/100));

        if  (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            //call even Ondead;
        }
    }

    public bool IsDead() => isDead;
}
