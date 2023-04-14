using UnityEngine;

public class Close_Button : MonoBehaviour
{
    public GameObject ScreenCam, PlayerCam, Player;
    public void Close()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ScreenCam.SetActive(false);
        PlayerCam.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled = true;
        
    }
}
