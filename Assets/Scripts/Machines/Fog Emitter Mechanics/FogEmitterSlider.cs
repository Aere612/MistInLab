using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.UI;

public class FogEmitterSlider : MonoBehaviour, IInteractable
{
    internal bool isCorrect;
    private bool _animDelay;
    [SerializeField] private AudioSource audioSource;

    public enum SliderState
    {
        Left,
        LeftMiddle,
        Middle,
        RightMiddle,
        Right
    }

    public SliderState leverState = 0;
    public Transform sliderObject;

    [SerializeField] private Slider sliderComponent;
    public void Interaction()
    {
        if (_animDelay) return;
        audioSource.Play();

        _animDelay = true;
        StartCoroutine(OneSecDelay());
        if (leverState != SliderState.Right) leverState++;
        else leverState = SliderState.Left;

        switch (leverState)
        {
            case SliderState.Left:
                sliderObject.DOMove(sliderObject.transform.position + new Vector3(0, 0, .700f), 1.00f);
                sliderComponent.DOValue(0f, 1);
                break;
            case SliderState.LeftMiddle:
                isCorrect = true;
                sliderObject.DOMove(sliderObject.transform.position + new Vector3(0, 0, -0.175f), 0.25f);
                sliderComponent.DOValue(0.25f, .25f);


                break;
            case SliderState.Middle:
                isCorrect = false;
                sliderObject.DOMove(sliderObject.transform.position + new Vector3(0, 0, -0.175f), 0.25f);
                sliderComponent.DOValue(0.50f, .25f);


                break;
            case SliderState.RightMiddle:
                sliderObject.DOMove(sliderObject.transform.position + new Vector3(0, 0, -0.175f), 0.25f);
                sliderComponent.DOValue(0.75f, .25f);


                break;
            case SliderState.Right:
                sliderObject.DOMove(sliderObject.transform.position + new Vector3(0, 0, -0.175f), 0.25f);
                sliderComponent.DOValue(1f, .25f);

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        IEnumerator OneSecDelay()
        {
            yield return new WaitForSeconds(1f);
            _animDelay = false;
        }
    }
}