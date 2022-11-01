using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look_Camera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform camera;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        

        if (camera.rotation.x > 0.70)
        {
            camera.Rotate(Vector3.left);
        }
        else if (camera.rotation.x < -0.70)
        {
            camera.Rotate(Vector3.right);
        }
        else { camera.Rotate(Vector3.left * mouseY); }
    }
}
