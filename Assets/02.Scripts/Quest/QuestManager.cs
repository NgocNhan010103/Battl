using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public enum QuestState
{
    Complete,
    Go,
    Claimed
}

public enum QuestType
{
    Daily,
    Weekly
}

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("BTN")]
    public Button openDailyPanel;
    public Button openWeeklyPanel;

    public GameObject DailyQuest;
    public GameObject WeeklyQuest;

    [SerializeField]public Transform contentDaily;
    [SerializeField]public Transform contentWeekly;
    [SerializeField] GameObject prf;

    [Header("List Task")]
    [SerializeField]public List<QuestData> dailyQ;
    [SerializeField]public List<QuestData> weeklyQ;

    private float itemHeight;
    public float itemSpacing = 0.5f;

    private void Awake()
    {
        Instance = this;


        if (RealTime.instance.IsNewDay())
        {
            UserData.data.QuestesDaily = CSVReader.instance.listDaillyQ;
            PointActive.Instance.ResetDaily();
            UserData.SaveData();
        }
        if (RealTime.instance.IsNewWeek())
        {
            UserData.data.QuestesWeekly = CSVReader.instance.listWeeklyQ;
            UserData.SaveData();
        }

        dailyQ = UserData.data.QuestesDaily;
        weeklyQ = UserData.data.QuestesWeekly;
    }


    private void OnEnable()
    {
        DailyQuest.SetActive(true);
        LoadQuest(dailyQ, contentDaily);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Delete(Transform transform)
    {
        transform.DetachChildren();
    }

    public void AAA()
    {
        SetQualityQuest(dailyQ[0]);
    }

    
    public void SetQualityQuest(QuestData quest)
    {
        if (quest.CurQuality < quest.Quality)
        {
            quest.CurQuality += 1;
            if (dailyQ.Contains(quest))
            {
                LoadQuest(dailyQ, contentDaily);
            }
            else
            {
                LoadQuest(weeklyQ, contentWeekly);
            }
        }
        if (quest.CurQuality >= quest.Quality)
        {
            quest.QState = QuestState.Complete;
            
        }
    }

    public void Claim(QuestType qType)
    {
        if (qType == QuestType.Daily)
        {
            LoadQuest(dailyQ, contentDaily);
        }
        else
        {
            LoadQuest(weeklyQ, contentWeekly);
        }
    }

    public void LoadQuest(List<QuestData> taskList, Transform content)
    {
        Debug.Log($"Child for content : {content.transform.childCount}");
        if (content.transform.childCount < 2)
        {
            itemHeight = content.GetChild(0).GetComponent<RectTransform>().sizeDelta.y + 10;
            Destroy(content.GetChild(0).gameObject);
            content.DetachChildren();
            for (int i = 0; i < taskList.Count; i++)
            {
                QuestData quest = taskList[i];

                UIQuest uiQuest = Instantiate(prf, content).GetComponent<UIQuest>();

                uiQuest.SetItemPosition(Vector2.down * i * (itemHeight + itemSpacing));
                uiQuest.gameObject.name = "Quest " + i;
                uiQuest.SetData(quest);
                uiQuest.SetDescription(quest.Description);
                uiQuest.SetCoinsReward(quest.CoinsForClaim);
                uiQuest.SetQuality(quest.CurQuality, quest.Quality);
                uiQuest.SetActive(quest.PointActive);
                

                float containerHeight = taskList.Count * (itemHeight + itemSpacing) + itemSpacing * 5;
                content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, containerHeight);
            }
        }
        else
        {
            for (int i =0; i < content.childCount; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
            for (int i = 0; i < taskList.Count; i++)
            {
                QuestData quest = taskList[i];

                if (quest.QState != QuestState.Claimed)
                {
                    UIQuest uiQuest = Instantiate(prf, content).GetComponent<UIQuest>();

                    uiQuest.SetItemPosition(Vector2.down * i * (itemHeight + itemSpacing));
                    uiQuest.gameObject.name = "Quest " + i;
                    uiQuest.SetData(quest);
                    uiQuest.SetDescription(quest.Description);
                    uiQuest.SetCoinsReward(quest.CoinsForClaim);
                    uiQuest.SetQuality(quest.CurQuality, quest.Quality);
                    uiQuest.SetActive(quest.PointActive);
                }
            }
            for (int i = 0; i < taskList.Count; i++)
            {
                QuestData quest = taskList[i];

                if (quest.QState == QuestState.Claimed)
                {
                    UIQuest uiQuest = Instantiate(prf, content).GetComponent<UIQuest>();

                    uiQuest.SetItemPosition(Vector2.down * i * (itemHeight + itemSpacing));
                    uiQuest.gameObject.name = "Quest " + i;
                    uiQuest.SetData(quest);
                    uiQuest.SetDescription(quest.Description);
                    uiQuest.SetCoinsReward(quest.CoinsForClaim);
                    uiQuest.SetQuality(quest.CurQuality, quest.Quality);
                    uiQuest.SetActive(quest.PointActive);
                }
                float containerHeight = taskList.Count * (itemHeight + itemSpacing) + itemSpacing * 5;
                content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, containerHeight);
            }

            for (int i = 0; i < content.childCount; i++)
            {
                UIQuest uiQ = content.GetChild(i).GetComponent<UIQuest>();

                uiQ.SetQuality(taskList[uiQ.data.ID].CurQuality, taskList[uiQ.data.ID].Quality);

            }

        }

    }
}
