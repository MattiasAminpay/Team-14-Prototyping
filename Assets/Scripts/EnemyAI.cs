using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private const float WALK_THRESHOLD = .5f;

    [SerializeField] private Transform patrolPointsParent;
    [SerializeField, Range(0f, 10f)] private float walkSpeed = 5f;
    [SerializeField, Range(0f, 10f)] public float detectionRadius = 5f;

    private Vector3 walkVelocity;
    private Rigidbody body;
    private Transform[] patrolPoints;
    private int patrolIndex;

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

    private void FixedUpdate()
    {
        Patrol();
    }

    private void Patrol()
    {
        UpdatePatrolPoint();
        body.velocity = walkVelocity;
    }

    private void UpdatePatrolPoint()
    {
        if (Vector3.Distance(patrolPoints[patrolIndex].position, transform.position) > WALK_THRESHOLD) return;

        PatrolIndex++;
        walkVelocity = (patrolPoints[PatrolIndex].position - transform.position).normalized * walkSpeed;
    }

    private void Start()
    {
        patrolPoints = patrolPointsParent.GetComponentsInChildren<Transform>();
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        walkVelocity = (patrolPoints[PatrolIndex].position - transform.position).normalized * walkSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}