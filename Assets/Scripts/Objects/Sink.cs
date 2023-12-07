using UnityEngine;
using UnityEngine.Serialization;

public class Sink : MonoBehaviour, IInteractable
{
    [SerializeField] private IngradientTypes _ingradientTypes;
    [SerializeField] private PlayerHandSo playerHandSo;
    [SerializeField] private AudioSource sinkSfx;

    public void Interaction()
    {
        if (playerHandSo.CurrentObject == null) return;
        if (!playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial)) return;
        if (_vial.BaseIngradiant ==_ingradientTypes.Empty) return;
        
        sinkSfx.Play();
        _vial.BaseIngradiant = _ingradientTypes.Empty;
        _vial.SideIngradiant = _ingradientTypes.Empty;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vial"))
        {
            if (other.gameObject == null) return;
            if (!other.gameObject.TryGetComponent<Vial>(out var _vial)) return;
            if (_vial.BaseIngradiant == _ingradientTypes.Empty) return;

            sinkSfx.Play();
            _vial.BaseIngradiant = _ingradientTypes.Empty;
            _vial.SideIngradiant = _ingradientTypes.Empty;
        }
    }
}