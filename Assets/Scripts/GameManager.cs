using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour //16
{
    public int timeLeft=1800;
    void Start()
    {
        StartCoroutine(Countdown());
    }
    void Update()
    {
        if (timeLeft <= 0)
        {
            //gameover sequence
        }
    }
    IEnumerator Countdown()
    {
        while (timeLeft>=1)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}