using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene instance;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
