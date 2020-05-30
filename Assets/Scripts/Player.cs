using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private int Jumpforce;
    [SerializeField]
    private float jumpRate = 1f;
    private float jumpCooldown;
    [SerializeField]
    private AudioClip jumpAudio;
    [SerializeField]
    private AudioClip deadAudio;
    [SerializeField]
    private AudioClip scoreAudio;



    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * 5;
        jumpCooldown = jumpRate;
    }

    // Update is called once per frame
    private void Update() {

        if (!GameManager.Instance.getGameOver())
            if (Input.GetButtonDown("Fire1") && jumpCooldown < Time.time) {
                playAudio(jumpAudio);
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * Jumpforce);
                jumpCooldown = Time.time + jumpRate;
            }

        Debug.Log(rb.velocity);

        transform.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0 + rb.velocity.y * 1.5f);
    }

    private void playAudio(AudioClip audio) {
        AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Pipe" || other.tag == "Collider") {
            playAudio(deadAudio);
            GameManager.Instance.setGameOver(true);
        }
        if (other.tag == "Score") {
            playAudio(scoreAudio);
            GameManager.Instance.addScore(0.5f);
        }
    }

}
