using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartClick : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        this.GetComponent<Button>().onClick.AddListener(clicked);
    }

    // Update is called once per frame
    void Update() {

    }
    void clicked() {
        SceneManager.LoadScene("MainScene");
    }
}
