using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class FogEmitterSlider : MonoBehaviour, IInteractable
{
    internal bool isCorrect;
    private bool _animDelay;
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
        if (_animDelay) return;
        _animDelay = true;
        StartCoroutine(OneSecDelay());
        if (leverState != SliderState.Right) leverState++;
        else leverState = SliderState.Left;

        switch (leverState) 
        {
            case SliderState.Left:
                slider.DOMove(slider.transform.position + new Vector3(0, 0, .700f), 1.00f);
                isCorrect = false;
                break;
            case SliderState.LeftMiddle:
                isCorrect = true;
                slider.DOMove(slider.transform.position + new Vector3(0, 0, -0.175f), 0.25f);
                break;
            case SliderState.Middle:
                isCorrect = false;
                slider.DOMove(slider.transform.position + new Vector3(0, 0, -0.175f), 0.25f);
                break;
            case SliderState.RightMiddle:
                isCorrect = false;
                slider.DOMove(slider.transform.position + new Vector3(0, 0, -0.175f), 0.25f);
                break;
            case SliderState.Right:
                isCorrect = false;
                slider.DOMove(slider.transform.position + new Vector3(0, 0, -0.175f), 0.25f);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        IEnumerator OneSecDelay()
        {
            yield return new WaitForSeconds(1f);
            _animDelay=false;
        }
    }
}