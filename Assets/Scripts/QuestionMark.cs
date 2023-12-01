using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour
{
    // rotation speed in degrees/second
    public float rotationSpeed = 100.0f;
    public GameObject questionMarkPrefab;
    public PointsManager pointsManager;

    void Start()
    {

    }

    void Update()
    {
        // rotate object around its y axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // add to caterpillar body
        CaterpillarMovement caterpillarHead = other.gameObject.GetComponent<CaterpillarMovement>();
        if (caterpillarHead != null)
        {
            // play power up sound effect
            //AudioSource.PlayClipAtPoint(crunchSound, transform.position);

            Destroy(gameObject);

            int numberOfTimesToGrow = Random.Range(3, 6); // Generates a random number between 3 and 5 (exclusive)

            for (int i = 0; i < numberOfTimesToGrow; i++)
            {
                caterpillarHead.GrowBody();
            }

            pointsManager.updatePoints(3f * numberOfTimesToGrow);
        }
    }

private void SpawnQuestionMark()
    {
        GameObject questionMark = Instantiate(questionMarkPrefab);
        // random position of the new object
        questionMark.transform.position = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
    }
}
