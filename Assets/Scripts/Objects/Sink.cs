using UnityEngine;

public class Sink : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHandSo _playerHandSo;

    public void Interaction()
    {
        if (!_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial)) return;
        if (_vial.baseIngradiant == Ingradiant.Empty) return;
        Debug.Log("Sink");
        
        _vial.baseIngradiant = Ingradiant.Empty;
        _vial.sideIngradiant = Ingradiant.Empty;
    }
}