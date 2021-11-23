using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private const float WALK_THRESHOLD = .5f;

    [SerializeField] private Transform patrolPointsParent;
    [SerializeField] public float patrolTime = 1.5f;
    [SerializeField, Range(0f, 10f)] private float walkSpeed = 5f;
    [SerializeField, Range(0f, 10f)] public float detectionRadius = 5f;
    [SerializeField, Range(0f, 5f)] public float detectionTime = 2f;
    [SerializeField, Range(0f, 360f)] public float enemyFOV = 180f;

    public bool hideVisual = false;
    public bool canKill = true;

    private Quaternion targetRotation;
    private Rigidbody body;
    private Transform[] patrolPoints;
    private int patrolIndex;

    private const float TURN_SMOOTHNESS = .05f;

    private int PatrolIndex
    {
        get => patrolIndex;
        set
        {
            if (value >= patrolPoints.Length || value < 0)
                value = 0;
            patrolIndex = value;
        }
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            Vector3 walkTo = new Vector3(patrolPoints[patrolIndex].position.x, 0f,
                patrolPoints[patrolIndex].position.z);
            Vector3 walkFrom = new Vector3(transform.position.x, 0f, transform.position.z);
            Vector3 relativePos = walkTo - walkFrom;
            
            if (relativePos.magnitude < WALK_THRESHOLD)
            {
                PatrolIndex++;
                yield return new WaitForSeconds(patrolTime);
            }

            targetRotation = Quaternion.LookRotation(relativePos.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TURN_SMOOTHNESS);

            Vector3 newVelocity = relativePos.normalized * walkSpeed;
            newVelocity.y = body.velocity.y;
            body.velocity = newVelocity;
            yield return new WaitForFixedUpdate();
        }
    }

    private void Start()
    {
        StartCoroutine(Patrol());
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        List<Transform> foundPoints = new List<Transform>();
        foreach (Transform point in patrolPointsParent.GetComponentsInChildren<Transform>())
        {
            if (point == patrolPointsParent) continue;

            foundPoints.Add(point);
        }

        patrolPoints = foundPoints.ToArray();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}