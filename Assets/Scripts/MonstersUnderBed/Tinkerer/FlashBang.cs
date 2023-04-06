using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

public class FlashBang : MonoBehaviour, IInteractable
{
    [SerializeField] private Tinkerer tinkerer;
    [SerializeField] private int currentCd;
    [SerializeField] private int maxCd = 180;
    [SerializeField] private GameEventListener onTimeClickEventListener;
    [SerializeField] private Light flashBangLight;

    public void Interaction()
    {
        if (currentCd != 0) return;
        var  flashBangSequence = DOTween.Sequence();
        flashBangSequence.Append(flashBangLight.DOIntensity(20f, 0.05f));
        flashBangSequence.Append(flashBangLight.DOIntensity(20f, 0.5f));
        flashBangSequence.Append(flashBangLight.DOIntensity(0f, 2f));
        currentCd = maxCd;
        onTimeClickEventListener.enabled = true;
        tinkerer.FlashBanged();
    }

    public void ReduceCd()
    {
        currentCd--;
        if (currentCd == 0) onTimeClickEventListener.enabled = false;
    }
}