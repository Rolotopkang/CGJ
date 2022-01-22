using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simple : MonoBehaviour
{
    public float speed = 1;
    
    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles =new Vector3(0, 0, Mathf.PingPong(Time.time/speed, 20) - 10);
    }
}
