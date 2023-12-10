using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerUpPrefab;

    public void StartSpawnRoutine(float delay)
    {
        StartCoroutine(Spawn(delay));
    }

    IEnumerator Spawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject powerUp = Instantiate(powerUpPrefab);
        powerUp.transform.position = new Vector3(Random.Range(-12f, 20f), 1f, Random.Range(-15f, 15f));
    }
}
