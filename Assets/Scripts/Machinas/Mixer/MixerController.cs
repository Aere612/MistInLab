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
        if (_slot.currentVial == null)
        {
            return;
        }

        if (!_mixer.isCountdownStarted || _slot.currentVial.baseIngradiant == Ingradiant.Empty ||
            _slot.currentVial.sideIngradiant == Ingradiant.Empty) return;

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
        _slot.currentVial.baseIngradiant =
            _mixer.RunTheMachine(_slot.currentVial.baseIngradiant, _slot.currentVial.sideIngradiant);
        _slot.currentVial.sideIngradiant = Ingradiant.Empty;
    }
}