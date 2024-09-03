using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public static CSVReader instance;

    [SerializeField] TextAsset dailyQTXT;
    [SerializeField] TextAsset weeklyQTXT;

    public List<QuestData> listDaillyQ;
    public List<QuestData> listWeeklyQ;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        ReadDailyQuestData();
        ReadWeeklkyQuestData();
    }

    public void ReadDailyQuestData()
    {
        listDaillyQ = new List<QuestData>();

        string[] data = dailyQTXT.text.Split(new string[] { "\t", "\n" }, System.StringSplitOptions.None);
        List<string> tempList = new List<string>();

        for (int i = 0; i < data.Length; i++)
        {
            tempList.Add(data[i]);
        }
        int tableSize = tempList.Count / 7 - 1;

        for (int i = 0; i < tableSize; i++)
        {
            var temp = new QuestData()
            {
                ID = int.Parse(tempList[7 * (i + 1)]),
                Name = tempList[7 * (i + 1) + 1],
                Description = tempList[7 * (i + 1) + 2],
                CoinsForClaim = int.Parse(tempList[7 * (i + 1) + 3]),
                Quality = int.Parse(tempList[7 * (i + 1) + 4]),
                QType = (QuestType)Enum.Parse(typeof(QuestType), tempList[7 * (i + 1) + 5]),
                PointActive = int.Parse(tempList[7 * (i + 1) + 6]),
                QState = (QuestState)Enum.Parse(typeof(QuestState), "Go"),
            };
            listDaillyQ.Add(temp);
        }
    }

    public void ReadWeeklkyQuestData()
    {
        listWeeklyQ = new List<QuestData>();

        string[] data = weeklyQTXT.text.Split(new string[] { "\t", "\n" }, System.StringSplitOptions.None);
        List<string> tempList = new List<string>();

        for (int i = 0; i < data.Length; i++)
        {
            tempList.Add(data[i]);
        }
        int tableSize = tempList.Count / 7 - 1;

        for (int i = 0; i < tableSize; i++)
        {
            var temp = new QuestData()
            {
                ID = int.Parse(tempList[7 * (i + 1)]),
                Name = tempList[7 * (i + 1) + 1],
                Description = tempList[7 * (i + 1) + 2],
                CoinsForClaim = int.Parse(tempList[7 * (i + 1) + 3]),
                Quality = int.Parse(tempList[7 * (i + 1) + 4]),
                QType = (QuestType)Enum.Parse(typeof(QuestType), tempList[7 * (i + 1) + 5]),
                PointActive = int.Parse(tempList[7 * (i + 1) + 6]),
                QState = (QuestState)Enum.Parse(typeof(QuestState), "Go"),
            };
            listWeeklyQ.Add(temp);
        }
    }
}
