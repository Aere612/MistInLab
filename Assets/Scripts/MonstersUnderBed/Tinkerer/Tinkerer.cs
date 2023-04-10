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

    public void Attack()
    {
        doorStatus.text = "Unlocking...";
        doorStatus.color = Color.red;
        doorTime = 7;
        gameEventListener.enabled = true;
        //play unlocking audio
    }

    public void FakeChance()
    {
        if (!(countDown.TimeLeft > 100)) return;
        fakeUnlockChance -= 1;
        if (Random.Range(0, 100) < fakeUnlockChance) return;
        fakeUnlockChance = 200;
        //play unlocking audio
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
        doorStatus.text = "Locked";
        doorStatus.color = Color.green;
    }
}