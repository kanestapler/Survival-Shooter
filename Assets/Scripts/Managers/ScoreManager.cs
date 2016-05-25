using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
   
	private static int score;
	public Text scoreText;

    void Awake () {
		score = 0;
    }

    void Update () {
		scoreText.text = "Score: " + score.ToString ();
    }

	public void AddScore(int addition) {
		score += addition;
	}
}
