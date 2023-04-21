using UnityEngine;
using UnityEngine.Serialization;

public class Sink : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHandSo playerHandSo;
    [SerializeField] private AudioSource sinkSfx;

    public void Interaction()
    {
        if (!playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial)) return;
        if (_vial.baseIngradiant.Type == Ingradient.Empty) return;
        sinkSfx.Play();
        _vial.baseIngradiant.Type = Ingradient.Empty;
        _vial.sideIngradiant.Type = Ingradient.Empty;
    }
}