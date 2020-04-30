using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool isTarget;
    public Material onTarget;
    public Material offTarget;

    void Start()
    {
        
    }

    void Update()
    {
        if (isTarget == true)
        {
            gameObject.tag = "ColourTarget";
            gameObject.GetComponent<Renderer>().material = onTarget;
        }
        else
        {
            gameObject.tag = "TargetsToBe";
            gameObject.GetComponent<Renderer>().material = offTarget;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Object" && isTarget)
        {
            print("YAY");
            isTarget = false;

            GameManager.Instance.score += 5;
            GameManager.Instance.ChooseNewTarget();
        }
    }
}
