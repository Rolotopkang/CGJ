using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneScript : ObjectOnClick
{
    public BagManager BagManager;
    public DialogManager DialogManager;
    public int chapter;
    public int phrase;
    public ShadowChangeController ShadowChangeController;
    public GameObject littlestone;

    private void OnMouseDown() {
        if (ShadowChangeController.isShadow && BagManager.IsHaveItem(HeldItem.Gaozi)) {
            littlestone.SetActive(true);
            gameObject.SetActive(false);
        } else {
            DialogManager.OpenDialog(chapter,phrase);
        }
    }
}
