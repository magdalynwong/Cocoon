using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CaterpillarMovement : MonoBehaviour
{
    public float forwardSpeed = 5;
    public int gap = 15;
    public float steerSpeed = 150;
    public GameObject bodyPrefab;
    private List<GameObject> bodies = new List<GameObject>();
    private List<Vector3> posHistory = new List<Vector3>();
    private bool isFalling = false;
    public TMP_Text pauseText;
    public TMP_Text gamePoints;
    public PointsManager pointsManager; 
    public Button playAgainButton;
    public Button mainMenuButton;

    // Update is called once per frame
    void Update()
    {
        if (!isFalling)
        {
            // move forward
            transform.position += transform.forward * forwardSpeed * Time.deltaTime;

            // steer
            float steerDirection = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);

            // position history
            posHistory.Insert(0, transform.position);

            // move body of caterpillar
            int index = gap;
            foreach (var body in bodies)
            {
                Vector3 point = posHistory[Mathf.Min(index * gap, posHistory.Count - 1)];
                body.transform.position = point;
                index += gap;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TransparentPlatform"))
        {
            EndGame();
        }
    }

    public void GrowBody()
    {
        GameObject body = Instantiate(bodyPrefab);
        bodies.Add(body);
    }


    public void EndGame()
    {
        isFalling = true;
        Time.timeScale = 0f;  // Pause the game

        // Show the game over message with obtained points
        float currentPoints = pointsManager.getCurrentScore();
        pauseText.text = "GAME OVER! \nObtained Points: " + currentPoints;

        // Show the pause text
        pauseText.gameObject.SetActive(true);
        // Remove the points text
        gamePoints.gameObject.SetActive(false);

        // Show the buttons
        playAgainButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }
}