using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class LightFlickerAnim : MonoBehaviour
{
    [SerializeField] private int currentWaitFactor = 50;
    [SerializeField] private Light light;
    private Sequence _sequence;

    private void Awake()
    {
        var lastIntensity = light.intensity;
        _sequence = DOTween.Sequence();
        _sequence.Append(light.DOIntensity(0f,1f));
        _sequence.Append(light.DOIntensity(lastIntensity,1f));
    }

    public void Check()
    {
        currentWaitFactor -= 1;
        if (Random.Range(0, 30) < currentWaitFactor) return;
        currentWaitFactor = 50;
        _sequence.Play();
    }
}