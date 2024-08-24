using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCameraLook : MonoBehaviour
{
    private float XMove;
    private float YMove;
    private float XRotation;
    [SerializeField] private Transform player;

    public Vector2 lookAxit;
    public float sensivity = 40f;

    private void Update()
    {
        XMove = lookAxit.x * sensivity * Time.deltaTime;
        YMove = lookAxit.y * sensivity * Time.deltaTime;
        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -40f, 40f);

        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        player.Rotate(Vector3.up * XMove);
    }
 
}
