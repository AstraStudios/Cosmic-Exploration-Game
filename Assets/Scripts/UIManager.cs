using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int fireType;

    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text numOfKillsText;
    [SerializeField] TMP_Text numOfKillsHighscoreText;

    [SerializeField] Player player;
    [SerializeField] GunController gunController;

    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject losePanel;

    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(true);
        mainPanel.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.health.ToString();
        numOfKillsText.text = gunController.numOfKills.ToString();

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
            numOfKillsHighscoreText.text = "Your highscore is: " + PlayerPrefs.GetInt("NumOfKillsHighscore").ToString();
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

    public void CloseOptions()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void SwitchFireType()
    {

    }
}
