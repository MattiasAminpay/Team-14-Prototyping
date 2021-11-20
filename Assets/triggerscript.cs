using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerscript : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject prefab;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(prefab, spawnpoint.position, spawnpoint.rotation);
        Debug.Log("is this working?");
    }
}
