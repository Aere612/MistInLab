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
        if (_cogSlotOne.CurrentObject == null || _cogSlotTwo.CurrentObject == null ||
            _cogSlotThree.CurrentObject == null) return;

        RunTheMachine();
    }

    public override void MixTheIngredients()
    {
        if (_vialSlot.CurrentObject == null) return;
        if (_vialSlot.CurrentObject.BaseIngradiant != _ingradientTypes.Green) return;
        if (_switchOne.switchState != FogEmitterSwitch.SwitchState.Down ||
            _switchTwo.switchState != FogEmitterSwitch.SwitchState.Up ||
            _switchThree.switchState != FogEmitterSwitch.SwitchState.Up ||
            _switchFour.switchState != FogEmitterSwitch.SwitchState.Down||
            !_slider.isCorrect || 
            !_lever.isCorrect) return;

        OnMachineStopped.Raise();
    }

    public override void RunTheMachine()
    {
        isCountdownStarted = true;
        _cogSlotOne.CurrentObject.IsAvailableToCollect = false;
        _cogSlotTwo.CurrentObject.IsAvailableToCollect = false;
        _cogSlotThree.CurrentObject.IsAvailableToCollect = false;
        _vialSlot.CurrentObject.IsAvailableToCollect = false;

        OnMachineStarted.Raise();
    }

    public override void StopTheMachine()
    {
        isCountdownStarted = false;
        _cogSlotOne.CurrentObject.IsAvailableToCollect = true;
        _cogSlotTwo.CurrentObject.IsAvailableToCollect = true;
        _cogSlotThree.CurrentObject.IsAvailableToCollect = true;
        _vialSlot.CurrentObject.IsAvailableToCollect = true;
    }
}