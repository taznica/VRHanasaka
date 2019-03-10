using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	private Material material;
	private Material sakuraMaterial;
	private Texture image;
	private bool isSakura;

	UnityEngine.AI.NavMeshAgent agent;
	GameObject player;

	// Use this for initialization
	void Start () {
//		material = this.gameObject.transform.FindChild("Oak_Tree").gameObject.GetComponent<Renderer>().material;
//		sakuraMaterial = new Material(Shader.Find("Sakura"));
//		sakuraMaterial = Resources.Load("Sakura", typeof(Material)) as Material;
		image = Resources.Load("tree_diffuse_sakura") as Texture;

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");

		isSakura = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isSakura) {
			agent.SetDestination(player.transform.position);
		} else {
			agent.isStopped = true;
		}
	}

	private void ChangeColor(){
// ok pink //		transform.FindChild("Oak_Tree").gameObject.GetComponent<Renderer>().material = sakuraMaterial;
// ok white //		transform.FindChild("Oak_Tree").gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", image);
// ok white 
		transform.Find("Oak_Tree").gameObject.GetComponent<Renderer>().material.mainTexture = image;

		isSakura = true;
	}
}
