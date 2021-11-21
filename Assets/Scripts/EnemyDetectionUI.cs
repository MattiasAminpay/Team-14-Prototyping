using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDetectionUI : MonoBehaviour
{
    [HideInInspector] public bool seeing;
    [HideInInspector] public bool hearing;
    [HideInInspector] public Vector2 size;

    [SerializeField] private RectTransform detectionBar;

    private EnemyAI ai;

    private void Start()
    {
        size = detectionBar.localScale;
    }

    private void Awake()
    {
        ai = GetComponentInParent<EnemyAI>();
    }

    private void Update()
    {
        Detect();
        Billboard();
    }

    private void Detect()
    {
        if (hearing)
        {
            size.x += Time.deltaTime / ai.detectionTime;
        }

        if (seeing)
        {
            size.x += Time.deltaTime / ai.detectionTime;
        }

        if (!hearing && !seeing)
        {
            size.x -= Time.deltaTime / ai.detectionTime;
        }

        if (size.x > 1f && ai.canKill)
        {
            SceneManager.LoadScene("GameOver");
            return;
        }
        float sizeX = Mathf.Clamp(size.x, 0f, 1f);
        size.x = sizeX;
        detectionBar.localScale = size;
    }

    private void Billboard()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}