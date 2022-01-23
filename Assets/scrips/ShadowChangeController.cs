using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ShadowChangeController : MonoBehaviour {
    
    public GameObject Player;
    public GameObject Shadow;
    public CinemachineVirtualCamera cm;
    public GameObject ShadowGlobalLight;
    public GameObject groundGlobalLight;
    public bool isShadow =false;
    [SerializeField] private bool playerIn;

    private playerController PlayerController;
    private playerController ShadowController;

    private void Awake() {
        PlayerController = Player.GetComponent<playerController>();
        ShadowController = Shadow.GetComponent<playerController>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)&& playerIn) {
            ChangeCharactor();
        }
    }

    private void OnTriggerEnter2D(Collider2D actor) {
        if (actor.gameObject.tag.Equals("player") && 
            actor.gameObject.GetComponent<playerController>().isCurrentPlayer) {
            playerIn = true;
            Shadow.gameObject.SetActive(true);
            Shadow.transform.localPosition = new Vector3(
                actor.gameObject.transform.position.x,
                Shadow.transform.position.y,
                Shadow.transform.position.z);
            Shadow.GetComponent<playerController>().isCurrentPlayer = true;
        }

        if (actor.gameObject.tag.Equals("shadow") &&
            actor.gameObject.GetComponent<playerController>().isCurrentPlayer) {
            playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D actor) {
        if (actor.gameObject.tag.Equals("player")&& 
            actor.gameObject.GetComponent<playerController>().isCurrentPlayer) {
            playerIn = false;
            Shadow.GetComponent<playerController>().isCurrentPlayer = false;
            Shadow.gameObject.SetActive(false);
        }

        if (actor.gameObject.tag.Equals("shadow") &&
            actor.gameObject.GetComponent<playerController>().isCurrentPlayer) {
            playerIn = false;
        }
    }

    public void ChangeCharactor() {
        if (!isShadow) {
            PlayerController.isCurrentPlayer = false;
            ShadowController.isCurrentPlayer = true;
            ShadowController.isInputTurn = true;
            isShadow = true;
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            cm.Follow = Shadow.transform;
            cm.m_Lens.Dutch = Mathf.Lerp(0,180,Time.time*3);
            ShadowGlobalLight.SetActive(true);
            groundGlobalLight.SetActive(true);
        } 
        else 
        {
            PlayerController.isCurrentPlayer = true;
            ShadowController.isCurrentPlayer = true;
            ShadowController.isInputTurn = false;
            isShadow = false;
            Player.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePosition;
            Shadow.transform.localPosition = new Vector3(
                Player.transform.position.x,
                Shadow.transform.position.y,
                Shadow.transform.position.z);
            cm.Follow = Player.transform;
            cm.m_Lens.Dutch = Mathf.Lerp(180,0,Time.time*3);
            ShadowGlobalLight.SetActive(false);
            groundGlobalLight.SetActive(false);
        }
    }
}
