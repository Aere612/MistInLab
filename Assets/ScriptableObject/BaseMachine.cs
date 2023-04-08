using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMachine : ScriptableObject
{
    [SerializeField] internal int currentCountdown;
    [SerializeField] internal bool isCountdownStarted;

    public abstract Ingradiant RunTheMachine(Ingradiant baseIngradiant,Ingradiant sideIngradiant);
}
