using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    [SerializeField] Transform spawnPos;

    private void Start()
    {
        Instantiate(GameResources.instance.monstersPrefab[1],spawnPos).transform.localScale = GameResources.instance.monstersPrefab[1].transform.localScale;
    }
}
