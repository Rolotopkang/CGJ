using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectOnClick : MonoBehaviour{
    
    protected SpriteRenderer SpriteRenderer;

    private String defaltLayer;

    protected void Awake() {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        defaltLayer = SpriteRenderer.sortingLayerName;
    }

    protected void OnMouseEnter() {
        SpriteRenderer.material.SetFloat("_IsOutLine",1);
        SpriteRenderer.sortingLayerName = "HighLight";
    }

    protected void OnMouseExit() {
        SpriteRenderer.material.SetFloat("_IsOutLine",0);
        SpriteRenderer.sortingLayerName = defaltLayer;
    }
}
