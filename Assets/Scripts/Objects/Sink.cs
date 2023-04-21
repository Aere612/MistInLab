using UnityEngine;
using UnityEngine.Serialization;

public class Sink : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHandSo playerHandSo;
    [SerializeField] private AudioSource sinkSfx;

    public void Interaction()
    {
        if (!playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial)) return;
        if (_vial.baseIngradiant == Ingradiant.Empty) return;
        sinkSfx.Play();
        _vial.baseIngradiant = Ingradiant.Empty;
        _vial.sideIngradiant = Ingradiant.Empty;
    }
}