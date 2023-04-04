using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHandSo", menuName = "ScriptableObjects/PlayerHand", order = 1)]
public class PlayerHandSo : ScriptableObject
{
    [SerializeField] private GameObject currentObject;

    public GameObject CurrentObject => currentObject;

    public void PlaceObject(GameObject putInHand)
    {
        currentObject = putInHand;
    }
    public void RemoveObject()
    {
        currentObject = null;
    }
}