using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHandSo", menuName = "ScriptableObjects/PlayerHand", order = 1)]
public class PlayerHandSo : ScriptableObject
{
    [SerializeField] private GameObject currentObject;
    [SerializeField] private Transform playerHandLocation;

    public GameObject CurrentObject => currentObject;

    public Transform PlayerHandLocation
    {
        get => playerHandLocation;
        set => playerHandLocation = value;
    }

    public void PutInHand(GameObject putInHand)
    {
        currentObject = putInHand;
        currentObject.transform.position = PlayerHandLocation.position;
        currentObject.transform.SetParent(PlayerHandLocation);
    }
    public void RemoveObject()
    {
        currentObject = null;
    }
}