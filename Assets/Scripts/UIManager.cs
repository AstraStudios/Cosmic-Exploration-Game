using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text numOfKillsText;

    [SerializeField] Player player;
    [SerializeField] GunController gunControll;

    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject losePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.health.ToString();
        numOfKillsText.text = gunControll.numOfKills.ToString();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            mainPanel.SetActive(false);
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (player.health <= 0)
        {
            mainPanel.SetActive(false);
            losePanel.SetActive(true);
        }
    }

    public void EndPauseMenu()
    {
        mainPanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadBacktoMain()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
