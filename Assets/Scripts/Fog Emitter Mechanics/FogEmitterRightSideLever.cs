using UnityEngine;
using DG.Tweening;

public class FogEmitterRightSideLever : MonoBehaviour, IInteractable
{
    public enum LeverState
    {
        Up,
        UpMiddle,
        Middle,
        DownMiddle,
        Down
    }

    [SerializeField] public LeverState leverState = 0;
    [SerializeField] public Transform lever;

    public void Interaction()
    {
        if (leverState != LeverState.Down) leverState++;
        else leverState = LeverState.Up;

        switch (leverState)
        {
            case LeverState.Up:
                lever.DORotate(new Vector3(0, 0, 0), 1f);
                break;
            case LeverState.UpMiddle:
                lever.DORotate(new Vector3(0, 0, 35), 0.25f);
                break;
            case LeverState.Middle:
                lever.DORotate(new Vector3(0, 0, 70), 0.25f);
                break;
            case LeverState.DownMiddle:
                lever.DORotate(new Vector3(0, 0, 105), 0.25f);
                break;
            case LeverState.Down:
                lever.DORotate(new Vector3(0, 0, 140), 0.25f);
                break;
        }
    }
}