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
            //// spawn question mark every 5 seconds
            //StartCoroutine(SpawnQuestionMark(1));

            int numberOfTimesToGrow = Random.Range(3, 7); 

            for (int i = 0; i < numberOfTimesToGrow; i++)
            {
                caterpillarHead.GrowBody();
            }

            pointsManager.updatePoints(3f * numberOfTimesToGrow);

            
        }
        
    }
 

    IEnumerator SpawnQuestionMark(float delay)
    {
        
        // wait for the specified delay
        yield return new WaitForSeconds(delay);
        print("h");
        GameObject questionMark = Instantiate(questionMarkPrefab);
        // random position of the new object
        questionMark.transform.position = new Vector3(Random.Range(-14f, 22f), 0.6f, Random.Range(-16f, 16f));
    }
}
