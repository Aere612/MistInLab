using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactions : MonoBehaviour
{
    int layerMask;
    RaycastHit hit;
    public GameObject Player, ScreenCam, PlayerCam;
    private void Start()
    {
        layerMask = 1 << 2;
        layerMask = ~layerMask;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3, layerMask);
            try { 
                if (hit.transform.tag == "Screen")
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    ScreenCam.SetActive(true);
                    PlayerCam.SetActive(false);
                    Player.GetComponent<pm>().enabled = false;
                }
            }
            catch {}
        }
    }
}