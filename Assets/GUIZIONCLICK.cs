using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIZIONCLICK : ObjectOnClick
{
    public BagManager BagManager;
    public DialogManager DialogManager;
    public HeldItem HeldItem;
    public HeldItem HeldItem2;
    public bool addItem;
    public int chapter;
    public int phrase;
    private bool isOpen =false;
    public Texture2D Texture2D;
    
    
    private void OnMouseDown() {
        if (BagManager.IsHaveItem(HeldItem.Fuzi) && !isOpen) {
            isOpen = true;
            Sprite sp = Sprite.Create(Texture2D,SpriteRenderer.sprite.textureRect,new Vector2(0.5f,0.5f));
            SpriteRenderer.sprite = sp;
        }else if (isOpen) {
            if (addItem) {
                BagManager.AddItemToBag(HeldItem);
                BagManager.AddItemToBag(HeldItem2);
            }
        }
    }
}
