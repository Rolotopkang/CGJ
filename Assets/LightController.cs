using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : ObjectOnClick {
    public GameObject LightEffect;
    private bool isOn = false;
    
    private void OnMouseDown() {
        if (isOn) {
            LightEffect.SetActive(false);
            isOn = false;
        } else {
            LightEffect.SetActive(true);
            isOn = true;
        }
        
    }
}
