using UnityEngine;

public class TitleUp : MonoBehaviour
{
    public float moveSpeed = 50f;

    void Update()
    {
        // Move the title upward
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Check if the title has moved off the screen (you may need to adjust the threshold)
        if (transform.position.y > Screen.height+15)
        {
            // Deactivate the title GameObject
            gameObject.SetActive(false);
        }
    }
}
