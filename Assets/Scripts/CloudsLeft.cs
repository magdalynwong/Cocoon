
// CloudMovement.cs
using System.Collections;
using UnityEngine;

public class CloudsLeft : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float moveDistance = 30.0f;

    void OnEnable()
    {
        StartCoroutine(MoveClouds());
    }

    IEnumerator MoveClouds()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + Vector3.left * moveDistance;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / moveDistance);
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        // Disable the cloud object after moving
        gameObject.SetActive(false);
    }
}