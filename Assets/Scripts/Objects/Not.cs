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
    [SerializeField] private Transform wallLocation;
    [SerializeField] private Transform player;
    [SerializeField] private pm playerMovement;
    private State state = State.OnWall;

    public void Interaction()
    {
        Debug.Log(player.rotation.y);
        switch (state)
        {
            case State.OnHand:
                playerMovement.enabled = true;
                state = State.OnWall;
                transform.DOMove(wallLocation.position, 1f);
                transform.DORotate(new Vector3(0,0,0), 0.5f);
                break;
            case State.OnWall:
                playerMovement.enabled = false;
                state = State.OnHand;
                transform.DOMove(playerFaceLocation.position, 0.5f);
               // transform.DOLookAt(player.position,0.5f);
                transform.DORotate(player.rotation.eulerAngles, 0.5f);
                break;
        }
    }
}