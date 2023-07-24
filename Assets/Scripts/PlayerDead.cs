using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{

    public GameObject DeathScreen;
    public GameObject Main;
    public GameObject enemySpawner;
    public TextMeshProUGUI bitsScore;
    public TextMeshProUGUI killScore;
    public static float kills = 0;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.alive == false)
        {
            Main.SetActive(false);
            DeathScreen.SetActive(true);
            Time.timeScale = 0;
            enemySpawner.SetActive(false);
            player.SetActive(false);
        }

        killScore.text = "Kills: " + kills;

        bitsScore.text = "Max bits " + Mathf.Round(Bits.maxBits);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
