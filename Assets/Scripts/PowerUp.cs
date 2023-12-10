using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public AudioClip powerupSound;
    public PointsManager pointsManager;
    private SpawnManager spawnManager;
    public float rotationSpeed = 100.0f;

    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        pointsManager = FindObjectOfType<PointsManager>();
    }

    void Update()
    {
        // rotate object around its y axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        CaterpillarMovement caterpillarHead = other.gameObject.GetComponent<CaterpillarMovement>();
        if (caterpillarHead != null)
        {
            AudioSource.PlayClipAtPoint(powerupSound, transform.position);
            Destroy(gameObject);

            int numberOfTimesToGrow = Random.Range(3, 6);

            for (int i = 0; i < numberOfTimesToGrow; i++)
            {
                caterpillarHead.GrowBody();
            }
            caterpillarHead.forwardSpeed += 1f;

            pointsManager.updatePoints(2f * numberOfTimesToGrow);
            spawnManager.StartSpawnRoutine(5);
           
        }
    }
}
