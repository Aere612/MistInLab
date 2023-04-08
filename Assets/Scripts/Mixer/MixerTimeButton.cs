using UnityEngine;

public class MixerTimeButton : MonoBehaviour, IInteractable
{
    [SerializeField] private MixerController _mixerController;
    [SerializeField] private int _countdown;
    public void Interaction()
    {
        if (_mixerController.isCountdownStarted) return;
        _mixerController.currentCountdown = _countdown;
        _mixerController.isCountdownStarted = true;
    }
}