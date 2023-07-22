using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpText : MonoBehaviour
{

    public TextMeshProUGUI powerText;
    public float powerCooldownText = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int cooldownSeconds = Mathf.CeilToInt(powerCooldownText);


        if (PlayerPowerUp.powerReady == true)
        {
            powerText.text = "POWER UP: READY";
            powerCooldownText = 15;
        }

        else
        {
            powerText.text = "POWER UP: " + cooldownSeconds.ToString();
        }




        if (powerCooldownText > 0)
        {
            powerCooldownText -= Time.unscaledDeltaTime;

            
        }
    }
}
