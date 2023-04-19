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
        doorStatus.text = "ACILIYOR...";
        doorStatus.color = Color.red;
        doorTime = 7;
        gameEventListener.enabled = true;
        audioSource.Play();
    }

    public void FakeChance()
    {
        if (!(countDown.TimeLeft > 100)) return;
        fakeUnlockChance -= 1;
        if (Random.Range(0, 100) < fakeUnlockChance) return;
        fakeUnlockChance = 200;
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
        gameEventListener.enabled = false;
        doorStatus.text = "KILITLI";
        doorStatus.color = Color.blue;
    }
}