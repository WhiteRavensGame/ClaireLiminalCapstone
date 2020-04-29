using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColour : MonoBehaviour
{
    public Material red;
    public Material blue;
    public Material plain;
    public Material green;
    public Material orange;
    public Material purple;
    public Material yellow;
    public Material turquoise;
    
    void OnCollisionEnter(Collision other)
    {
        //if (other.transform.tag == "Object")
        //{
        print("collided");
        //if(other.transform.tag == "Object" && other.GetComponent<Renderer>().material == purple)
            if(GetComponent<Renderer>().material == purple)
            {
                gameObject.GetComponent<Renderer>().material = purple;
                print("I should be purple");
            }
            else if 
            (GetComponent<Renderer>().material == orange)
            {
                gameObject.GetComponent<Renderer>().material = orange;
            }
       // }

    }

}
