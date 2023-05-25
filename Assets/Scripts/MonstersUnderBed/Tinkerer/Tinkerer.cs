using UnityEngine;
using TMPro;

public class Tinkerer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI doorStatus;
    [SerializeField] private int doorTime;
    [SerializeField] private int fakeUnlockChance=150;
    [SerializeField] private GameEventListener gameEventListener;
    [SerializeField] private GameEvent onGameLoseEvent;
    [SerializeField] private CountDown countDown;
    [SerializeField] private AudioSource audioSource;

    public void Attack()
    {
        doorStatus.text = "UNLOCKING...";
        doorStatus.color = Color.red;
        doorTime = 7;
        gameEventListener.enabled = true;
        audioSource.Play();
    }

    public void DoorTimeReducer()
    {
        if (doorTime > 0)
        {
            doorTime--;
            return;
        }
        onGameLoseEvent.Raise();
    }

    public void FlashBanged()
    {
        if(!gameEventListener.enabled) return;
        gameEventListener.enabled = false;
        doorStatus.text = "LOCKED";
        doorStatus.color = Color.blue;
        audioSource.Stop();
    }
}