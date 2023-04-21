using UnityEngine;

public class TrashEnabledStart : MonoBehaviour, ICollactable, IInteractable
{
    public bool IsAvailableToCollect { get; set; } = true;
    [SerializeField] private AudioSource pickUpSound;
    public void Interaction()
    {
        pickUpSound.Play();
    }
}