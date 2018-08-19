using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public BoundaryController bc;
    public GameObject bt;
    public GameObject bl;
    public GameObject br;

    public DeathMenu deathScreen;

    public Transform gc;
    private Vector3 _gcStart;

    public PlayerController player;
    private Vector3 _playerSpawn;

    private Destroy[] _platformList;

    public Text scoreText;
    public Text highScoreText;

    public float score;
    public float highScore;

    private float _pointsPerSec = 5;

    public bool isScoreIncreasing;


    void Start(){
        bc = FindObjectOfType<BoundaryController>();

        _gcStart = gc.position;
        _playerSpawn = player.transform.position;

        isScoreIncreasing = true;
        if(PlayerPrefs.GetFloat("HighScore") != null) {
            highScore = PlayerPrefs.GetFloat("HighScore");
        }

        deathScreen.gameObject.SetActive(false);
    }
	void Update(){
        Scoring();
    }

    void Scoring(){
        //score over time
        if (isScoreIncreasing){
            score += _pointsPerSec * Time.deltaTime;
        }

        //high score
        if (score > highScore){
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }

        //displays scores
        scoreText.text = "Score: " + Mathf.Round(score);
        highScoreText.text = "High Score: " + Mathf.Round(highScore);
    }

    public void RestartGame(){
        isScoreIncreasing = false;
        player.gameObject.SetActive(false);
        bc.isMovingBoundaries = false;

        deathScreen.gameObject.SetActive(true);
    }
    public void Reset(){
        //boundaries
        bc.isResetBoundaries = true;
        bt.transform.localScale = new Vector3(bt.transform.localScale.x, 1, bt.transform.localScale.z);
        br.transform.localScale = new Vector3(1, br.transform.localScale.y, br.transform.localScale.z);
        bl.transform.localScale = new Vector3(1, bl.transform.localScale.y, bl.transform.localScale.z);

        //hazards
        

        deathScreen.gameObject.SetActive(false);
        _platformList = FindObjectsOfType<Destroy>();
        for (int i = 0; i < _platformList.Length; i++){
            _platformList[i].gameObject.SetActive(false);
        }
        player.transform.position = _playerSpawn;
        gc.position = _gcStart;
        bc.isResetBoundaries = false;
        StartCoroutine(bc.Wait());
        player.gameObject.SetActive(true);
        score = 0;
        isScoreIncreasing = true;
    }
}
