using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillarMovement : MonoBehaviour
{

    public float forwardSpeed = 5;
    public int gap = 20;
    public float steerSpeed = 150;
    public GameObject bodyPrefab;
    private List<GameObject> bodies = new List<GameObject>();
    private List<Vector3> posHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        //GrowBody();
        //GrowBody();
        //GrowBody();
    }

    // Update is called once per frame
    void Update()
    {
        // move forward
        transform.position += transform.forward * forwardSpeed * Time.deltaTime;

        // steer
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);

        // position history
        posHistory.Insert(0, transform.position);

        // move body of caterpillar
        int index = gap;
        foreach (var body in bodies)
        {
            Vector3 point = posHistory[Mathf.Min(index * gap, posHistory.Count-1)];
            body.transform.position = point;
            //Vector3 moveDirection = point - body.transform.position;
            //body.transform.position += moveDirection * forwardSpeed * Time.deltaTime;
            //body.transform.LookAt(point);
            index+= gap;
        }
    }

    public void GrowBody()
    {
        GameObject body = Instantiate(bodyPrefab);
        bodies.Add(body);
    }
}
