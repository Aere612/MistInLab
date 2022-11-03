using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactions : MonoBehaviour
{
    int layerMask;
    RaycastHit hit;
    public GameObject Player,Screen;
    private void Start()
    {
        layerMask = 1 << 2;
        layerMask = ~layerMask;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out  hit, 15, layerMask) ;
            if (hit.transform.tag == "Screen")
            {
                Screen.SetActive(true);
                Player.GetComponent<pm>().enabled=false;
                GetComponent<interactions>().enabled = false;
            }
        }
    }
}
