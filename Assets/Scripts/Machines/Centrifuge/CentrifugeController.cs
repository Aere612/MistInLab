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
        var vialOne = _inputOne.CurrentObject; 
        var vialTwo = _inputTwo.CurrentObject;
        var vialOutput = _output.CurrentObject;
        
        if (vialOne == null || vialTwo == null || vialOutput == null)
        {
            _centrifuge.isCountdownStarted = false;
            return;
        }

        if (!_centrifuge.isCountdownStarted ||vialOne.baseIngradiant == Ingradiant.Empty ||
            vialTwo.baseIngradiant == Ingradiant.Empty ||
            vialOutput.baseIngradiant != Ingradiant.Empty)
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
        var vialOne = _inputOne.CurrentObject; 
        var vialTwo = _inputTwo.CurrentObject;
        var vialOutput = _output.CurrentObject;
        
        vialOutput.baseIngradiant =
            _centrifuge.RunTheMachine(vialOne.baseIngradiant, vialTwo.baseIngradiant);
        vialOutput.sideIngradiant = Ingradiant.Empty;
    }
}