using StarterAssets;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyAIDetection : MonoBehaviour
{
    [SerializeField] private EnemyAI ai;
    [SerializeField] private EnemyDetectionUI detect;
    [SerializeField] private Transform visual;

    private LayerMask _playerMask;
    private SphereCollider _sphereCol;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThirdPersonController playerCtrl = other.GetComponent<ThirdPersonController>();
            float sneakySpeed = playerCtrl.SprintSpeed;
            float currSpeed = playerCtrl._speed;
            
            detect.hearing = currSpeed > sneakySpeed + .2f;

            Vector3 ratPos = other.transform.position - transform.position;
            ratPos.y += .4f;
            Vector2 forward = new Vector2(ai.transform.forward.normalized.x, ai.transform.forward.normalized.z);
            Vector2 ratPosNorm = new Vector2(ratPos.normalized.x, ratPos.normalized.z);
            float dot = Vector2.Dot(forward, ratPosNorm);
            float ang = Mathf.Acos(dot) * Mathf.Rad2Deg;

            detect.seeing = !Physics.Raycast(transform.position, ratPos, ratPos.magnitude, ~_playerMask)
                            && ang < ai.enemyFOV / 2f;
            
            if (detect.seeing || detect.hearing)
            {
                playerCtrl.detectionHUD.AddArrow(detect);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            detect.hearing = false;
            detect.seeing = false;
        }
    }

    private void Update()
    {
        HideSoundSphere();
    }

    private void HideSoundSphere()
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

        _sphereCol.radius = ai.detectionRadius;
        transform.position = ai.transform.position;
    }

    private void Awake()
    {
        _sphereCol = GetComponent<SphereCollider>();
        _playerMask = LayerMask.GetMask("Player");
    }
}