using UnityEngine;

public abstract class BaseMachine : ScriptableObject
{
    [SerializeField] internal int currentCountdown;
    [SerializeField] internal bool isCountdownStarted;
    [SerializeField] internal int choosenCountdown;
    [SerializeField] internal GameEvent OnMachineStarted;
    [SerializeField] internal GameEvent OnMachineStopped;

    public abstract void CheckTheConditionsAndRun();
    public abstract void MixTheIngradients();

    public abstract void RunTheMachine();
    public abstract void StopTheMachine();
}