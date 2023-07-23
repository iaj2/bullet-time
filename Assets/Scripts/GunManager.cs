using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    // List to hold guns
    public List<GameObject> loadOut = new List<GameObject>();
    // Current Gun data
    private GameObject currentGun;
    private int currentGunIndex;
    // SwapGun cooldown
    private float swapGunCoolDownDuration = 1f;
    private float swapGunCoolDown;
    private bool swapGunCooling = false;

    // Gun prefabs
    public GameObject pistol;
    public GameObject shotGun;
    void Start()
    {
        // Start with pistol by Default
        loadOut.Add(pistol);
        currentGunIndex = 0;
        loadOut.Add(shotGun);
        EquipGun(currentGunIndex);
    }

    private void StartSwapCoolDown()
    {
        swapGunCoolDown = swapGunCoolDownDuration;
        swapGunCooling = true;
    }
    private void resetSwapCoolDown()
    {
        swapGunCoolDown = swapGunCoolDownDuration;
        swapGunCooling = false;
    }
    private void Update()
    {
        if (swapGunCooling)
        {
            swapGunCoolDown -= Time.deltaTime;
            if (swapGunCoolDown <= 0) {
                resetSwapCoolDown();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            FireGun();
        }
        // Swap to next gun
        if (Input.GetKey(KeyCode.E) && !swapGunCooling)
        {
            IncrementGunIndex();
            EquipGun(currentGunIndex);
            StartSwapCoolDown();
        }
        // Swap previous gun
        if (Input.GetKey(KeyCode.Q) && !swapGunCooling)
        {
            DecrementGunIndex();
            EquipGun(currentGunIndex);
            StartSwapCoolDown();
        }

    }

    private void FireGun()
    {
        if (currentGun != null)
        {
            currentGun.GetComponent<BaseGun>().Fire();
        }
    }

    private void EquipGun (int gunIndex)
    {
        // Check if the index is within the range of the gunPrefabs array
        if (gunIndex >= 0 && gunIndex < loadOut.Count)
        {
            // Deactivate current gun
            if (currentGun != null){
                currentGun.SetActive(false);
            }
            

            // Activate gun
            currentGun = loadOut[gunIndex];
            currentGun.SetActive(true);
            currentGunIndex = gunIndex;
        }
    }

    private void IncrementGunIndex()
    {
        if (currentGunIndex == loadOut.Count - 1)
        {
            currentGunIndex = 0;
        }
        else
        {
            currentGunIndex++;
        }
    }

    private void DecrementGunIndex()
    {
        if (currentGunIndex == 0)
        {
            currentGunIndex = loadOut.Count - 1;
        }
        else
        {
            currentGunIndex--;
        }
    }
}
