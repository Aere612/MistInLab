using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}
