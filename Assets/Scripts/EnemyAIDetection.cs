using System;
using StarterAssets;
using UnityEngine;

public class EnemyAIDetection : MonoBehaviour
{
    private LayerMask playerMask;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ratPos = other.transform.position - transform.position;
            ratPos.y += .4f;
            float sneakySpeed = other.GetComponent<ThirdPersonController>().SprintSpeed;
            float currSpeed = other.GetComponent<ThirdPersonController>()._speed;
            if (currSpeed > sneakySpeed + .2f)
            {
                print("death has found you, the ear-splitting rat");
                return;
            }

            if (!Physics.Raycast(transform.position, ratPos, ratPos.magnitude, ~playerMask))
            {
                print("death has found you, the rotund rat");
            }
        }
    }

    private void Awake()
    {
        playerMask = LayerMask.GetMask("Player");
    }

    private Vector3 ratPos;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, ratPos);
    }
}