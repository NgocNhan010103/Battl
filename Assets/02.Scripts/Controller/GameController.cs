using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Start()
    {
        InitGameDatas();
    }

    public void InitGameDatas()
    {
        if (!PlayerPrefs.HasKey(GameData.PP_USER_DATA))
        {
            UserData.data = new UserDeepData();
        }
        else
        {
            var stringJson = PlayerPrefs.GetString(GameData.PP_USER_DATA);
            Debug.Log(" UserData json : " + stringJson);
            UserData.data = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDeepData>(stringJson);
        }
    }
}
