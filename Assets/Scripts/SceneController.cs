using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
    }

    [ContextMenu("WinGame")]
    public void EndTheGame()
    {
        SceneManager.LoadScene("EndingScene", LoadSceneMode.Additive);
    }
    [ContextMenu("LoseGame")]
    public void LoseTheGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
