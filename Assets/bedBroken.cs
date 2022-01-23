using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedBroken : MonoBehaviour {
    private SpriteRenderer SpriteRenderer;
    public Texture2D Texture2D;
    public GameObject roup;
    public PolygonCollider2D PolygonCollider2D;

    private void Awake() {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("stone")) {
            other.gameObject.SetActive(false);
            Sprite sp = Sprite.Create(Texture2D,SpriteRenderer.sprite.textureRect,new Vector2(0.5f,0.5f));
            SpriteRenderer.sprite = sp;
            PolygonCollider2D.enabled = false;
            roup.SetActive(true);
        }
    }
    
}
