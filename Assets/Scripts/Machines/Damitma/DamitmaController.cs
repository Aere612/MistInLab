using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamitmaController : MonoBehaviour
{
    [SerializeField] private Damitma _damitma;
    [SerializeField] private VialSlot _input;
    [SerializeField] private VialSlot _output;
    
    private void Awake()
    {
        _damitma.isCountdownStarted = false;
    }

    public void CheckCountdown()
    {
        var currentInput = _input.CurrentObject;
        var currentOutput = _output.CurrentObject;
        if (currentInput == null || currentOutput == null)
        {
            _damitma.isCountdownStarted = false;
            return;
        }

        if (!_damitma.isCountdownStarted ||currentInput.baseIngradiant == Ingradiant.Empty ||
            currentOutput.baseIngradiant != Ingradiant.Empty) return;

        if (_damitma.currentCountdown > 0)
            _damitma.currentCountdown--;
        else
        {
            RunTheDamitma();
            _damitma.isCountdownStarted = false;
        }
    }

    private void RunTheDamitma()
    {
        var currentVial = _input.CurrentObject;
        var currentOutput = _output.CurrentObject;
        currentOutput.baseIngradiant =
            _damitma.RunTheMachine(currentVial.baseIngradiant, currentVial.sideIngradiant);
        currentOutput.sideIngradiant = Ingradiant.Empty;
    }
}