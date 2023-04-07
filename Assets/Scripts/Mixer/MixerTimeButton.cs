using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerTimeButton : MonoBehaviour, IInteractable
{
    [SerializeField] private MixerController _mixerController;
    [SerializeField] private int _countdown;
    public void Interaction()
    {
        _mixerController.currentCountdown = _countdown;
        _mixerController.isCountdownStarted = true;
    }
}