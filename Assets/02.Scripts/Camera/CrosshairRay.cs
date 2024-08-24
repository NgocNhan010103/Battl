using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairRay : MonoBehaviour
{
    public Camera firsetPersonCamera;
    public Camera thirstPersonCamera;

    public Image crosshairImage;
    public GameObject crosshair;
    public RaycastWeapon raycastWeapon;
    public ProgressBar otherProgressBar;

    Ray ray;
    RaycastHit hit;

    void Update()
    {
        if (firsetPersonCamera.isActiveAndEnabled)
            RayInCamera(firsetPersonCamera);
        else RayInCamera(thirstPersonCamera);

    }

    void RayInCamera(Camera camera)
    {
        Vector3 cameraDirection = camera.transform.forward;

        ray = new Ray(camera.transform.position, cameraDirection);

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        Physics.Raycast(ray, out hit);
        crosshair.transform.position = hit.point;

        if (Physics.Raycast(ray, out hit))
        {
            gameObject.GetComponent<PlayerController>().cunrrentEntity = hit.collider.GetComponent<Entity>();

            if (gameObject.GetComponent<PlayerController>().cunrrentEntity != null)
            {
                otherProgressBar.gameObject.SetActive(true);
                otherProgressBar.maxHealth = hit.collider.GetComponent<Entity>().maxHealth;
                otherProgressBar.currentHealth = hit.collider.GetComponent<Entity>().currentHealth;
                hit.collider.GetComponent<Entity>().progressBar = otherProgressBar;
                crosshairImage.color = Color.red;

                if (raycastWeapon.IsFiring())
                {
                    hit.collider.GetComponent<Entity>().TakeDamage(500);
                    raycastWeapon.isFiring = false;
                }
            }
            else
            {
                crosshairImage.color = Color.white;
                otherProgressBar.gameObject.SetActive(false);
            }
        }
        return;
    }
}
