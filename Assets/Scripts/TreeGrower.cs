using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrower : MonoBehaviour {

	private float time;
	private float timeOut;
	public GameObject tree;

	private float radius;

	// Use this for initialization
	void Start () {
		timeOut = 5.0f;
		radius = 24.0f;
		Grow(radius);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if(time >= timeOut){
			time = 0.0f;
			radius--;
			Grow(radius);
		}
	}

	private void Grow(float radius){
		Vector3 point = GetRandomPointOnCircle(radius);
		Instantiate(tree, transform.position - point, Quaternion.identity);
		Debug.Log(point);
	}

	private Vector3 GetRandomPointOnCircle(float radius){
		float deg = Random.Range(0.0f, 360.0f);
		float rad = deg * Mathf.Deg2Rad;
		float x = Mathf.Cos(rad) * radius;
		float z = Mathf.Sin(rad) * radius;

		return new Vector3(x, 0, z);
	}
}
