using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Close_Button : MonoBehaviour
{
    public GameObject ScreenCam, PlayerCam, Player;
    public void Close()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ScreenCam.SetActive(false);
        PlayerCam.SetActive(true);
        Player.GetComponent<pm>().enabled = true;
        
    }
}
