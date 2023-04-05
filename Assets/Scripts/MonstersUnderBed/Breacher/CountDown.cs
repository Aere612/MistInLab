using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] private int timeLeft = 900;
    [SerializeField] private GameEvent onGameOverEvent;
    [SerializeField] private ParticleSystem particleSystem;

    public int TimeLeft => timeLeft;

    public void Counting()
    {
        if (TimeLeft > 0)
        {
            var parSys=particleSystem.main;
            parSys.startColor = new Color(parSys.startColor.color.r,parSys.startColor.color.g,parSys.startColor.color.b,parSys.startColor.color.a+0.0013888888888889f);
            timeLeft--;
            return;
        }
        onGameOverEvent.Raise();
    }
}