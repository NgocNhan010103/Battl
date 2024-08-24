using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public Image realFillBar;
    public Image virtualFillBar;
    [Space(20)]
    public float maxHealth;
    public float currentHealth;



    public void SetProgressBar(int amount)
    {
        realFillBar.fillAmount = amount;
        Debug.Log(amount);
    }

    public void SetMaxHelath(int max)
    {
        maxHealth = max;
    }

    public void SetCurrentHealth(int current)
    {
        currentHealth = current;
    }

    private void LateUpdate()
    {
        UpdateProgressBar();

        realFillBar.fillAmount = currentHealth / maxHealth;
    }

    //call methods when take damage
    public void UpdateProgressBar()
    {
        if (realFillBar.fillAmount != virtualFillBar.fillAmount)
        {
            if (realFillBar.fillAmount < virtualFillBar.fillAmount)
            {
                virtualFillBar.fillAmount -= Time.deltaTime * 0.1f;
                if (virtualFillBar.fillAmount < realFillBar.fillAmount)
                    virtualFillBar.fillAmount = realFillBar.fillAmount;
            }
            if (realFillBar.fillAmount > virtualFillBar.fillAmount)
            {
                virtualFillBar.fillAmount += Time.deltaTime * 0.1f;
                if (virtualFillBar.fillAmount > realFillBar.fillAmount)
                    virtualFillBar.fillAmount = realFillBar.fillAmount;
            }
        }
    }
}
