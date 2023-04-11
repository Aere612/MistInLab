using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Not : MonoBehaviour, IInteractable
{
    private enum State
    {
        OnHand,
        OnWall
    }

    [SerializeField] private Transform playerFaceLocation;
    [SerializeField] private Transform returnLocation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform flashLight;
    [SerializeField] private Transform flashLightCurrent;
    [SerializeField] private Transform flashLightCloseUp;
    [SerializeField] private pm playerMovement;
    private State _state = State.OnWall;

    public void Interaction()
    {
        var sequence = DOTween.Sequence();
        switch (_state)
        {
            case State.OnHand:
                _state = State.OnWall;
                sequence.Append(flashLight.DOMove(flashLightCurrent.position, 0.5f));
                sequence.Join(flashLight.DORotate(flashLightCurrent.rotation.eulerAngles, 0.5f));
                sequence.Join(transform.DOMove(returnLocation.position, 0.5f));
                sequence.Join(transform.DORotate(returnLocation.rotation.eulerAngles, 0.5f));
                sequence.OnComplete(() => playerMovement.enabled = true);
                break;
            case State.OnWall:
                _state = State.OnHand;
                sequence.OnStart(() => playerMovement.enabled = false);
                sequence.Append(flashLight.DOMove(flashLightCloseUp.position, 0.5f));
                sequence.Join( flashLight.DORotate(flashLightCloseUp.rotation.eulerAngles, 0.5f));
                sequence.Join(transform.DOMove(playerFaceLocation.position, 0.5f));
                sequence.Join(transform.DORotate(player.rotation.eulerAngles, 0.5f));
                break;
        }
    }
}