using UnityEngine;
using UnityEngine.Serialization;

public class Sink : MonoBehaviour, IInteractable
{
    [SerializeField] private IngradientTypes _ingradientTypes;
    [SerializeField] private PlayerHandSo playerHandSo;
    [SerializeField] private AudioSource sinkSfx;

    public void Interaction()
    {
        if (!playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial)) return;
        if (_vial.baseIngradiant ==_ingradientTypes.Empty) return;
        
        sinkSfx.Play();
        _vial.baseIngradiant = _ingradientTypes.Empty;
        _vial.sideIngradiant = _ingradientTypes.Empty;
    }
}