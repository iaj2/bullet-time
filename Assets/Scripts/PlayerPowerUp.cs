using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public static bool powerReady;


    // Start is called before the first frame update
    void Start()
    {
        powerReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)&& powerReady == true)
        {
            powerUp();
            powerReady = false;
            StartCoroutine("powerCooldown");
            
        }


    }

    IEnumerator powerCooldown()
    {
        yield return new WaitForSecondsRealtime(15);
        powerReady = true;
    }

    IEnumerator powerTime()
    {
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
        playerMovement.speed = 5;
        CameraFollow.speed = 5;
    }

    void powerUp()
    {
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
        playerMovement.speed = 25;
        CameraFollow.speed = 27;
        StartCoroutine("powerTime");
    }
}
