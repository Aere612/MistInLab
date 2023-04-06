using System;
using UnityEngine;
using DG.Tweening;

public class FogEmitterRightSideSlider : MonoBehaviour, IInteractable
{
    public enum SliderState
    {
        Left,
        LeftMiddle,
        Middle,
        RightMiddle,
        Right
    }

    [SerializeField] public SliderState leverState = 0;
    [SerializeField] public Transform slider;

    public void Interaction()
    {
        if (leverState != SliderState.Right) leverState++;
        else leverState = SliderState.Left;

        switch (leverState)
        {
            case SliderState.Left:
                slider.DOMove(new Vector3(-5.17f, 1.5134f, 2.020f), 1.00f);
                break;
            case SliderState.LeftMiddle:
                slider.DOMove(new Vector3(-5.17f, 1.5134f, 1.845f), 0.25f);
                break;
            case SliderState.Middle:
                slider.DOMove(new Vector3(-5.17f, 1.5134f, 1.670f), 0.25f);
                break;
            case SliderState.RightMiddle:
                slider.DOMove(new Vector3(-5.17f, 1.5134f, 1.495f), 0.25f);
                break;
            case SliderState.Right:
                slider.DOMove(new Vector3(-5.17f, 1.5134f, 1.320f), 0.25f);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}