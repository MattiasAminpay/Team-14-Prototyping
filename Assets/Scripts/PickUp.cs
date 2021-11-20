using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;

     void OnMouseDown()
    {
        //GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().freezeRotation = true;

    }

     void OnMouseUp()
    {
        this.transform.parent = null;
        //GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().freezeRotation = false;
    }

}
