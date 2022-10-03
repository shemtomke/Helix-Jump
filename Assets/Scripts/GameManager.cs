using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    public static bool mute = false;
    public static bool isGameStarted;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;

    public static int currentLevelIndex;

    public Slider gameProgressSlider;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

    public static int numberOfPassedRings = 0;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }
    void Start()
    {
        Time.timeScale = 1;
        isGameStarted = gameOver = levelCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex+1).ToString();

        int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        if(Input.GetMouseButton(0) && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }

        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Level");
            }
        }

        if (levelCompleted)
        {
            levelCompletedPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene("Level");
            }
        }
    }
}
