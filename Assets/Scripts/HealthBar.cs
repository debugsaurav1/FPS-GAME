using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    

    public void SetMaxHealth(float hlth)
    {
        slider.maxValue = hlth;
        slider.value = hlth;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
