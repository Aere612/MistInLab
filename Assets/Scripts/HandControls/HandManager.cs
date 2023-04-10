using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] private PlayerHandSo _playerHandSo;
    [SerializeField] private Transform playerHandTransform;
    [SerializeField] private Transform playerCameraTransform;

    private void Start()
    {
        _playerHandSo.CurrentObject = null;
        _playerHandSo.playerHandTransform = playerHandTransform;
        _playerHandSo.playerCameraTransform = playerCameraTransform;
    }

    public void CastRay()
    {
        if (!Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out var hit, 10)) return;
        
        if (hit.collider.TryGetComponent<ICollactable>(out var _clickedObject) && _playerHandSo.CurrentObject == null && _clickedObject.IsAvaibleToCollect)
        {
            _playerHandSo.PutObjectToHand(hit.collider.gameObject);
        }

        if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
        {
            interactable.Interaction();
        }

    }
    public void DropTheObject()
    {
        _playerHandSo.DropTheObject();
    }
}
