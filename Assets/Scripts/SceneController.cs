using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Counter counter;
    [SerializeField] private InputController inputController;
    [SerializeField] private GameObject _monsterSpawner;

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
        _monsterSpawner.SetActive(false);
        inputController.CancelListening();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        counter.enabled = false;
    }
}