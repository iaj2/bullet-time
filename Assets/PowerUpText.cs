using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpText : MonoBehaviour
{

    public TextMeshProUGUI powerText;
    public float powerCooldownText = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        powerText.text = "POWERUP: " + powerCooldownText;


        if(powerCooldownText > 0)
        {
            powerCooldownText -= Time.deltaTime;
        }
    }
}
