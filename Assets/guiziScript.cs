using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class guiziScript : MonoBehaviour {
    public PolygonCollider2D guiziCollider2D;
    public CinemachineVirtualCamera Camera;
    public Transform FocusPoint;
    private GameObject currentPlayer;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.tag.Equals("player")) {
            currentPlayer = other.gameObject;
            Camera.Follow = FocusPoint;
            Invoke("ReturnFollow",1.5f);
        }
        
        if (other.gameObject.tag.Equals("shadow")) {
            currentPlayer = other.gameObject;
            guiziCollider2D.enabled = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag.Equals("shadow")) {
            guiziCollider2D.enabled = false;
        }
    }

    private void ReturnFollow() {
        Camera.Follow = currentPlayer.transform;
    }
}
