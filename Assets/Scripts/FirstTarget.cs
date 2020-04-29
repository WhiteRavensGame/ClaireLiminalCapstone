using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTarget : MonoBehaviour
{
    public GameObject target1;
    public GameObject sphere;
    public GameObject shatterCube1;
    GameObject target1Clone;
    public bool hasCollided;

    public GameObject chosenShape;
    public GameObject[] shapes;

    void Start()
    {
        //GameObject sphereClone = Instantiate(sphere, transform.position, Quaternion.identity);
        //GameObject target1Clone = Instantiate(target1, transform.position, Quaternion.identity);
        hasCollided = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Object" && !hasCollided)
        {
            //target1.gameObject.SetActive(false);
            //choose random prefab = chosenShape
            Instantiate(chosenShape, new Vector3(3.63f, 3.16f, 8.889f), Quaternion.identity);
            hasCollided = true;
            DestroyClone();
        }
    }

    void DestroyClone()
    {
        Destroy(chosenShape);
    }
}
