using UnityEngine;

public class Sink : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHandSo _playerHandSo;

    public void Interaction()
    {
        if (!_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial)) return;
        if (_vial.BaseIngradiant == Ingradiant.Empty) return;
        Debug.Log("Sink");
        
        _vial.BaseIngradiant = Ingradiant.Empty;
        _vial.SideIngradiant = Ingradiant.Empty;
    }
}