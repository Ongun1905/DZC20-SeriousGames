using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRocks : MonoBehaviour
{
    private Vector3 p0;

    // Start is called before the first frame update
    void Start()
    {
        p0 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 p0 = new Vector3(-2.5f, 0f, 0f);
        //Vector3 p1 = new Vector3(-2.5f, 26.0f, 1.2f);
        Vector3 p1 = new Vector3(-47f, -21f, 53f);
        Vector3 p2 = new Vector3(-53.25f, -41.2993f, 52.31f);
        
 /*       Vector3 targetPosition;
        if (Vector3.Distance(transform.position, p1) < 0.1f){
            targetPosition = p2;
        } else {
            targetPosition = p1;
        }
*/        
        float speed = 10f; // higher is faster
        float t = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, p1, t);

    }

}
