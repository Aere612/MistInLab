using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrifugeController : MonoBehaviour
{
    [SerializeField] private Centrifuge _centrifuge;

    [SerializeField] private VialSlot _inputOne;
    [SerializeField] private VialSlot _inputTwo;
    [SerializeField] private VialSlot _output;

    private void Awake()
    {
        _centrifuge.isCountdownStarted = false;
    }

    public void CheckCountdown()
    {
        if (_inputOne.currentVial == null || _inputTwo.currentVial == null || _output.currentVial == null)
        {
            return;
        }

        if (!_centrifuge.isCountdownStarted || _inputOne.currentVial.baseIngradiant == Ingradiant.Empty ||
            _inputTwo.currentVial.baseIngradiant == Ingradiant.Empty ||
            _output.currentVial.baseIngradiant != Ingradiant.Empty)
            return;

        if (_centrifuge.currentCountdown > 0)
            _centrifuge.currentCountdown--;
        else
        {
            RunTheCentrifuge();
            _centrifuge.isCountdownStarted = false;
        }
    }

    private void RunTheCentrifuge()
    {
        _output.currentVial.baseIngradiant =
            _centrifuge.RunTheMachine(_inputOne.currentVial.baseIngradiant, _inputTwo.currentVial.baseIngradiant);
        _output.currentVial.sideIngradiant = Ingradiant.Empty;
    }
}