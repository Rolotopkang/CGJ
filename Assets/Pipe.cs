using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : ObjectOnClick {
    public PolygonCollider2D PolygonCollider2D;
    public BagManager BagManager;
    public DialogManager DialogManager;
    public GameObject finishiUI;
    private bool tydeOn =false;
    public Texture2D Texture2D;
    public ShadowChangeController ShadowChangeController;

    private void Update() {
        if (BagManager.IsHaveItem(HeldItem.SheetRope)) {
            PolygonCollider2D.enabled = true;
        }
    }

    private void OnMouseDown() {
        if(BagManager.IsHaveItem(HeldItem.SheetRope)&& !tydeOn && !ShadowChangeController.isShadow)
        {
            Sprite sp = Sprite.Create(Texture2D,SpriteRenderer.sprite.textureRect,new Vector2(0.5f,0.5f));
            SpriteRenderer.sprite = sp;
            DialogManager.OpenDialog(12,1);
            tydeOn = true;
        }else if (BagManager.IsHaveItem(HeldItem.SheetRope) && tydeOn && !ShadowChangeController.isShadow) {
            finishiUI.SetActive(true);
        }
    }
}
