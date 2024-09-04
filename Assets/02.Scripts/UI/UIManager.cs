using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    #region Quest

    public Button openDailyQBtn;
    public Button openWeeklyQBtn;

    public GameObject dailyQPanel;
    public GameObject weeklyQPanel;



    public void OpenDailyQuest()
    {
        openDailyQBtn.GetComponent<Outline>().enabled = true;
        openWeeklyQBtn.GetComponent<Outline>().enabled = false;
        dailyQPanel.SetActive(true);
        weeklyQPanel.SetActive(false);
        QuestManager.Instance.LoadQuest(QuestManager.Instance.dailyQ, QuestManager.Instance.contentDaily);
        PointActive.Instance.CheckPointActive(QuestType.Daily);
    }

    public void OpenWeeklyQuest()
    {
        openDailyQBtn.GetComponent<Outline>().enabled = false;
        openWeeklyQBtn.GetComponent<Outline>().enabled = true;
        dailyQPanel.SetActive(false);
        weeklyQPanel.SetActive(true);
        QuestManager.Instance.LoadQuest(QuestManager.Instance.weeklyQ, QuestManager.Instance.contentWeekly);
        PointActive.Instance.CheckPointActive(QuestType.Weekly);
    }
    #endregion

}
