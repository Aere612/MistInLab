using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogEmitterController : MonoBehaviour
{
    [SerializeField] private FogEmitter _fogEmitter;
    [SerializeField] private FogEmitterRightSideSlider _slider;
    [SerializeField] private FogEmitterRightSideLever _lever;

    [SerializeField] private FogEmitterRightSideSwitch _switchOne;
    [SerializeField] private FogEmitterRightSideSwitch _switchTwo;
    [SerializeField] private FogEmitterRightSideSwitch _switchThree;
    [SerializeField] private FogEmitterRightSideSwitch _switchFour;

    [SerializeField] private CogSlot _cogSlot;

    public void CheckCountdown()
    {
        if (!_fogEmitter.isCountdownStarted) return;

        if (_fogEmitter.currentCountdown > 0)
            _fogEmitter.currentCountdown--;
        else
        {
            RunTheFogEmitter();
            _fogEmitter.isCountdownStarted = false;
        }
    }
    public void RunTheFogEmitter()
    {
        if (!_slider.isCorrect || !_lever.isCorrect) return;
        if (_switchOne.switchState != FogEmitterRightSideSwitch.SwitchState.Down ||
            _switchTwo.switchState != FogEmitterRightSideSwitch.SwitchState.Up ||
            _switchThree.switchState != FogEmitterRightSideSwitch.SwitchState.Up ||
            _switchFour.switchState != FogEmitterRightSideSwitch.SwitchState.Down) return;
        
        Debug.Log("Fog Successful");

    }

}