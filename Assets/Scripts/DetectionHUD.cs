using System.Collections.Generic;
using UnityEngine;

public class DetectionHUD : MonoBehaviour
{
    [HideInInspector] public List<EnemyDetectionUI> addedArrows = new List<EnemyDetectionUI>();

    [SerializeField] private GameObject arrowPrefab;

    public void AddArrow(EnemyDetectionUI detectionUI)
    {
        if (addedArrows.Contains(detectionUI)) return;
        addedArrows.Add(detectionUI);

        SpawnArrow();
        
        void SpawnArrow()
        {
            Instantiate(arrowPrefab, transform).GetComponent<DetectionArrowUI>().enemyDetection = detectionUI;
        }
    }

    
}
