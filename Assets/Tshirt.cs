using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tshirt : ObjectOnClick
{
    public BagManager BagManager;
    public DialogManager DialogManager;
    public HeldItem HeldItem;
    public bool addItem;
    public int shadowChapter;
    public int shadowPhrase;
    public int chapter;
    public int phrase;
    public Texture2D Texture2D;
    public ShadowChangeController ShadowChangeController;
    
    private void OnMouseDown() {
        if (ShadowChangeController.isShadow) {
            Sprite sp = Sprite.Create(Texture2D,SpriteRenderer.sprite.textureRect,new Vector2(0.5f,0.5f));
            SpriteRenderer.sprite = sp;
            // if (addItem) {
            //     BagManager.addItemToBag(HeldItem);
            // }
            // DialogManager.OpenDialog(shadowChapter,shadowPhrase);
        } else {
            DialogManager.OpenDialog(chapter,phrase);
        }
    }
}
