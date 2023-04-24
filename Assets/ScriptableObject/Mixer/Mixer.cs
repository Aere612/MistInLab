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

        if (inputOne.CurrentObject.BaseIngradiant == _ingradientTypes.Empty ||
            inputTwo.CurrentObject.BaseIngradiant == _ingradientTypes.Empty ||
            output.CurrentObject.BaseIngradiant != _ingradientTypes.Empty)
            return;
        RunTheMachine();
    }

    public override void MixTheIngredients()
    {
        if ((inputOne.CurrentObject.BaseIngradiant== _ingradientTypes.LightBlue
             && inputTwo.CurrentObject.BaseIngradiant == _ingradientTypes.BoldYellow)
            ||
            (inputOne.CurrentObject.BaseIngradiant == _ingradientTypes.BoldYellow
             && inputTwo.CurrentObject.BaseIngradiant == _ingradientTypes.LightBlue))
        {
            output.CurrentObject.BaseIngradiant= _ingradientTypes.Green;
        }
        else
        {
            output.CurrentObject.BaseIngradiant = _ingradientTypes.Empty;
        }
        
        inputOne.CurrentObject.BaseIngradiant = _ingradientTypes.Empty;
        inputTwo.CurrentObject.BaseIngradiant = _ingradientTypes.Empty;
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