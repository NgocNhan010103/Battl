using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThirstCameraLook : MonoBehaviour
{
    private float XMove;
    private float YMove;
    [SerializeField] private Transform player; 
    public float sensivity = 40f; 

    private float currentRotationX; 
    private float currentRotationY; 

    public Vector2 lookAxit;

    void Update()
    {
        XMove = lookAxit.x * sensivity * Time.deltaTime;
        YMove = lookAxit.y * sensivity * Time.deltaTime;
        currentRotationX -= YMove;
        currentRotationX = Mathf.Clamp(currentRotationX, -30f, 30f);
        currentRotationY += XMove;
        transform.localRotation = Quaternion.Euler(currentRotationX, 0, 0);
        Quaternion playerRotation = Quaternion.Euler(0, currentRotationY, 0);
        player.rotation = playerRotation;
    }
}
