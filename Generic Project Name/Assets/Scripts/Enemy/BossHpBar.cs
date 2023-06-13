using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHpBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    public void UpdateHPSlider(float current, float target)
    {
        slider.maxValue = target;
        slider.value = current;
    }
}
