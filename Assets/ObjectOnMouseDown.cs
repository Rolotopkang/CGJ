using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectOnMouseDown : ObjectOnClick {
    public BagManager BagManager;
    public DialogManager DialogManager;
    public ShadowChangeController ShadowChangeController;
    public GameObject shadow;
    public GameObject prefab;


    private void OnMouseDown() {
        if (BagManager.IsHaveItem(HeldItem.Stone) && !ShadowChangeController.isShadow) {
            DialogManager.OpenDialog(11,1);
        }
        else if(BagManager.IsHaveItem(HeldItem.Stone) && ShadowChangeController.isShadow) {
            Instantiate(prefab, shadow.transform.position, quaternion.identity);
        } else {
            DialogManager.OpenDialog(1,1);
        }
    }
}
