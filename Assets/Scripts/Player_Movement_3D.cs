using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement_3D : MonoBehaviour
{
    public CharacterController controller;
    public int playerSpeed=5;
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}