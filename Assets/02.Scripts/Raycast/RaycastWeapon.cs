using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    public CharacterAiming characterAiming;
    public ParticleSystem[] muzzleFlash;
    public ParticleSystem hitEffect;
    public GameObject crosshair;

    public void StartFiring()
    {
        if (characterAiming.canFire)
        {
            isFiring = true;
            foreach (var muzzle in muzzleFlash)
            {
                muzzle.Emit(1);
            }
            hitEffect.transform.position = crosshair.transform.position;
            hitEffect.transform.forward = crosshair.transform.forward;
            hitEffect.Emit(1);
        }
    }


    public bool IsFiring() => isFiring;
}
