using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHandSo", menuName = "ScriptableObjects/PlayerHand", order = 1)]
public class PlayerHandSo : ScriptableObject
{
    [SerializeField] private GameObject currentObject;
    [SerializeField] internal Transform playerHandTransform;
    [SerializeField] internal Transform playerCameraTransform;
    public GameObject CurrentObject
    {
        get => currentObject;
        set => currentObject = value;
    }
    public void PutObjectToHand(GameObject objectToPut)
    {
        CurrentObject = objectToPut;
        CurrentObject.transform.parent = playerCameraTransform;
        CurrentObject.transform.position = playerHandTransform.position;
        CurrentObject.transform.eulerAngles = playerHandTransform.eulerAngles;
        CurrentObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void DropTheObject()
    {
        if (CurrentObject == null) return;
        var rigidbody = CurrentObject.GetComponent<Rigidbody>();
        CurrentObject.transform.parent = null;
        rigidbody.isKinematic = false;
        rigidbody.AddForce(CurrentObject.transform.forward * 200);
        CurrentObject = null;
    }
}