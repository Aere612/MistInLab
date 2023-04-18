using UnityEngine;

[CreateAssetMenu(fileName = "Shaker", menuName = "Machines/Shaker")]
public class Shaker : BaseMachine
{
    [SerializeField] internal bool isCorrect;
    [SerializeField] internal int correctCountdown;
    public override Ingradiant RunTheMachine(Ingradiant baseIngradiant, Ingradiant sideIngradiant)
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
}