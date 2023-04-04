using UnityEngine;

public class CountDown : MonoBehaviour
{
    public int timeLeft=1800;
    [SerializeField] private GameEvent onGameOverEvent;
    public void Counting()
    {
        if (timeLeft > 0)
        {
           timeLeft--;
           return;
        }
        onGameOverEvent.Raise();
    }
}
