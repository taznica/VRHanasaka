using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public int health;
	public Text healthLabel;
	public Text gameOverLabel;

	// Use this for initialization
	void Start () {
		health = 3;
	}

	// Update is called once per frame
	void Update () {
		healthLabel.text = "Health : " + health.ToString() + " / 3";
	}

	private void DecrementHealth(){
		health--;
		if(health <= 0){
			GameOver();
		}
	}

	private void GameOver(){
		// visible gameOverLabel
		gameOverLabel.text = "Game Over\nPress A to retry.";

		// stop growing
		Time.timeScale = 0;

		// destroy trees which is not sakura
		GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
		foreach(GameObject tree in trees){
			if(!tree.GetComponent<Treee>().isSakura){
				Destroy(tree);
			}
		}
	}
}
