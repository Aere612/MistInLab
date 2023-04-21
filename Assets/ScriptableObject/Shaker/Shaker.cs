using UnityEngine;

[CreateAssetMenu(fileName = "Shaker", menuName = "Machines/Shaker")]
public class Shaker : BaseMachine
{
    [SerializeField] internal bool isCorrect;
    [SerializeField] internal int correctCountdown;

    internal VialSlot input;

    public override void CheckTheConditionsAndRun()
    {
        if (input.CurrentObject.baseIngradiant == _ingradientTypes.Empty ||
            input.CurrentObject.sideIngradiant == _ingradientTypes.Empty) 
            return;
        isCorrect = choosenCountdown == correctCountdown;
        RunTheMachine();    
    }

    public override void MixTheIngradients()
    {
        if (((input.CurrentObject.baseIngradiant == _ingradientTypes.Blue &&
              input.CurrentObject.sideIngradiant == _ingradientTypes.Orange) ||
             (input.CurrentObject.baseIngradiant == _ingradientTypes.Orange &&
              input.CurrentObject.sideIngradiant == _ingradientTypes.Blue)) && isCorrect)
            input.CurrentObject.baseIngradiant = _ingradientTypes.LightBlue;

        else if (((input.CurrentObject.baseIngradiant == _ingradientTypes.Red &&
                   input.CurrentObject.sideIngradiant == _ingradientTypes.Purple) ||
                  (input.CurrentObject.baseIngradiant == _ingradientTypes.Purple &&
                   input.CurrentObject.sideIngradiant == _ingradientTypes.Red)) && isCorrect)
            input.CurrentObject.baseIngradiant = _ingradientTypes.BoldYellow;

        else
            input.CurrentObject.baseIngradiant = _ingradientTypes.Black;
        
        input.CurrentObject.sideIngradiant = _ingradientTypes.Empty;
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