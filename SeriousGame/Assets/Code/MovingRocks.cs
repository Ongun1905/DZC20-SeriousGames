using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRocks : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p1 = new Vector3(-47f, 21f, 53f);
        float speed = 10f; // higher is faster
        float t = Time.deltaTime * speed;

        transform.position = Vector3.MoveTowards(transform.position, p1, t);
    }

}
