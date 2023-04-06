using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private int currentWaitFactor = 380;
    [SerializeField] private Flicker flicker;
    [SerializeField] private Tinkerer tinkerer;
    [SerializeField] private CountDown countDown;


    public void SpawnCheck()
    {
        if (!(countDown.TimeLeft > 100)) return;
        currentWaitFactor -= 1;
        if (Random.Range(0, 100) < currentWaitFactor) return;
        currentWaitFactor = 380;
        switch (Random.Range(2, 3))
        {
            case 1:
                flicker.Attack();
                break;
            case 2:
                tinkerer.Attack();
                break;
        }
    }
}