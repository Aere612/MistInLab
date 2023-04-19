using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamitmaAnimation : MonoBehaviour
{
    [SerializeField] private Damitma _damitma;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject  objectsToAnimate;

    private Tweener _tween;
    
    public void RunAnimation()
    {
        objectsToAnimate.SetActive(true);
        _tween = objectsToAnimate.transform.DOLocalMoveY(-1f, 0.9f)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear)
            .SetRelative();
    }
    public void KillAnimation()
    {
        _tween.SetLoops(0);
        _tween.Complete();
        _tween.Kill();
        objectsToAnimate.SetActive(false);
    }

    public void UpdateCountdownText()
    {
        countdownText.text = "00:" + _damitma.currentCountdown.ToString("00");
    }
}
