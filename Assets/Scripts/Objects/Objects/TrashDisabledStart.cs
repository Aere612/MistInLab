using UnityEngine;

public class TrashDisabledStart : MonoBehaviour,ICollactable
{
    public bool IsAvailableToCollect { get; set; } = false;
}