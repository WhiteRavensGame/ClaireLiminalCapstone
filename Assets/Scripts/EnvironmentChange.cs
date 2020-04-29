using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentChange : MonoBehaviour
{
    public float environmentSpeed;
    public Vector3 Direction;
    public GameObject environment1;

    public Rigidbody frozenObject;
    public GameObject enviroTarget1;
    public bool onTheMove = false;

    float currentTime = 0f;
    float startingTime = 1f;

    void Start()
    {
        environmentSpeed = 10f;
        Direction = Vector3.left;

        frozenObject = GetComponent<Rigidbody>();

        enviroTarget1.gameObject.SetActive(false);
        currentTime = startingTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Object")
        {
            environment1.transform.Translate(Direction * environmentSpeed);
            enviroTarget1.gameObject.SetActive(false)     ;
            onTheMove = true;
        }
    }

    void Update()
    {
        if (onTheMove == true)
        {
            currentTime -= 1 * Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                environment1.transform.tag = "FrozenEnvironment";
            }
        }

        if (environment1.tag == "FrozenEnvironment")
        {
            frozenObject.constraints = RigidbodyConstraints.FreezePosition;
            frozenObject.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
