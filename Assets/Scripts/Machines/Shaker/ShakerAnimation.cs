using DG.Tweening;
using TMPro;
using UnityEngine;

public class ShakerAnimation : MonoBehaviour
{
    [SerializeField] private Shaker _shaker;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject objectsToAnimate;

    private Tweener _tween;
    public void RunAnimation()
    {
        _tween = objectsToAnimate.transform.DOLocalMoveY(0.2f, 0.1f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo)
            .SetRelative();
    }

    public void KillAnimation()
    {
        _tween.SetLoops(0);
        _tween.Complete();
        _tween.Kill();
    }

    public void UpdateCountdownText()
    {
        countdownText.text = "00:" + _shaker.currentCountdown.ToString("00");
    }
}