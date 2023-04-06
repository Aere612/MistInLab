using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private PlayerHandSo _playerHandSo;

    public void Interaction()
    {
        if (_playerHandSo.CurrentObject == null)
        {
            var instantiatedObject = Instantiate(objectToSpawn);
            _playerHandSo.PutObjectToHand(instantiatedObject);
        }
    }
}