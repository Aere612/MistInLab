using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerController : MonoBehaviour
{
    [SerializeField] private Mixer _mixer;

    [SerializeField] private VialSlot _inputOne;
    [SerializeField] private VialSlot _inputTwo;
    [SerializeField] private VialSlot _output;

    private void Awake()
    {
        _mixer.isCountdownStarted = false;
    }

    public void CheckCountdown()
    {
        var vialOne = _inputOne.CurrentObject; 
        var vialTwo = _inputTwo.CurrentObject;
        var vialOutput = _output.CurrentObject;
        
        if (vialOne == null || vialTwo == null || vialOutput == null)
        {
            _mixer.isCountdownStarted = false;
            return;
        }

        if (!_mixer.isCountdownStarted ||vialOne.baseIngradiant == Ingradiant.Empty ||
            vialTwo.baseIngradiant == Ingradiant.Empty ||
            vialOutput.baseIngradiant != Ingradiant.Empty)
            return;

        if (_mixer.currentCountdown > 0)
            _mixer.currentCountdown--;
        else
        {
            RunTheCentrifuge();
            _mixer.isCountdownStarted = false;
        }
    }

    private void RunTheCentrifuge()
    {
        var vialOne = _inputOne.CurrentObject; 
        var vialTwo = _inputTwo.CurrentObject;
        var vialOutput = _output.CurrentObject;
        
        vialOutput.baseIngradiant =
            _mixer.RunTheMachine(vialOne.baseIngradiant, vialTwo.baseIngradiant);
        
        vialOutput.sideIngradiant = Ingradiant.Empty;
        vialOne.baseIngradiant = Ingradiant.Empty;
        vialTwo.baseIngradiant = Ingradiant.Empty;
    }
}