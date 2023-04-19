using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class FogEmitterLever : MonoBehaviour, IInteractable
{
    internal bool isCorrect;   
    private bool _animDelay;

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
        if (_animDelay) return;
        _animDelay = true;
        StartCoroutine(OneSecDelay());
        if (leverState != LeverState.Down) leverState++;
        else leverState = LeverState.Up;

        switch (leverState)
        {
            case LeverState.Up:
                isCorrect = false;
                lever.DORotate(new Vector3(0, 0, 0), 1f);
                break;
            case LeverState.UpMiddle:
                isCorrect = true;
                lever.DORotate(new Vector3(0, 0, 35), 0.25f);
                break;
            case LeverState.Middle:
                isCorrect = false;
                lever.DORotate(new Vector3(0, 0, 70), 0.25f);
                break;
            case LeverState.DownMiddle:
                isCorrect = false;
                lever.DORotate(new Vector3(0, 0, 105), 0.25f);
                break;
            case LeverState.Down:
                isCorrect = false;
                lever.DORotate(new Vector3(0, 0, 140), 0.25f);
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