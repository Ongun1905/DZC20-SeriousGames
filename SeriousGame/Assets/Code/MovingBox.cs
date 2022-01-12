using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    bool up;

    // Start is called before the first frame update
    void Start()
    {
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p0 = new Vector3(-230.3f, 7.1f, 172f);
        Vector3 p1 = new Vector3(-230.3f, 13.2f, 172f);
        float speed = 10f; // higher is faster
        float t = Time.deltaTime * speed;

        if(up){
            transform.position = Vector3.MoveTowards(transform.position, p1, t);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, p0, t);
        }
        if(transform.position == p1 || transform.position == p0){
            up = !up;
        }
        
    }
}
