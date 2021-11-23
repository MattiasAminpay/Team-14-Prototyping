using UnityEngine;
using UnityEngine.UI;

public class DetectionArrowUI : MonoBehaviour
{
    [SerializeField] private Image arrowToFill;

    [HideInInspector] public EnemyDetectionUI enemyDetection;

    private Transform camera;

    private DetectionHUD detectionHUD;
    private float spawnTime;

    private void Update()
    {
        arrowToFill.fillAmount = enemyDetection.size.x;
        
        Rotate();
    }

    private void Rotate()
    {
        Vector2 enemyPos = new Vector2(enemyDetection.transform.position.x, enemyDetection.transform.position.z);
        Vector2 cameraPos = new Vector2(camera.position.x, camera.position.z);
        Vector2 relative = (enemyPos - cameraPos).normalized;
        float andToEnemyDeg = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0,
            (camera.transform.rotation.eulerAngles.y + andToEnemyDeg) - 90);

        if (enemyDetection.size.x < .01f && spawnTime + .25f < Time.time) //todo fade out instead of checking spawn time
        {
            detectionHUD.addedArrows.Remove(enemyDetection);
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        detectionHUD = GetComponentInParent<DetectionHUD>();
        camera = Camera.main.transform;
        spawnTime = Time.time;
    }
}