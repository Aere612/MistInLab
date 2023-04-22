using UnityEngine;

[CreateAssetMenu(fileName = "FogEmitter", menuName = "Machines/FogEmitter")]
public class FogEmitter : BaseMachine
{
    internal CogSlot _cogSlotOne;
    internal CogSlot _cogSlotTwo;
    internal CogSlot _cogSlotThree;

    internal FogEmitterSwitch _switchOne;
    internal FogEmitterSwitch _switchTwo;
    internal FogEmitterSwitch _switchThree;
    internal FogEmitterSwitch _switchFour;

    internal FogEmitterSlider _slider;
    internal FogEmitterLever _lever;

    internal VialSlot _vialSlot;

    public override void CheckTheConditionsAndRun()
    {
        if (_vialSlot.CurrentObject == null) return;
        if (_vialSlot.CurrentObject.BaseIngradiant != _ingradientTypes.Green) return;
        if (!_slider.isCorrect || !_lever.isCorrect) return;

        RunTheMachine();
    }

    public override void MixTheIngradients()
    {
        if (_switchOne.switchState != FogEmitterSwitch.SwitchState.Down ||
            _switchTwo.switchState != FogEmitterSwitch.SwitchState.Up ||
            _switchThree.switchState != FogEmitterSwitch.SwitchState.Up ||
            _switchFour.switchState != FogEmitterSwitch.SwitchState.Down) return;

        if (_cogSlotOne.CurrentObject == null || _cogSlotTwo.CurrentObject == null ||
            _cogSlotThree.CurrentObject == null) return;
        OnMachineStopped.Raise();
    }

    public override void RunTheMachine()
    {
        isCountdownStarted = true;
        OnMachineStarted.Raise();
    }

    public override void StopTheMachine()
    {
        isCountdownStarted = false;
    }
}