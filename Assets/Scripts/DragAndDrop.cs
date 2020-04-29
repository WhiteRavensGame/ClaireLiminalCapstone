using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class DragAndDrop : MonoBehaviour
{
    public OVRInput.Controller controller;
    private GameObject grabbedObject;

    //private Vector3 locationOfGrabbedObject;

    public float distance;
    public float speed;
    
    Renderer modelRenderer;
    float controlTime;

    public bool pickedUp = false;
    public bool dropped = false;

    private float fixedDeltaTime;

    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        controlTime += Time.deltaTime;

        #region VRController
        // Get the currently active VR device
        var vrDevice = VRDevice.Device;
        if (vrDevice == null)
            return;

        // Get the primary input device (the controller)
        var inputDevice = vrDevice.PrimaryInputDevice;
        if (inputDevice == null)
            return;
        #endregion

        if (inputDevice.GetButtonDown(VRButton.One))
        {
            Click();
        }

        if (inputDevice.GetButtonUp(VRButton.One))
        {
            Drop();
        }

        #region explosion blocks things

        //if (BigCollide == true)
        //{
        //    Instantiate(BigExplosion, gameObject.transform.position, Quaternion.identity);
        //    Destroy(grabbedObject);
        //
        //    BigExplosion.transform.parent = null;
        //    BigExplosion.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //
        //    BigExplosion.gameObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(controller);
        //
        //    BigExplosion = null;
        //}
        //
        //if (SmallCollide == true)
        //{
        //    Instantiate(SmallExplosion, gameObject.transform.position, Quaternion.identity);
        //    Destroy(BigExplosion);
        //
        //    SmallExplosion.transform.parent = null;
        //    SmallExplosion.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //
        //    SmallExplosion.gameObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(controller);
        //
        //    SmallExplosion = null;
        //}

        #endregion

        //modelRenderer.material.SetFloat("_ControlTime", controlTime);
    }

    private void Click()
    {
        var hitResult = VRDevice.Device.PrimaryInputDevice.Pointer.CurrentRaycastResult;
        if (hitResult.gameObject != null)
        {
            if (hitResult.gameObject.tag == "Object")
            {
                grabbedObject = hitResult.gameObject;
                grabbedObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                grabbedObject.transform.position = transform.position;
                grabbedObject.transform.parent = transform;
                pickedUp = true;

                controlTime = 0;
                
                if (Time.timeScale == 1.0f)
                {
                    Time.timeScale = 0.2f;
                }
                else
                {
                    Time.timeScale = 1.0f;
                }

                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            }
        }
    }

    private void Drop()
    {
        if (grabbedObject != null)
        {
            grabbedObject.transform.parent = null;
            grabbedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed; 

            //grabbedObject.gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(OVRInput.GetLocalControllerVelocity(controller)) * speed;

            Shatter shatterComponent = grabbedObject.GetComponent<Shatter>();
            if (shatterComponent != null)
            {
                shatterComponent.SetExplodable();
            }

            grabbedObject = null;
        }
    }
    
}
