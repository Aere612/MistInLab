using System;
using UnityEngine;

public class FogEmitterController : MonoBehaviour
{
    [SerializeField] private IngradientTypes _ingradientTypes;

    [SerializeField] private FogEmitter _fogEmitter;
    [SerializeField] private FogEmitterSlider _slider;
    [SerializeField] private FogEmitterLever _lever;

    [SerializeField] private FogEmitterSwitch _switchOne;
    [SerializeField] private FogEmitterSwitch _switchTwo;
    [SerializeField] private FogEmitterSwitch _switchThree;
    [SerializeField] private FogEmitterSwitch _switchFour;

    [SerializeField] private CogSlot _cogSlotOne;
    [SerializeField] private CogSlot _cogSlotTwo;
    [SerializeField] private CogSlot _cogSlotThree;

    [SerializeField] private VialSlot _vialSlot;
    

    private void Awake()
    {
        InitializeFogEmitter();
    }

    public void CheckCountdown()
    {
        if (!_fogEmitter.isCountdownStarted) return;

        if (_fogEmitter.currentCountdown > 0)
            _fogEmitter.currentCountdown--;
        else
        {
            _fogEmitter.MixTheIngredients();
            _fogEmitter.StopTheMachine();
            _fogEmitter.isCountdownStarted = false;
        }
    }


    private void InitializeFogEmitter()
    {
        _fogEmitter.isCountdownStarted = false;
        
        _fogEmitter._cogSlotOne = _cogSlotOne;
        _fogEmitter._cogSlotTwo = _cogSlotTwo;
        _fogEmitter._cogSlotThree = _cogSlotThree;
        _fogEmitter._switchOne = _switchOne;
        _fogEmitter._switchTwo = _switchTwo;
        _fogEmitter._switchThree = _switchThree;
        _fogEmitter._switchFour = _switchFour;
        _fogEmitter._slider = _slider;
        _fogEmitter._lever = _lever;
        _fogEmitter._vialSlot = _vialSlot;
        
    }
}