using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_3D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool canMove=true;
    public int a=5;
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {Move();}
    }
    void Move(){
        if(Input.GetKey("w"))
        {transform.Translate(Vector3.forward*5*Time.deltaTime);}
        if(Input.GetKey("a"))
        {transform.Translate(Vector3.left*5*Time.deltaTime);}
        if(Input.GetKey("s"))
        {transform.Translate(Vector3.back*5*Time.deltaTime);}
        if(Input.GetKey("d"))
        {transform.Translate(Vector3.right*5*Time.deltaTime);}


    }
}
