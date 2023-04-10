using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FlashBang : MonoBehaviour, IInteractable
{
    [SerializeField] private Tinkerer tinkerer;
    [SerializeField] private int currentCd;
    [SerializeField] private int maxCd = 180;
    [SerializeField] private GameEventListener onTimeClickEventListener;
    [SerializeField] private Light flashBangLight;
    [SerializeField] private Image lightAnimImage;

    public void Interaction()
    {
        if (currentCd != 0) return;
        var  flashBangSequenceLight = DOTween.Sequence();
        var  flashBangSequenceImage = DOTween.Sequence();
        flashBangSequenceImage.Append(lightAnimImage.DOColor(new Color(1f,1f,1f,1f),0.05f));
        flashBangSequenceImage.Append(lightAnimImage.DOColor(new Color(1f,1f,1f,1f),0.5f));
        flashBangSequenceImage.Append(lightAnimImage.DOColor(new Color(1f,1f,1f,0f),2f));
        flashBangSequenceLight.Append(flashBangLight.DOIntensity(20f, 0.05f));
        flashBangSequenceLight.Append(flashBangLight.DOIntensity(20f, 0.5f));
        flashBangSequenceLight.Append(flashBangLight.DOIntensity(0f, 2f));
        currentCd = maxCd;
        onTimeClickEventListener.enabled = true;
        tinkerer.FlashBanged();
    }

    public void ReduceCd()
    {
        currentCd--;
        if (currentCd == 0) onTimeClickEventListener.enabled = false;
    }
}