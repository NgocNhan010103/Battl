using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField _FixedTouchField;
    public ThirstCameraLook thirstCameraLook;
    public FirstCameraLook firstCameraLook;

    void Update()
    {
        if (thirstCameraLook.isActiveAndEnabled)
        {
            thirstCameraLook.lookAxit = _FixedTouchField.TouchDist;
        }
        else
        {
            firstCameraLook.lookAxit = _FixedTouchField.TouchDist;
        }
    }

    public void ChangeCameraPerson()
    {
        if (thirstCameraLook.isActiveAndEnabled)
        {
            thirstCameraLook.gameObject.SetActive(false);
            firstCameraLook.gameObject.SetActive(true);
        }
        else
        {
            thirstCameraLook.gameObject.SetActive(true);
            firstCameraLook.gameObject.SetActive(false);
        }
    }
}
