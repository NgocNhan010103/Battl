using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public PlayerData playerData;
    [Space(10)]
    public Entity cunrrentEntity;
    [Space(20)]
    public static PlayerController Instance;
    private Entity entity;
    [Space(20)]
    public Image warmingHP;


    private void Awake()
    {
        Instance = this;
    }

    public GameObject currentPrefab;
    public Animator anim;



    private void Start()
    {
        entity = GetComponent<Entity>();

        if (currentPrefab != null)
        {
            LoadPlayerPrefab(currentPrefab);
        }
        entity.progressBar.SetProgressBar(1);
        entity.progressBar.SetMaxHelath(entity.maxHealth);
        entity.progressBar.SetCurrentHealth(entity.currentHealth);
        LoadAnimator();
    }

    private void Update()
    {
        float healthRatio = entity.currentHealth / entity.maxHealth;

        if (healthRatio <= 0.3f)
        {
            warmingHP.color = new Color(warmingHP.color.r, warmingHP.color.g, warmingHP.color.b, 2.33f - healthRatio * 2.33f);
        }
        else
        {
            warmingHP.color = new Color(warmingHP.color.r, warmingHP.color.g, warmingHP.color.b, 0f);
        }
    }


    void LoadAnimator()
    {
        anim = transform.GetChild(3).GetComponent<Animator>();
    }

    void LoadPlayerPrefab(GameObject prefab)
    {
        Instantiate(prefab, transform).transform.localPosition = Vector3.zero;
    }


    public void ChangeCharacterState(State state)
    {
        entity.currentState = state;

        //Change animation to character state
        switch (state)
        {
            case State.Idle:
                ChangeCharacterAnims("Idle");
                break;
            case State.Jump:
                ChangeCharacterAnims("Jump");
                break;
            case State.Run:
                ChangeCharacterAnims("Run");
                break;
            case State.Attack:
                ChangeCharacterAnims("Attack");
                break;
            case State.Hit:
                ChangeCharacterAnims("Hit");
                break;
            case State.Dead:
                ChangeCharacterAnims("Dead");
                break;
        }
    }

    public void ChangeCharacterAnims(string animName)
    {
        anim.Play(animName);
    }
}


