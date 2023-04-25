using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Counter counter;
    [SerializeField] private InputController inputController;

    private void Start()
    {
        SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
    }

    [ContextMenu("WinGame")]
    public void EndTheGame()
    {
        EndScene();
        SceneManager.LoadScene("EndingScene", LoadSceneMode.Additive);
    }

    [ContextMenu("LoseGame")]
    public void LoseTheGame()
    {
        EndScene();
        SceneManager.LoadScene("LoseScene");
    }

    private void EndScene()
    {
        inputController.CancelListening();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        counter.enabled = false;
    }
}