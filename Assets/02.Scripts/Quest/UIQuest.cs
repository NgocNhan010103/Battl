using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIQuest : MonoBehaviour
{
    public QuestData data;

    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI coinsReward;
    [SerializeField] Button reward;
    [SerializeField] TextMeshProUGUI qualityText;
    [SerializeField] TextMeshProUGUI activeText;


    public Action Complete;


    private void OnEnable()
    {
        reward.interactable = false;
        Complete += OnEventComplete;
    }

    private void OnDisable()
    {
        Complete -= OnEventComplete;
    }

    public void OnEventComplete()
    {
        data.QState = QuestState.Complete;
        reward.interactable = true;
    }

    public void SetData(QuestData _data)
    {
        this.data = _data;
    }

    public void SetItemPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetDescription(string description)
    {
        descriptionText.text = description;
    }

    public void SetCoinsReward(int coins)
    {
        coinsReward.text = coins.ToString();
    }

    public void SetQuality(int curQuality ,int quality)
    {
            qualityText.text = string.Format("{0}/{1}", curQuality, quality);
        if (curQuality == quality && !data.IsClaimed)
            Complete?.Invoke();
    }

    public void SetActive(int active)
    {
        activeText.text = active.ToString();
    }

    public void Claim()
    {
        reward.interactable = false;
        data.IsClaimed = true;
        data.QState = QuestState.Claimed; 
        QuestManager.Instance.Claim( data.QType);
    }
}
