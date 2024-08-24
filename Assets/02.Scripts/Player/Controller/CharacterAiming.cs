using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterAiming : MonoBehaviour
{
    public Rig aimRigging;
    float aimDuration = 0.5f;

    public bool canFire = false;


    public void ChangeAnimationAimRig()
    {
        if (aimRigging.weight == 0)
        {
            while (aimRigging.weight < 1)
            {
                aimRigging.weight += Time.deltaTime / aimDuration;
            }
            canFire = true;
        }
        else
        {
            while (aimRigging.weight > 0)
            {
                aimRigging.weight -= Time.deltaTime / aimDuration;
            }
            canFire = false;
        }
    }
}
