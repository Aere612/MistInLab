using System;
using UnityEngine;

public class IngradiantSpawner : MonoBehaviour, IInteractable, ICollactable
{
    [SerializeField] private PlayerHandSo _playerHandSo;
    [SerializeField] private Ingradiant ingradiantType;
    [SerializeField] private AudioSource pickUpSfx;

    private void Awake()
    {
        IsAvailableToCollect = true;
    }

    public void Interaction()
    {
        pickUpSfx.Play();
        if (_playerHandSo.CurrentObject == null) return;
        if (_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial))
        {
            if (_vial.baseIngradiant. != Ingradiant.Empty)
            {
                if (_vial.sideIngradiant != Ingradiant.Empty)
                    Debug.Log("Vial is Full");
                else
                {
                    _vial.sideIngradiant = ingradiantType;
                }

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

    public bool IsAvailableToCollect { get; set; }
}