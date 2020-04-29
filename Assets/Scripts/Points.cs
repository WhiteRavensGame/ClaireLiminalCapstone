using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Object")
        {
            Destroy(other.gameObject);
        }
    }
}
