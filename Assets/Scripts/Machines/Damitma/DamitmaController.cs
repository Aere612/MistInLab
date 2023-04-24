using UnityEngine;

public class DamitmaController : MonoBehaviour
{
    [SerializeField] private Damitma _damitma;
    [SerializeField] private VialSlot _input;
    [SerializeField] private VialSlot _output;
    [SerializeField] private GameEventListener timeClickListener;

    private void Awake()
    {
        InitializeMixer();
    }

    public void CheckCountdown()
    {

        if (_damitma.currentCountdown > 0)
            _damitma.currentCountdown--;
        else
        {
            _damitma.MixTheIngredients();
            _damitma.StopTheMachine();
            timeClickListener.enabled = false;
        }
    }

    public void ActivateTimeClickListener()
    {
        timeClickListener.enabled = true;
    }

    private void InitializeMixer()
    {
        _damitma.isCountdownStarted = false;
        _damitma.input = _input;
        _damitma.output = _output;
        timeClickListener.enabled = false;
    }
}
