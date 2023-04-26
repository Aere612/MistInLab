using UnityEngine;

[CreateAssetMenu(fileName = "Shaker", menuName = "Machines/Shaker")]
public class Shaker : BaseMachine
{
    [SerializeField] internal bool isCorrect;
    [SerializeField] internal int correctCountdown;

    internal VialSlot input;

    public override void CheckTheConditionsAndRun()
    {
        if (input.CurrentObject.BaseIngradiant == _ingradientTypes.Empty ||
            input.CurrentObject.SideIngradiant == _ingradientTypes.Empty) 
            return;
        isCorrect = choosenCountdown == correctCountdown;
        RunTheMachine();    
    }

    public override void MixTheIngredients()
    {
        if (input.CurrentObject == null) return;
        if (((input.CurrentObject.BaseIngradiant == _ingradientTypes.Blue &&
              input.CurrentObject.SideIngradiant == _ingradientTypes.Orange) ||
             (input.CurrentObject.BaseIngradiant == _ingradientTypes.Orange &&
              input.CurrentObject.SideIngradiant == _ingradientTypes.Blue)) && isCorrect)
            input.CurrentObject.BaseIngradiant = _ingradientTypes.LightBlue;

        else if (((input.CurrentObject.BaseIngradiant == _ingradientTypes.Yellow &&
                   input.CurrentObject.SideIngradiant == _ingradientTypes.Red) ||
                  (input.CurrentObject.BaseIngradiant == _ingradientTypes.Red &&
                   input.CurrentObject.SideIngradiant == _ingradientTypes.Yellow)) && isCorrect)
            input.CurrentObject.BaseIngradiant = _ingradientTypes.BoldYellow;

        else
            input.CurrentObject.BaseIngradiant = _ingradientTypes.Black;
        
        input.CurrentObject.SideIngradiant = _ingradientTypes.Empty;
    }

    public override void RunTheMachine()
    {
        isCountdownStarted = true;
        input.CurrentObject.IsAvailableToCollect = false;
        OnMachineStarted.Raise();
    }

    public override void StopTheMachine()
    {
        isCountdownStarted = false;
        input.CurrentObject.IsAvailableToCollect = true;
        OnMachineStopped.Raise();
    }
}