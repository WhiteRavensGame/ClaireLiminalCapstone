using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOrder : MonoBehaviour
{
    #region Gameobjects
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;

    public GameObject shape1;
    public GameObject shape2;
    public GameObject shape3;
    public GameObject shape4;
    public GameObject shape5;
    #endregion
    
    void Start()
    {
        #region gameObject.SetActive
        target1.transform.gameObject.SetActive(true);
        shape1.transform.gameObject.SetActive(true);

        target2.transform.gameObject.SetActive(false);
        target3.transform.gameObject.SetActive(false);
        shape2.transform.gameObject.SetActive(false);
        shape3.transform.gameObject.SetActive(false);
        shape4.transform.gameObject.SetActive(false);
        shape5.transform.gameObject.SetActive(false);
        #endregion
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "ColourTarget")
        {
            target2.transform.gameObject.SetActive(true);
            shape2.gameObject.SetActive(true);
            target1.transform.gameObject.SetActive(false);
        }

        if (other.transform.tag == "BounceTarget")
        {
            target3.transform.gameObject.SetActive(true);
            shape3.transform.gameObject.SetActive(true);
            target2.transform.gameObject.SetActive(false);
        }

        if (other.transform.tag == "Portal")
        {
            shape4.transform.gameObject.SetActive(true);
            shape5.transform.gameObject.SetActive(true);
            target3.transform.gameObject.SetActive(false);
        }
    }
}
