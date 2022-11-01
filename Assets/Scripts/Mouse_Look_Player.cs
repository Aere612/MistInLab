using UnityEngine;
using System.Collections;


public class Mouse_Look_Player : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform player;
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity *Time.deltaTime;
        
        player.Rotate(Vector3.up * mouseX);
    }
    


}