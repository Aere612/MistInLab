using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour, IInteractable
{
    [SerializeField] protected  GameObject objectToSpawn;
    [SerializeField] protected PlayerHandSo _playerHandSo;

    public virtual void Interaction()
    {
        if (_playerHandSo.CurrentObject == null)
        {
            var instantiatedObject = Instantiate(objectToSpawn);
            _playerHandSo.PutObjectToHand(instantiatedObject);
        }
    }
}