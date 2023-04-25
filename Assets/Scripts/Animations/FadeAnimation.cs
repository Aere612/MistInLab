using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FadeAnimation : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        StartCoroutine(DoAnim());
    }

    private IEnumerator DoAnim()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.3f);
        image.DOFade(0f, 1f).OnComplete(()=>Destroy(gameObject));
    }
}
