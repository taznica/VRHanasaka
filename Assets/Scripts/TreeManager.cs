using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {

	private Material material;
	private Material sakuraMaterial;
	private Texture image;

	// Use this for initialization
	void Start () {
//		material = this.gameObject.transform.FindChild("Oak_Tree").gameObject.GetComponent<Renderer>().material;
//		sakuraMaterial = new Material(Shader.Find("Sakura"));
		sakuraMaterial = Resources.Load("Sakura", typeof(Material)) as Material;
		image = Resources.Load("tree_diffuse_sakura") as Texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void ChangeColor(){
// ok pink //		transform.FindChild("Oak_Tree").gameObject.GetComponent<Renderer>().material = sakuraMaterial;
// ok white //		transform.FindChild("Oak_Tree").gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", image);
// ok white //		transform.FindChild("Oak_Tree").gameObject.GetComponent<Renderer>().material.mainTexture = image;
	}
}
