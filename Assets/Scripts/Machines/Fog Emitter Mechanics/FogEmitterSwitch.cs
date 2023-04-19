using UnityEngine;
using DG.Tweening;

public class FogEmitterSwitch : MonoBehaviour,IInteractable
{
    public enum SwitchState
    {
        Up,
        Down
    }

    [SerializeField] public SwitchState switchState = 0;
    [SerializeField] public Transform switcher;

    public void Interaction()
    {
        if (switchState == SwitchState.Up)
        {
            switchState = SwitchState.Down;
            switcher.DORotate(new Vector3(0, 0, 160), 0.5f);
            return;
        }
        switchState = SwitchState.Up;
        switcher.DORotate(new Vector3(0, 0, 0), 0.5f);
    }
}