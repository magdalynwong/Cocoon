using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{ 
    // Reference to the Food prefab
    public GameObject foodPrefab;

    private void OnTriggerEnter(Collider other)
    {
         // Destroy boxes that are hit by an explosion
        CaterpillarMovement caterpillarHead = other.gameObject.GetComponent<CaterpillarMovement>();
        if (caterpillarHead != null)
        {
            Destroy(gameObject);
            
            caterpillarHead.GrowBody();
            SpawnFood();
        }
    }

    private void SpawnFood()
    {
        GameObject newFood = Instantiate(foodPrefab);

        // random position of the new food object
        newFood.transform.position = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
    }
}
