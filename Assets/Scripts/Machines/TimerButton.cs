using UnityEngine;

public class TimerButton : MonoBehaviour, IInteractable
{
    [SerializeField] private BaseMachine _machine;
    [SerializeField] private int _countdown;
    public bool once=false;
    public void Awake()
    {
        TimerButton button = GetComponent<TimerButton>();
        button.StartShaker(button._machine, button._countdown);
    }


    public void Interaction()
    {
        if (_machine.isCountdownStarted) return;
        _machine.choosenCountdown = _countdown;
        _machine.currentCountdown = _countdown;
        _machine.CheckTheConditionsAndRun();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (true)
        {

        }
        
    }
    public void StartShaker(BaseMachine _machine , int _countdown)
    {
        if (_machine.isCountdownStarted) return;
        _machine.choosenCountdown = _countdown;
        _machine.currentCountdown = _countdown;
        _machine.CheckTheConditionsAndRun();
    }
}