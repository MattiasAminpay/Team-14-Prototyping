using StarterAssets;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyAIDetection : MonoBehaviour
{
    [SerializeField] private EnemyAI ai;

    private LayerMask playerMask;
    private SphereCollider sphereCol;
    [SerializeField] private Transform visual;

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

    private void Update()
    {
        if (ai.hideVisual)
        {
            visual.gameObject.SetActive(false);
        }
        else
        {
            visual.gameObject.SetActive(true);
            float detectionDiameter = ai.detectionRadius * 2;
            visual.localScale = new Vector3(detectionDiameter, detectionDiameter, detectionDiameter); 
        }
        sphereCol.radius = ai.detectionRadius;
        transform.position = ai.transform.position;
    }

    private void Awake()
    {
        sphereCol = GetComponent<SphereCollider>();
        playerMask = LayerMask.GetMask("Player");
    }

    private Vector3 ratPos;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, ratPos);
    }
}