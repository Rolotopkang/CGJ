using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class littleStoneScript : ObjectOnClick
{
    public BagManager BagManager;
    public DialogManager DialogManager;
    public int chapter;
    public int phrase;
    public ShadowChangeController ShadowChangeController;

    private void OnMouseDown() {
        if (!ShadowChangeController.isShadow) {
            BagManager.AddItemToBag(HeldItem.Stone);
            gameObject.SetActive(false);
        } else {
            DialogManager.OpenDialog(chapter,phrase);
        }
    }
}
