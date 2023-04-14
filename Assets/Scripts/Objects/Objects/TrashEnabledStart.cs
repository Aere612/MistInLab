using UnityEngine;

public class TrashEnabledStart : MonoBehaviour, ICollactable
{
    public bool IsAvailableToCollect { get; set; } = true;
}