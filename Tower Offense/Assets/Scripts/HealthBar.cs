using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHP(int health)
    {
        slider.maxValue = health;
    }
    public void setHealth(int health)
    {
        slider.value = health;
    }

    public int getHealth()
    {
        return (int) slider.value;
    }
}
