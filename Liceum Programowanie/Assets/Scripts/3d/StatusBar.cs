using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] float changeSpeed = 1;
    float targetPercentage;

    public void SetBarValue(float maxValue, float currentValue)
    {
        //Wartoœæ od 0 do 1
        targetPercentage = maxValue / currentValue;
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.MoveTowards
            (healthBar.fillAmount, targetPercentage, changeSpeed * Time.deltaTime);
    }
}
