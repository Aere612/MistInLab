using UnityEngine;

[CreateAssetMenu(fileName = "Shaker", menuName = "Machines/Shaker")]
public class Shaker : BaseMachine
{
    [SerializeField] internal bool isCorrect;
    [SerializeField] internal int correctCountdown;
    public Ingradiant MixTheIngradients(Ingradiant baseIngradiant, Ingradiant sideIngradiant)
    {
        Ingradiant result;

        if (((baseIngradiant == Ingradiant.Blue && sideIngradiant == Ingradiant.Orange) ||
             (baseIngradiant == Ingradiant.Orange && sideIngradiant == Ingradiant.Blue)) && isCorrect)
            result = Ingradiant.LightBlue;
        
        else if (((baseIngradiant == Ingradiant.Red && sideIngradiant == Ingradiant.Purple) ||
                  (baseIngradiant == Ingradiant.Purple && sideIngradiant == Ingradiant.Red)) && isCorrect)
            result = Ingradiant.BoldYellow;
        
        else
            result = (Ingradiant)Random.Range(1, 6);

        return result;
    }

    public override void CheckTheConditionsAndRun()
    {
        throw new System.NotImplementedException();
    }

    public override void MixTheIngradients()
    {
        throw new System.NotImplementedException();
    }

    public override void RunTheMachine()
    {
        throw new System.NotImplementedException();
    }

    public override void StopTheMachine()
    {
        throw new System.NotImplementedException();
    }
}