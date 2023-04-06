using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHandSo", menuName = "ScriptableObjects/PlayerHand", order = 1)]
public class PlayerHandSo : ScriptableObject
{
    [SerializeField] private GameObject currentObject;

    public GameObject CurrentObject
    {
        get => currentObject;
        set => currentObject = value;
    }
}