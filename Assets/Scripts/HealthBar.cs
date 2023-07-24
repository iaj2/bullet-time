using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        healthText.text = "Health: " + (slider.value * 100).ToString();
    }

    public void SetValue(float health)
    {
        slider.value = health;
        healthText.text = "Health: " + Mathf.Round(health*100).ToString();
    }

}
