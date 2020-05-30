using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [Header("Game Setting")]
    [SerializeField]
    private bool isGameOver;
    [SerializeField]
    private Pipe pipePf;
    [SerializeField]
    private Transform spawnPosition;
    [Header("Spawn inverval time")]
    [SerializeField]
    private float minSpawnIntervalTime;
    [SerializeField]
    private float maxSpawnIntervalTime;
    [Header("Random Spawn position")]
    [SerializeField, Range(-1.5f, 1.5f)]
    private float minAddPosition;
    [SerializeField, Range(-1.5f, 1.5f)]
    private float maxAddPosition;
    [Header("Score")]
    [SerializeField]
    private float score = 0;

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameManager>();

                if (_instance == null) {
                    GameObject container = new GameObject("Game Manager");
                    _instance = container.AddComponent<GameManager>();
                }
            } else {
            }

            return _instance;
        }
    }
    #endregion

    private void Awake() {

        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        if (isGameOver) {

            StopAllCoroutines();
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
    }


    // Update is called once per frame

    public void startGame() {
        SceneManager.LoadScene(0);
        score = 0;
        isGameOver = false;
        StartCoroutine(spawnPipe(minSpawnIntervalTime, maxSpawnIntervalTime));
    }


    private void Update() {
        if (isGameOver) {

            StopAllCoroutines();
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }

    }

    IEnumerator spawnPipe(float min, float max) {
        while (true) {

            var spawnIntervalTime = Random.Range(min, max);
            var randomPosition = Random.Range(minAddPosition, maxAddPosition);
            yield return new WaitForSeconds(spawnIntervalTime);
            Instantiate(pipePf, new Vector2(spawnPosition.position.x, spawnPosition.position.y + randomPosition), Quaternion.identity);
            Instantiate(pipePf, new Vector2(spawnPosition.position.x, -spawnPosition.position.y + randomPosition), Quaternion.Euler(180, 0, 0));
        }
    }

    public bool getGameOver() {
        return isGameOver;
    }

    public void setGameOver(bool v) {
        isGameOver = v;
    }
    public float getScore() {
        return score;
    }

    public void addScore(float v) {
        score += v;
    }
}
