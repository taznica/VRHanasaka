using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private int score;
	public Text scoreLabel;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreLabel.text = "Sakura : " + score.ToString();
	}

	private void IncrementScore(){
		score++;
	}
}
