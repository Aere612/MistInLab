using UnityEngine;

public class FogEmitterLeftSide : MonoBehaviour, IInteractable
{
    [SerializeField] private int cogAmount=0;

    [SerializeField] private PlayerHandSo playerHandSo;

    public void Interaction()
    {
        if (!playerHandSo.CurrentObject.TryGetComponent<Cog>(out var cog)) return;
        cog.gameObject.SetActive((false));
        playerHandSo.RemoveObject();
        cogAmount++;
    }
}