using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    private Vector2 initialPosition; // Store the initial position of the joystick
    public bool isDraging;
    protected override void Start()
    {
        base.Start();
        initialPosition = background.anchoredPosition; // Save the initial position
        // background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        isDraging = true;
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        isDraging = false;
        //background.gameObject.SetActive(false);
        background.anchoredPosition = initialPosition; // Reset the joystick position
        base.OnPointerUp(eventData);
    }
}
