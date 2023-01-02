using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class J_Door : MonoBehaviour
{
    public bool triggered=false,allowed=true,locked=false,open=false;
    void Update()
    {
        if(triggered&&allowed&&!locked){
            triggered = false;
            if (open)
            {
                GetComponent<Animator>().SetBool("Open",false);
                open = false;
            }
            else
            {
                GetComponent<Animator>().SetBool("Open", true);
                open = true;
            }
        }
        if (locked)
        {
            //play sound locked
        }
    }
}