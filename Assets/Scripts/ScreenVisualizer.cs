using UnityEngine;
using TMPro;
using System;
public class ScreenVisualizer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI integrity, lockState;
    [SerializeField] private CountDown countDown;

    public void UpdateScreen()
    {
        var currentCountDown = countDown;
        if (currentCountDown.timeLeft > 300)
        {
            var value = (float)0.000025 * currentCountDown.timeLeft * currentCountDown.timeLeft + (float)0.01 * currentCountDown.timeLeft;
            integrity.text = "%"+Math.Floor(value);
            integrity.color = value switch
            {
                < 33 => Color.red,
                < 66 => Color.yellow,
                _ => integrity.color
            };
            return;
        }
        integrity.text = "Collapse Imminent";
    }
}
