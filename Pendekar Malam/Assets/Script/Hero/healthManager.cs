using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthManager : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] GameObject HealthBarPoint;
    public void DecreaseLife(float damage)
    {
        healthBar.value -= damage;
        if (healthBar.value < damage)
        {
            HealthBarPoint.SetActive(false);
        }
    }
}