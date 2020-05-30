using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

    // Update is called once per frame
    [SerializeField]
    TextMeshProUGUI scoreText;
    void Update() {
        if (GameManager.Instance.getGameOver()) {
            gameObject.GetComponent<Canvas>().enabled = true;
        } else {
            gameObject.GetComponent<Canvas>().enabled = false;
        }
        scoreText.text = $"your score: {GameManager.Instance.getScore()}";

    }


    public void startGame() {
        GameManager.Instance.startGame();
    }
}
