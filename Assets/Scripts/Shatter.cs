using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject newShapes;

    bool collide = false;
    bool explodable = false;

    public float thrust = 1000f;
    public Rigidbody rb;

    public DragAndDrop mainScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (explodable == true)
        {
            Destroy(gameObject);
            Instantiate(newShapes, this.transform.position, Quaternion.identity);
            rb = newShapes.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * thrust);
        }

    }

    public void SetExplodable()
    {
        explodable = true;
    }
}
