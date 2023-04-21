using UnityEngine;

public class IngradiantSpawner : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHandSo _playerHandSo;
    [SerializeField] private Ingradiant ingradiantType;
    
    public void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial))
        {
            if (_vial.baseIngradiant. != Ingradiant.Empty)
            {
                if(_vial.sideIngradiant != Ingradiant.Empty)
                    Debug.Log("Vial is Full");
                else
                {
                    _vial.sideIngradiant = ingradiantType;
                }
                return;
            }
            _vial.BaseIngradiant = ingradiantType;
            Debug.Log("Base Ingradient ejected");
        }
        else
        {
            Debug.Log("Wrong object to put");
        }
    }
}