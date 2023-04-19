using DG.Tweening;
using TMPro;
using UnityEngine;

public class MixerAnimation : MonoBehaviour
{
    [SerializeField] private Mixer _mixer;
    [SerializeField] private GameObject kapak;
    [SerializeField] private GameObject innerObjects;
    [SerializeField] private TMP_Text countdownText;

    private Tweener _tween;
    public void RunAnimation()
    {
        
        kapak.transform.DOLocalMoveY(1, 1).SetEase(Ease.Linear).OnComplete(() =>
        {
        _tween = innerObjects.transform.DORotate(new Vector3(0, 360, 0), 2,RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart).SetRelative();
            
        });
    }
    public void KillAnimation()
    {
        _tween.SetLoops(0);
        _tween.Complete();
        _tween.Kill();
        kapak.transform.DOLocalMoveY(-1, 1).SetEase(Ease.Linear);
    }

    public void UpdateCountdownText()
    {
        countdownText.text = "00:" + _mixer.currentCountdown.ToString("00");
    }
}
