using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject[] targets;
    public bool isTarget;
    public GameObject chosenTarget;
    public Material onTarget;
    public Material offTarget;
    public bool hit;

    void Start()
    {
        chosenTarget = targets[Random.Range(0, targets.Length)];
        chosenTarget.transform.gameObject.tag = "ColourTarget";
        isTarget = true;
        hit = false;
    }

    void Update()
    {
        if (isTarget == true)
        {
            chosenTarget.transform.gameObject.tag = "ColourTarget";
            gameObject.GetComponent<Renderer>().material = onTarget;
            hit = false;
        }
        else
        {
            chosenTarget.transform.gameObject.tag = "TargetsToBe";
            gameObject.GetComponent<Renderer>().material = offTarget;
        }

        if (hit == true)
        {
            chosenTarget = targets[Random.Range(0, targets.Length)];
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Object" && isTarget)
        {
            isTarget = false;
            hit = true;
        }
    }
}
