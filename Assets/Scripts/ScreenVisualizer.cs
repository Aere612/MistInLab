using UnityEngine;
using TMPro;
using System;
public class ScreenVisualizer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI integrity;
    [SerializeField] private CountDown countDown;

    public void UpdateScreen()
    {
        var currentCountDown = countDown.TimeLeft;
        if (currentCountDown > 100)
        {
            var value = 0.0001234567899f * currentCountDown * currentCountDown;
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
