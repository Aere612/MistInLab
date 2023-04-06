using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class Flicker : MonoBehaviour
{
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private Light light3;
    [SerializeField] private MonsterSpawner monsterSpawner;
    [SerializeField] private Deadbolt deadbolt;
    [SerializeField] private GameEvent onGameLoseEvent;


    public void Attack()
    {
        Debug.Log("Attack");
        FlickerLights( light1);
        FlickerLights( light2);
        FlickerLights( light3, true);
    }

    private void SafetyCheck()
    {
        Debug.Log("SafetyCheck");
        if (deadbolt.IsLocked)
        {
            light1.DOIntensity(0.5f, 2f);
            light2.DOIntensity(0.5f, 2f);
            light3.DOIntensity(0.5f, 2f);
            Debug.Log("Dodge Flicker");
            return;
        }
        Debug.Log("Lose Flicker");
        onGameLoseEvent.Raise();
    }

    private void FlickerLights( Light targetLight, bool activator = false)
    {
        var targetSequence = DOTween.Sequence();
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.1f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.3f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.4f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.1f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.3f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.1f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.5f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.4f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.1f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.0f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.1f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.35f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.25f, 0.3f));
        targetSequence.Append(targetLight.DOIntensity(0.5f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.25f, 0.3f));
        targetSequence.Append(targetLight.DOIntensity(0.0f, 5.0f));
        if(activator)targetSequence.OnComplete(SafetyCheck);
    }
}