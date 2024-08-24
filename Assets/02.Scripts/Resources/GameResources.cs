using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    public static GameResources instance;

    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> charactersPrefab;

    public List<GameObject> monstersPrefab;


}
