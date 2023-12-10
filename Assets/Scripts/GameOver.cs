using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text pauseMessage;
    public Button playAgainButton;
    public Button mainMenuButton;
    public Button backgroundEnd;
    public PointsManager pointsManager;

    void Start()
    {
        // disable the text initially
        pauseMessage.gameObject.SetActive(false);
        backgroundEnd.gameObject.SetActive(false);
        playAgainButton.onClick.AddListener(PlayAgain);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void Update()
    {
        // check if the game is paused
        if (Time.timeScale == 0f)
        {
            // show the text
            pauseMessage.gameObject.SetActive(true);
            backgroundEnd.gameObject.SetActive(true);
        }
        else
        {
            // Hide the text when the game is not paused
            pauseMessage.gameObject.SetActive(false);
        }
    }

    public void PlayAgain()
    {
        // reload the current scene
        Time.timeScale = 1f;

        // reload the current scene
        pointsManager.ResetPoints();

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    
    public void GoToMainMenu()
    {
        // unpause the game
        Time.timeScale = 1f;
        pointsManager.ResetPoints();

        // load the main menu scene
        SceneManager.LoadScene("NewIntro"); 
    }
}