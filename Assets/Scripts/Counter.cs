using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour //16
{
    [SerializeField] private GameEvent onTimeClickEvent;
    private void Start()
    {
        StartCoroutine(Countdown());
    }
    private IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            onTimeClickEvent.Raise();
        }
    }
}