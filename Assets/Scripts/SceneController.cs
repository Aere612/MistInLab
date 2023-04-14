using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    [ContextMenu("EndGame")]
    private void EndTheGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
}
