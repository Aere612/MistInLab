using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class Flicker : MonoBehaviour
{
    private readonly Sequence _mySequence1;
    private readonly Sequence _mySequence2;
    private readonly Sequence _mySequence3;
    private readonly Sequence _mySequence4;
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private Light light3;
    [SerializeField] private Light light4;
    [SerializeField] private MonsterSpawner monsterSpawner;
    [SerializeField] private Deadbolt deadbolt;
    [SerializeField] private GameEvent onGameLoseEvent;


    public void Attack()
    {
        Debug.Log("Attack");
        FlickerLights(_mySequence1, light1);
        FlickerLights(_mySequence2, light2);
        FlickerLights(_mySequence3, light3);
        FlickerLights(_mySequence4, light4, true);
    }

    private void SafetyCheck()
    {
        Debug.Log("SafetyCheck");
        if (deadbolt.IsLocked)
        {
            monsterSpawner.AllowSpawn();
            light1.DOIntensity(0.5f, 2f);
            light2.DOIntensity(0.5f, 2f);
            light3.DOIntensity(0.5f, 2f);
            light4.DOIntensity(0.5f, 2f);
            Debug.Log("Dodge Flicker");
            return;
        }
        Debug.Log("Lose Flicker");
        onGameLoseEvent.Raise();
    }

    private void FlickerLights(Sequence targetSequence, Light targetLight, bool activator = false)
    {
        targetSequence = DOTween.Sequence();
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