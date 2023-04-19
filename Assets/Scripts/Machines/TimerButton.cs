using UnityEngine;

public class TimerButton : MonoBehaviour, IInteractable
{
    [SerializeField] private BaseMachine _machine;
    [SerializeField] private int _countdown;

    public void Interaction()
    {
        if (_machine.isCountdownStarted) return;
        _machine.choosenCountdown = _countdown;
        _machine.currentCountdown = _countdown;
        _machine.CheckTheConditionsAndRun();
    }
}