using UnityEngine;

[CreateAssetMenu(fileName = "Mixer", menuName = "Machines/Mixer")]
public class Mixer : BaseMachine
{
    internal VialSlot inputOne;
    internal VialSlot inputTwo;
    internal VialSlot output;

    public override void CheckTheConditionsAndRun()
    {
        if (inputOne == null || inputTwo == null || output == null)
            return;

        if (inputOne.CurrentObject.baseIngradiant == _ingradientTypes.Empty ||
            inputTwo.CurrentObject.baseIngradiant == _ingradientTypes.Empty ||
            output.CurrentObject.baseIngradiant != _ingradientTypes.Empty)
            return;
        RunTheMachine();
    }

    public override void MixTheIngradients()
    {
        if ((inputOne.CurrentObject.baseIngradiant== _ingradientTypes.LightBlue
             && inputTwo.CurrentObject.baseIngradiant == _ingradientTypes.BoldYellow)
            ||
            (inputOne.CurrentObject.baseIngradiant == _ingradientTypes.BoldYellow
             && inputTwo.CurrentObject.baseIngradiant == _ingradientTypes.LightBlue))
        {
            output.CurrentObject.baseIngradiant= _ingradientTypes.Green;
        }
        else
        {
            output.CurrentObject.baseIngradiant = _ingradientTypes.Empty;
        }

        inputOne.CurrentObject.baseIngradiant = _ingradientTypes.Empty;
        inputTwo.CurrentObject.baseIngradiant = _ingradientTypes.Empty;
    }

    public override void RunTheMachine()
    {
        isCountdownStarted = true;
        OnMachineStarted.Raise();
    }

    public override void StopTheMachine()
    {
        isCountdownStarted = false;
        OnMachineStopped.Raise();
    }
}