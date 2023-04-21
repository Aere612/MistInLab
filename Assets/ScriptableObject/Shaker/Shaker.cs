using UnityEngine;

[CreateAssetMenu(fileName = "Shaker", menuName = "Machines/Shaker")]
public class Shaker : BaseMachine
{
    [SerializeField] internal bool isCorrect;
    [SerializeField] internal int correctCountdown;

    internal VialSlot input;

    public override void CheckTheConditionsAndRun()
    {
        if (input.CurrentObject.baseIngradiant.Type == Ingradient.Empty ||
            input.CurrentObject.sideIngradiant.Type == Ingradient.Empty) 
            return;
        isCorrect = choosenCountdown == correctCountdown;
        RunTheMachine();    
    }

    public override void MixTheIngradients()
    {
        if (((input.CurrentObject.baseIngradiant.Type == Ingradient.Blue &&
              input.CurrentObject.sideIngradiant.Type == Ingradient.Orange) ||
             (input.CurrentObject.baseIngradiant.Type == Ingradient.Orange &&
              input.CurrentObject.sideIngradiant.Type == Ingradient.Blue)) && isCorrect)
            input.CurrentObject.baseIngradiant.Type = Ingradient.LightBlue;

        else if (((input.CurrentObject.baseIngradiant.Type == Ingradient.Red &&
                   input.CurrentObject.sideIngradiant.Type == Ingradient.Purple) ||
                  (input.CurrentObject.baseIngradiant.Type == Ingradient.Purple &&
                   input.CurrentObject.sideIngradiant.Type == Ingradient.Red)) && isCorrect)
            input.CurrentObject.baseIngradiant.Type = Ingradient.BoldYellow;

        else
            input.CurrentObject.baseIngradiant.Type = (Ingradient)Random.Range(1, 6);
        input.CurrentObject.sideIngradiant.Type = Ingradient.Empty;
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