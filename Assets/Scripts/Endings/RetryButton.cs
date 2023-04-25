using UnityEngine.SceneManagement;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
