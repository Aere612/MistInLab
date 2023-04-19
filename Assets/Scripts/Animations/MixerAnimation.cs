using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

public class MixerAnimation : MonoBehaviour
{
    [SerializeField] private Mixer _mixer;
    [SerializeField] private GameObject kapak;
    [SerializeField] private GameObject innerObjects;
    private Sequence _sequence;

    internal void RunAnimation()
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(kapak.transform.DOLocalMoveY(1, 1).SetEase(Ease.Linear));
        _sequence.Append(innerObjects.transform.DORotate(new Vector3(0, 360, 0), 2,RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart).SetRelative());
    }

    internal void KillAnimation()
    {
        DOTween.Kill(innerObjects.transform);
        kapak.transform.DOLocalMoveY(-1, 1).SetEase(Ease.Linear);
    }
}
