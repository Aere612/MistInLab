using System.Collections;
using DG.Tweening;
using UnityEngine;

public class LateGame : MonoBehaviour
{
    [SerializeField] private CountDown countDown;
    [SerializeField] private Light[] roomLights;
    [SerializeField] private Light[] spotLights;
    [SerializeField] private Transform[] spotLightsParentsTransforms;
    public void LateGameStartCheck()
    {
        if(countDown.TimeLeft==128) StartCoroutine(LateGameStart());
    }
    //128 lights out
    //112 yellow lights
    //83 lights out
    //79 red lights
    //5 lights out
    private IEnumerator LateGameStart()
    {
        foreach (var spotLightsParentsTransform in spotLightsParentsTransforms)
        {
            spotLightsParentsTransform.transform.DORotate(new Vector3(0, 360, 0),1f).SetLoops(-1);
        }
        foreach (var roomLight in roomLights)
        {
            roomLight.enabled = false;
        }
        yield return new WaitForSeconds(16f);
        foreach (var spotLight in spotLights)
        {
            spotLight.enabled = true;
            spotLight.color = Color.yellow;
        }
        yield return new WaitForSeconds(29f);
        foreach (var spotLight in spotLights)
        {
            spotLight.enabled = false;
        }
        yield return new WaitForSeconds(4f);
        foreach (var spotLight in spotLights)
        {
            spotLight.enabled = true;
            spotLight.color = Color.red;
        }       
        yield return new WaitForSeconds(74f);
        foreach (var spotLight in spotLights)
        {
            spotLight.enabled = false;
        }  
        yield return new WaitForSeconds(0.1f);
        foreach (var spotLight in spotLights)
        {
            spotLight.enabled = true;
        }  
        yield return new WaitForSeconds(0.1f);
        foreach (var spotLight in spotLights)
        {
            spotLight.enabled = false;
        }  
        yield return new WaitForSeconds(0.1f);
        foreach (var spotLight in spotLights)
        {
            spotLight.enabled = true;
        }  
        yield return new WaitForSeconds(0.1f);
        foreach (var spotLight in spotLights)
        {
            spotLight.enabled = false;
        }  
    }
}
