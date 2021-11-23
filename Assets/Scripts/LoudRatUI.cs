using StarterAssets;
using UnityEngine;

public class LoudRatUI : MonoBehaviour
{
    [SerializeField] private GameObject wifi;
    private ThirdPersonController _ctrl;

    private void Update()
    {
        wifi.SetActive(_ctrl._speed > _ctrl.SprintSpeed);
    }

    private void Awake()
    {
        _ctrl = transform.root.GetComponent<ThirdPersonController>();
    }
}
