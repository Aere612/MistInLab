using System.Collections;
using System.Collections.Generic;
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
            if (_vial.baseIngradiant != Ingradiant.Empty)
            {
                Debug.Log("There is another ingrediant");
                return;
            }

            _vial.baseIngradiant = ingradiantType;
            Debug.Log("Base Ingradient ejected");
        }
        else
        {
            Debug.Log("Wrong object to put");
        }
    }
}