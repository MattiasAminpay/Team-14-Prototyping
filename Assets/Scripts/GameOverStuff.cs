using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverStuff : MonoBehaviour
{
    [SerializeField] private string sceneToRetry = "AITestingScene";

    public void Retry()
    {
        SceneManager.LoadScene(sceneToRetry);
    }

    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
