using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secondpickupscript : MonoBehaviour
{
    public float pickUpRange = 5;
    private GameObject heldObj;
    public Transform holdParent;
    public float moveForce = 250;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null) {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
                {
                    DropOject();
                }

            
            if(heldObj != null)
            {
                MoveObject();
            }
            void MoveObject()
            {
                if(Vector3.Distance(heldObj.transform.position, holdParent.position)> 0.1f)
                {
                    Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
                    heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
                }
            }
        }
    }

    void PickUpObject (GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;

        }
    }
    void DropOject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
