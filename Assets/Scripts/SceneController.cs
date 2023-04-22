using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
    }

    [ContextMenu("EndGame")]
    private void EndTheGame()
    {
        SceneManager.LoadScene("EndingScene", LoadSceneMode.Additive);
    }
}
