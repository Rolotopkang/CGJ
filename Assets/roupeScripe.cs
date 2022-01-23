using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roupeScripe : ObjectOnClick
{
    public BagManager BagManager;
    public DialogManager DialogManager;
    public ShadowChangeController ShadowChangeController;

    private void OnMouseDown() {
        if (!ShadowChangeController.isShadow) {
            BagManager.AddItemToBag(HeldItem.SheetRope);
            gameObject.SetActive(false);
            DialogManager.OpenDialog(11,2);
        } else {
            DialogManager.OpenDialog(11,3);
        }
    }
}
