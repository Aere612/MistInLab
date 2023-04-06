using UnityEngine;
using TMPro;

public class Tinkerer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI doorStatus;
    [SerializeField] private int doorTime;
    [SerializeField] private GameEventListener gameEventListener;
    [SerializeField] private GameEvent onGameLoseEvent;
    [SerializeField] private MonsterSpawner monsterSpawner;

    public void Attack()
    {
        doorStatus.text = "Unlocking...";
        doorStatus.color = Color.red;
        doorTime = 7;
        gameEventListener.enabled = true;
    }

    public void DoorTimeReducer()
    {
        if (doorTime > 0)
        {
            doorTime--;
            return;
        }
        Debug.Log("Lose Tinkerer");
        onGameLoseEvent.Raise();
    }

    public void FlashBanged()
    {
        gameEventListener.enabled = false;
        doorStatus.text = "Locked";
        doorStatus.color = Color.green;
        Debug.Log("Dodge Tinkerer");
    }
}