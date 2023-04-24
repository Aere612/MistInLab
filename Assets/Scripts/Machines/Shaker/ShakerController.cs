using UnityEngine;

public class ShakerController : MonoBehaviour
{
    [SerializeField] private Shaker _shaker;
    [SerializeField] private VialSlot _input;
    [SerializeField] private GameEventListener timeClickListener;
    private void Awake()
    {
        InitializeShaker();
    }

    public void CheckCountdown()
    {
        if (_shaker.currentCountdown > 0)
            _shaker.currentCountdown--;
        else
        {
            _shaker.MixTheIngredients();
            _shaker.isCountdownStarted = false;
            timeClickListener.enabled = false;
            _shaker.StopTheMachine();
        }
    }
    public void ActivateTimeClickListener()
    {
        timeClickListener.enabled = true;
    }
    private void InitializeShaker()
    {
        _shaker.isCountdownStarted = false;
        _shaker.input = _input;
        timeClickListener.enabled = false;
    }
}