using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTree : MonoBehaviour
{
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position+new Vector3(-11.9f,18f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10f; // higher is faster
        float t = Time.deltaTime * speed;
        float turnSpeed = 1;
        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, 122), turnSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, pos, t);
    }

}
