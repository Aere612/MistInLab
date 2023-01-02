using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBolt : MonoBehaviour
{
    public int a = 0;
    public bool triggered = false,open=true;
    //DeadBoltHinge
    void Update()
    {
        if (triggered)
        {
            if (open)
            {
                a = 0;
                while (a <= 90) {
                    GameObject.Find("DeadBoltHinge").transform.Rotate(new Vector3(0f, 1f, 0f));
                    a++;
                }
            }
            else
            {
                a = 0;
                while (a <= 90)
                {
                    GameObject.Find("DeadBoltHinge").transform.Rotate(new Vector3(0f, -1f, 0f));
                    a++;
                }
            }
        }
    }
}
