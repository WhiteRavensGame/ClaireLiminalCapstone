using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject portal1;

    public float x;
    public float y;
    public float z;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Portal")
        {
            transform.position = new Vector3(x, y, z);
        }

    }
}
