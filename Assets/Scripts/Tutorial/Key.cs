using UnityEngine;

public class Key : MonoBehaviour, IInteractable, ICollactable
{
    [SerializeField] private PickUpTutorial pickUpTutorial;
    [SerializeField] private bool once = true;
    [SerializeField] private AudioSource keyPickUpSound;

    public void Interaction()
    {
        keyPickUpSound.Play();
        if (!once) return;
        once = false;
        pickUpTutorial.Vanish();
    }

    private void Awake()
    {
        pickUpTutorial.gameObject.SetActive(true);
    }

    public bool IsAvailableToCollect { get; set; } = true;
}