using System;
using UnityEngine;

public class ShakerController : MonoBehaviour
{
    [SerializeField] private Shaker _shaker;
    [SerializeField] private VialSlot _slot;

    private void Awake()
    {
        _shaker.isCountdownStarted = false;
    }

    public void CheckCountdown()
    {
        var currentVial = _slot.CurrentObject;
        if (currentVial == null)
        {
            _shaker.isCountdownStarted = false;
            return;
        }

        if (!_shaker.isCountdownStarted ||currentVial.baseIngradiant == Ingradiant.Empty ||
            currentVial.sideIngradiant == Ingradiant.Empty) return;

        _shaker.isCorrect = _shaker.choosenCountdown == _shaker.correctCountdown;
        
        if (_shaker.currentCountdown > 0)
            _shaker.currentCountdown--;
        else
        {
            RunTheMixer();
            _shaker.isCountdownStarted = false;
        }
    }

    private void RunTheMixer()
    {
        var currentVial = _slot.CurrentObject;
        
        currentVial.baseIngradiant =
            _shaker.MixTheIngradients(currentVial.baseIngradiant, currentVial.sideIngradiant);
        currentVial.sideIngradiant = Ingradiant.Empty;
    }
}