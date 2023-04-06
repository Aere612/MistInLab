using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour,IInteractable
{
    [SerializeField] private PlayerHandSo _playerHandSo;
    public void Interaction()
    {
        if (_playerHandSo.CurrentObject != null)
        {
            Destroy(_playerHandSo.CurrentObject.gameObject);
        }
    }
}
