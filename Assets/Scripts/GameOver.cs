using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text pauseMessage;
    public float moveSpeed = 2.0f;
    public Button playAgainButton;
    public Button mainMenuButton;
    public PointsManager pointsManager;

    void Start()
    {
        // Disable the text initially
        pauseMessage.gameObject.SetActive(false);
        playAgainButton.onClick.AddListener(PlayAgain);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void Update()
    {
        // Check if the game is paused
        if (Time.timeScale == 0f)
        {
            // Show the text
            pauseMessage.gameObject.SetActive(true);

            // Move the text down
            Vector3 targetPosition = transform.position - Vector3.up * moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Hide the text when the game is not paused
            pauseMessage.gameObject.SetActive(false);
        }
    }

    public void PlayAgain()
    {
        // Reload the current scene
        Time.timeScale = 1f;

        // Reload the current scene
        pointsManager.ResetPoints();

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

    }

    public void GoToMainMenu()
    {
        // Unpause the game
        Time.timeScale = 1f;
        pointsManager.ResetPoints();

        // Load the main menu scene
        SceneManager.LoadScene("Intro"); 
    }
}