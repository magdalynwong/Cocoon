using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject foodPrefab;
    public float rotationSpeed = 100.0f;
    public PointsManager pointsManager;
    public AudioClip crunchSound;

    
    private void OnTriggerEnter(Collider other)
    {

        // add to caterpillar body
        CaterpillarMovement caterpillarHead = other.gameObject.GetComponent<CaterpillarMovement>();
        if (caterpillarHead != null)
        {
            // play crunch sound effect
            AudioSource.PlayClipAtPoint(crunchSound, transform.position);         

            Destroy(gameObject);

            caterpillarHead.GrowBody();
            SpawnFood();
            pointsManager.updatePoints(3f);
        }
    }

    private void SpawnFood()
    {
        GameObject newFood = Instantiate(foodPrefab);

        // random position of the new food object
        newFood.transform.position = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
    }
}
