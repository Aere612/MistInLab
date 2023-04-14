using UnityEngine;
using DG.Tweening;

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
    [SerializeField] private PlayerMovement playerMovement;
    private State _state = State.OnWall;
    private Sequence _sequence;
    public void Interaction()
    {
        if (_state == State.OnHand) return;
        _state = State.OnHand;
        _sequence = DOTween.Sequence();
        _sequence.OnStart(() => playerMovement.enabled = false);
        _sequence.Append(flashLight.DOMove(flashLightCloseUp.position, 0.5f));
        _sequence.Join( flashLight.DORotate(flashLightCloseUp.rotation.eulerAngles, 0.5f));
        _sequence.Join(transform.DOMove(playerFaceLocation.position, 0.5f));
        _sequence.Join(transform.DORotate(player.rotation.eulerAngles, 0.5f));
    }
    private void OnMouseDown()
    {
        if (_state == State.OnWall) return;
        _state = State.OnWall;
        _sequence = DOTween.Sequence();
        _sequence.Append(flashLight.DOMove(flashLightCurrent.position, 0.5f));
        _sequence.Join(flashLight.DORotate(flashLightCurrent.rotation.eulerAngles, 0.5f));
        _sequence.Join(transform.DOMove(returnLocation.position, 0.5f));
        _sequence.Join(transform.DORotate(returnLocation.rotation.eulerAngles, 0.5f));
        _sequence.OnComplete(() => playerMovement.enabled = true);
    }
}        