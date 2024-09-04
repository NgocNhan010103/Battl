using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    [SerializeField] Vector3 inScreenPos;
    [SerializeField] Vector3 outScreenPos;
    [SerializeField] Vector3 btnInScreenPos;
    [SerializeField] Vector3 btnOutScreenPos;
    [Space(20)]
    [SerializeField] float tweenDuration;
    [SerializeField] public string menuName;
    [Space(10)]
    [SerializeField] GameObject darkPanel;
    [SerializeField] GameObject btnClose;
    public bool open;

    public void Open()
    {
        open = true;
        if (darkPanel != null && btnClose != null)
        {
            darkPanel.SetActive(true);
            btnClose.GetComponent<RectTransform>().DOAnchorPos3D(btnInScreenPos, tweenDuration).SetUpdate(true);
            
        }
        GetComponent<RectTransform>().DOAnchorPos3D(inScreenPos, tweenDuration).SetUpdate(true);
    }

    public void Close()
    {
        open = false;
        if (darkPanel != null && btnClose != null)
        {
            darkPanel.SetActive(false);
            btnClose.GetComponent<RectTransform>().DOAnchorPos3D(btnOutScreenPos, tweenDuration).SetUpdate(true);
        }
        GetComponent<RectTransform>().DOAnchorPos3D(outScreenPos, tweenDuration).SetUpdate(true);
    }
}
