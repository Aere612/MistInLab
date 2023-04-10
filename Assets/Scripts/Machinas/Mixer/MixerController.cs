using System;
using UnityEngine;

public class MixerController : MonoBehaviour
{
    [SerializeField] private Mixer _mixer;
    [SerializeField] private VialSlot _slot;

    private void Awake()
    {
        _mixer.isCountdownStarted = false;
    }

    public void CheckCountdown()
    {
        var currentVial = _slot.CurrentObject;
        if (currentVial == null)
        {
            _mixer.isCountdownStarted = false;
            return;
        }

        if (!_mixer.isCountdownStarted ||currentVial.baseIngradiant == Ingradiant.Empty ||
            currentVial.sideIngradiant == Ingradiant.Empty) return;

        if (_mixer.currentCountdown > 0)
            _mixer.currentCountdown--;
        else
        {
            RunTheMixer();
            _mixer.isCountdownStarted = false;
        }
    }

    private void RunTheMixer()
    {
        var currentVial = _slot.CurrentObject;
        
        currentVial.baseIngradiant =
            _mixer.RunTheMachine(currentVial.baseIngradiant, currentVial.sideIngradiant);
        currentVial.sideIngradiant = Ingradiant.Empty;
    }
}