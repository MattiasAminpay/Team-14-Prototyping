using System;
using StarterAssets;
using UnityEngine;

public class EnemyAIDetection : MonoBehaviour
{
    private LayerMask enemyAndPlayerMask;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float sneakySpeed = other.GetComponent<ThirdPersonController>().SprintSpeed;
            float currSpeed = other.GetComponent<CharacterController>().velocity.magnitude;
            if (currSpeed > sneakySpeed)
            {
                print("death has found you, the ear-splitting rat");
                return;
            }

            if (!Physics.Raycast(transform.position, other.transform.position,
                Vector3.Distance(transform.position, other.transform.position), ~enemyAndPlayerMask))
            {
                print("death has found you, the rotund rat");
            }
        }
    }

    private void Awake()
    {
        enemyAndPlayerMask = LayerMask.GetMask("Player", "Enemy");
    }
}