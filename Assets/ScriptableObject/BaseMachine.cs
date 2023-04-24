using UnityEngine;

public abstract class BaseMachine : ScriptableObject
{
    [SerializeField] protected IngradientTypes _ingradientTypes;

    [SerializeField] internal int currentCountdown;
    [SerializeField] internal bool isCountdownStarted;
    [SerializeField] internal int choosenCountdown;
    [SerializeField] internal GameEvent OnMachineStarted;
    [SerializeField] internal GameEvent OnMachineStopped;

    public abstract void CheckTheConditionsAndRun();
    public abstract void MixTheIngredients();

    public abstract void RunTheMachine();
    public abstract void StopTheMachine();
}