using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] private PlayerHandSo playerHandSo;
    [SerializeField] private Transform playerHandTransform;
    [SerializeField] private Transform playerCameraTransform;

    private void Start()
    {
        playerHandSo.CurrentObject = null;
        playerHandSo.playerHandTransform = playerHandTransform;
        playerHandSo.playerCameraTransform = playerCameraTransform;
    }

    public void CastRay()
    {
        if (!Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out var hit, 4)) return;
        
        if (hit.collider.TryGetComponent<ICollactable>(out var clickedObject) && playerHandSo.CurrentObject == null && clickedObject.IsAvailableToCollect)
        {
            playerHandSo.PutObjectToHand(hit.collider.gameObject);
        }

        if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
        {
            interactable.Interaction();
        }

    }
    public void DropTheObject()
    {
        playerHandSo.DropTheObject();
    }
}
