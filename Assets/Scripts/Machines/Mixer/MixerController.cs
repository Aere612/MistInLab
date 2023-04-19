using UnityEngine;

public class MixerController : MonoBehaviour
{
    [SerializeField] private Mixer _mixer;
    [SerializeField] private VialSlot _inputOne;
    [SerializeField] private VialSlot _inputTwo;
    [SerializeField] private VialSlot _output;
    [SerializeField] private GameEventListener timeClickListener;

    private void Awake()
    {
        InitializeMixer();
    }

    public void CheckCountdown()
    {
        if (_mixer.currentCountdown > 0)
            _mixer.currentCountdown--;
        else
        {
            _mixer.MixTheIngradients();
            _mixer.StopTheMachine();
            timeClickListener.enabled = false;
        }
    }

    public void ActivateTimeClickListener()
    {
        timeClickListener.enabled = true;
    }
    private void InitializeMixer()
    {
        _mixer.isCountdownStarted = false;
        _mixer.inputOne = _inputOne;
        _mixer.inputTwo = _inputTwo;
        _mixer.output = _output;
        timeClickListener.enabled = false;
    }
}