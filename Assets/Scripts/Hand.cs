using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

	private List<Joycon> joycons;
	private Joycon joycon;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		joycons = JoyconManager.Instance.j;

		// joycon = joycons.Find(con => con.isLeft);
		joycon = joycons.Find(con => !con.isLeft);
	}
	
	// Update is called once per frame
	void Update () {
		if(joycons == null || joycons.Count <= 0){
			Debug.Log("null");
			return;
		}

		GetAngles();

		float accel = GetMagnitudeOfAccel();

//		Debug.Log(accel);

		if(accel >= 2.0f){
			ScatterAsh();
//			Debug.Log("Scatter");
		}
	}

	private void GetAngles(){
		var orientation = joycon.GetVector().eulerAngles;
		var angles = transform.localEulerAngles;

		angles.x = orientation.x;
		angles.y = orientation.z;
		angles.z = -orientation.y;

		transform.localEulerAngles = angles;
	}

	private float GetMagnitudeOfAccel(){
		var accelX = joycon.GetAccel().x;
		var accelY = joycon.GetAccel().y;
		var accelZ = joycon.GetAccel().z;

		Vector3 accel = new Vector3 (accelX, accelY, accelZ);

		return accel.magnitude;
//		return Mathf.Sqrt((accelX * accelX) + (accelY * accelY) + (accelZ * accelZ));
	}

	private void ScatterAsh(){
		Vector3 center = new Vector3 (Screen.width/2, Screen.height/2, 0);
		Ray ray = Camera.main.ScreenPointToRay(center);
		float distance = 50;

		if(Physics.Raycast(ray, out hit, distance)){
			if(hit.collider.tag == "Tree"){
				Debug.Log("***** hit! *****");
				hit.collider.SendMessage("ChangeColor");
			}
		}
	}


}
