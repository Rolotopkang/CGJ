using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnMouseDown : ObjectOnClick {
    public BagManager BagManager;
    public DialogManager DialogManager;
    public HeldItem HeldItem;
    public bool addItem;
    public int chapter;
    public int phrase;
    
    private void OnMouseDown() {
        if (addItem) {
            BagManager.addItemToBag(HeldItem);
        }
        DialogManager.OpenDialog(chapter,phrase);
    }
}
