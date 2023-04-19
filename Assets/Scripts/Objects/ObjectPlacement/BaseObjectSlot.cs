using Unity.Mathematics;
using UnityEngine;

public class BaseObjectSlot : MonoBehaviour, IInteractable
{
    [SerializeField] internal PlayerHandSo _playerHandSo;
    [SerializeField] internal Transform _slotTransform;
    [SerializeField] internal BaseObject _currentObject;

    public virtual void Interaction()
    {
    }

    protected void PlaceTheObject(GameObject objectToPlace)
    {
        _playerHandSo.CurrentObject.transform.parent = null;
        objectToPlace.transform.position = _slotTransform.position;
        objectToPlace.transform.eulerAngles = new Vector3(transform.eulerAngles.x+90,transform.eulerAngles.y,transform.eulerAngles.z);
        _playerHandSo.CurrentObject.transform.parent = transform;
        _playerHandSo.CurrentObject = null;
    }
}