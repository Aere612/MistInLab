using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CogAnimation : MonoBehaviour
{
    [SerializeField] internal bool turnRight;
    private Tweener _tween;

    public void PlayAnimation()
    {
        var angle = turnRight ? 360 : -360;
        _tween = transform.DORotate(new Vector3(0, 0, angle), 2,RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart).SetRelative();
    }

    public void StopAnimation()
    {
        _tween.SetLoops(0);
        _tween.Complete();
        _tween.Kill();
    }
}
