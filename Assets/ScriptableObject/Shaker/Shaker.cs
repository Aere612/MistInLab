using UnityEngine;

[CreateAssetMenu(fileName = "Shaker", menuName = "Machines/Shaker")]
public class Shaker : BaseMachine
{
    [SerializeField] internal bool isCorrect;
    [SerializeField] internal int correctCountdown;

    internal VialSlot input;

    public override void CheckTheConditionsAndRun()
    {
        if (input.CurrentObject.BaseIngradiant == Ingradiant.Empty ||
            input.CurrentObject.SideIngradiant == Ingradiant.Empty) 
            return;
        isCorrect = choosenCountdown == correctCountdown;
        RunTheMachine();    
    }

    public override void MixTheIngradients()
    {
        if (((input.CurrentObject.BaseIngradiant == Ingradiant.Blue &&
              input.CurrentObject.SideIngradiant == Ingradiant.Orange) ||
             (input.CurrentObject.BaseIngradiant == Ingradiant.Orange &&
              input.CurrentObject.SideIngradiant == Ingradiant.Blue)) && isCorrect)
            input.CurrentObject.BaseIngradiant = Ingradiant.LightBlue;

        else if (((input.CurrentObject.BaseIngradiant == Ingradiant.Red &&
                   input.CurrentObject.SideIngradiant == Ingradiant.Purple) ||
                  (input.CurrentObject.BaseIngradiant == Ingradiant.Purple &&
                   input.CurrentObject.SideIngradiant == Ingradiant.Red)) && isCorrect)
            input.CurrentObject.BaseIngradiant = Ingradiant.BoldYellow;

        else
            input.CurrentObject.BaseIngradiant = (Ingradiant)Random.Range(1, 6);
        input.CurrentObject.SideIngradiant = Ingradiant.Empty;
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