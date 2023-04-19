using UnityEngine;

public class Key : MonoBehaviour,IInteractable,ICollactable
{
    [SerializeField] private PickUpTutorial pickUpTutorial;
    [SerializeField] private bool once=true;
    public void Interaction()
    {
        if (!once) return;
        once = false;
        pickUpTutorial.Vanish();
    }

    private void Awake()
    {
        pickUpTutorial.gameObject.SetActive(true);
    }

    public bool IsAvailableToCollect { get; set; }= true;
}
