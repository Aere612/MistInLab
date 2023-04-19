using UnityEngine;

[CreateAssetMenu(fileName = "Shaker", menuName = "Machines/Shaker")]
public class Shaker : BaseMachine
{
    [SerializeField] internal bool isCorrect;
    [SerializeField] internal int correctCountdown;

    internal VialSlot input;

    public override void CheckTheConditionsAndRun()
    {
        if (input.CurrentObject.baseIngradiant == Ingradiant.Empty ||
            input.CurrentObject.sideIngradiant == Ingradiant.Empty) 
            return;
        isCorrect = choosenCountdown == correctCountdown;
        RunTheMachine();    
    }

    public override void MixTheIngradients()
    {
        if (((input.CurrentObject.baseIngradiant == Ingradiant.Blue &&
              input.CurrentObject.sideIngradiant == Ingradiant.Orange) ||
             (input.CurrentObject.baseIngradiant == Ingradiant.Orange &&
              input.CurrentObject.sideIngradiant == Ingradiant.Blue)) && isCorrect)
            input.CurrentObject.baseIngradiant = Ingradiant.LightBlue;

        else if (((input.CurrentObject.baseIngradiant == Ingradiant.Red &&
                   input.CurrentObject.sideIngradiant == Ingradiant.Purple) ||
                  (input.CurrentObject.baseIngradiant == Ingradiant.Purple &&
                   input.CurrentObject.sideIngradiant == Ingradiant.Red)) && isCorrect)
            input.CurrentObject.baseIngradiant = Ingradiant.BoldYellow;

        else
            input.CurrentObject.baseIngradiant = (Ingradiant)Random.Range(1, 6);
        input.CurrentObject.sideIngradiant = Ingradiant.Empty;
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