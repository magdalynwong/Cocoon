using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour
{
    // rotation speed in degrees/second
    public float rotationSpeed = 100.0f;
    public GameObject questionMarkPrefab;

    void Start()
    {

    }

    void Update()
    {
        // rotate object around its y axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void SpawnQuestionMark()
    {
        GameObject questionMark = Instantiate(questionMarkPrefab);
        // random position of the new object
        questionMark.transform.position = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
    }
}
