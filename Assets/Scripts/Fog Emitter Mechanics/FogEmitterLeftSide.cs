using UnityEngine;

public class FogEmitterLeftSide : MonoBehaviour, IInteractable
{
    [SerializeField] private int cogAmount=0;
    [SerializeField] private PlayerHandSo playerHandSo;
    [SerializeField] private GameEvent onCogChangedEvent;

    public void Interaction()
    {
        if (!playerHandSo.CurrentObject.TryGetComponent<Cog>(out var cog)) return;
        cog.gameObject.SetActive(false);
        playerHandSo.CurrentObject = null;
        cogAmount++;
        onCogChangedEvent.Raise();
    }
}