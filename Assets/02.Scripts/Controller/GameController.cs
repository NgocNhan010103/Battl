using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Start()
    {
        InitGameDatas();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Delete Data");
        }
    }

    public void InitGameDatas()
    {
        if (!PlayerPrefs.HasKey(GameData.PP_USER_DATA))
        {
            UserData.data = new UserDeepData();
            UserData.data.lastCheckedDate = DateTime.Now.AddDays(01/01/2024);
            UserData.data.QuestesDaily = CSVReader.instance.listDaillyQ;
            UserData.data.QuestesWeekly = CSVReader.instance.listWeeklyQ;
        }
        else
        {
            var stringJson = PlayerPrefs.GetString(GameData.PP_USER_DATA);
            Debug.Log(" UserData json : " + stringJson);
            UserData.data = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDeepData>(stringJson);
        }
    }
}
