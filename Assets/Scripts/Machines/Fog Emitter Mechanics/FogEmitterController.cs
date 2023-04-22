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

    private void RunTheFogEmitter()
    {
        if (_vialSlot.CurrentObject == null) return;
        if (_vialSlot.CurrentObject.BaseIngradiant != _ingradientTypes.Green) return;
        if (!_slider.isCorrect || !_lever.isCorrect) return;
        
        if (_switchOne.switchState != FogEmitterSwitch.SwitchState.Down ||
            _switchTwo.switchState != FogEmitterSwitch.SwitchState.Up ||
            _switchThree.switchState != FogEmitterSwitch.SwitchState.Up ||
            _switchFour.switchState != FogEmitterSwitch.SwitchState.Down) return;
        
        if (_cogSlotOne.CurrentObject == null || _cogSlotTwo.CurrentObject == null ||
            _cogSlotThree.CurrentObject == null) return;

        Debug.Log("Fog Successful");
    }
}