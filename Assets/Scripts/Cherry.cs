using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public GameObject cherryPrefab;
    public float rotationSpeed = 100.0f;
    public PointsManager pointsManager;
    public AudioClip crunchSound;

    private void OnTriggerEnter(Collider other)
    {
        CaterpillarMovement caterpillarHead = other.gameObject.GetComponent<CaterpillarMovement>();
        if (caterpillarHead != null)
        {
            // play crunch sound effect
            AudioSource.PlayClipAtPoint(crunchSound, 0.8f * Camera.main.transform.position, 10f);
            Destroy(gameObject);

            // add to caterpillar body, spawn new cherry
            caterpillarHead.GrowBody();
            caterpillarHead.GrowBody();
            SpawnCherry();
            pointsManager.updatePoints(2f);
        }
    }

    private void SpawnCherry()
    {
        GameObject newCherry = Instantiate(cherryPrefab);

        // random position of the new cherry object
        newCherry.transform.position = new Vector3(Random.Range(-10f, 20f), 1.4f, Random.Range(-13f, 13f));
    }
}
