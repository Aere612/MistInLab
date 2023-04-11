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
    private State state = State.OnWall;

    public void Interaction()
    {
        switch (state)
        {
            case State.OnHand:
                playerMovement.enabled = true;
                state = State.OnWall;
                flashLight.DOMove(flashLightCurrent.position, 0.5f);
                flashLight.DORotate(flashLightCurrent.rotation.eulerAngles, 0.5f);
                transform.DOMove(returnLocation.position, 0.5f);
                transform.DORotate(returnLocation.rotation.eulerAngles, 0.5f);
                break;
            case State.OnWall:
                playerMovement.enabled = false;
                state = State.OnHand;
                flashLight.DOMove(flashLightCloseUp.position, 0.5f);
                flashLight.DORotate(flashLightCloseUp.rotation.eulerAngles, 0.5f);
                transform.DOMove(playerFaceLocation.position, 0.5f);
                transform.DORotate(player.rotation.eulerAngles, 0.5f);
                break;
        }
    }
}