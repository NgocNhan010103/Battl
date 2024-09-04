using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointActive : MonoBehaviour
{
    public static PointActive Instance;

    private void Awake()
    {
        Instance = this;

        SetDailyFill((float)UserData.data.PointDActive/100);
        SetWeeklyFill((float)UserData.data.PointWActive/100);

    }

    public List<Button> listImgDChest;
    public List<Button> listImgWChest;
    [Space(20)]
    public Image pointDActiveFill;
    public Image pointWActiveFill;
    public Sprite chestSprite;

    
    public void ResetDaily()
    {
        UserData.data.PointDActive = 0;
        UserData.SaveData();
        CheckPointActive(QuestType.Daily);
    }

    public void ResetWeekly()
    {
        UserData.data.PointWActive = 0;
        UserData.SaveData();
        CheckPointActive(QuestType.Weekly);
    }

    public void CheckPointActive(QuestType qType)
    {
        if (qType == QuestType.Daily)
        {
            switch (UserData.data.PointDActive)
            {
                case 10:
                    listImgDChest[0].interactable = true;
                    listImgDChest[0].GetComponent<Image>().sprite = chestSprite; break;
                case 40:
                    listImgDChest[1].interactable = true;
                    listImgDChest[1].GetComponent<Image>().sprite = chestSprite; break;
                case 70:
                    listImgDChest[2].interactable = true;
                    listImgDChest[2].GetComponent<Image>().sprite = chestSprite; break;
                case 100:
                    listImgDChest[3].interactable = true;
                    listImgDChest[3].GetComponent<Image>().sprite = chestSprite; break;
            }

            SetDailyFill((float)UserData.data.PointDActive / 100);
        }
        else
        {
            switch (UserData.data.PointWActive)
            {
                case 10:
                    listImgWChest[0].interactable = true;
                    listImgWChest[0].GetComponent<Image>().sprite = chestSprite; break;
                case 40:
                    listImgWChest[1].interactable = true;
                    listImgWChest[1].GetComponent<Image>().sprite = chestSprite; break;
                case 70:
                    listImgWChest[2].interactable = true;
                    listImgWChest[2].GetComponent<Image>().sprite = chestSprite; break;
                case 100:
                    listImgWChest[3].interactable = true;
                    listImgWChest[3].GetComponent<Image>().sprite = chestSprite; break;
            }

            SetWeeklyFill((float)UserData.data.PointWActive / 100);
        }
    }

    public void SetDailyFill(float amount)
    {
        pointDActiveFill.fillAmount = amount;
    }

    public void SetWeeklyFill(float amount)
    {
        pointWActiveFill.fillAmount = amount;
    }
}
