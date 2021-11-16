using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cablebite : MonoBehaviour
{
   
    float curDist = 2;
    GameObject[] items;
    GameObject itemToDestroy;
    public GameObject Player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            items = GameObject.FindGameObjectsWithTag("Cables");
            curDist = 2;
            foreach (GameObject item in items)
            {
                float dist = Vector3.Distance(Player.transform.position, item.transform.position);
                if (dist < curDist)
                {
                    curDist = dist;
                    itemToDestroy = item;
                    print(dist);
                }
            }
            if (itemToDestroy != null)
            {
                Destroy(itemToDestroy);
            }
        }
    }
}

