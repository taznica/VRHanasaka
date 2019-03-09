using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconScript : MonoBehaviour {

	private List<Joycon> joycons;
	private Joycon joycon;

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
	}

	private void GetAngles(){
		var orientation = joycon.GetVector().eulerAngles;
		var angles = transform.localEulerAngles;

		angles.x = orientation.x;
		angles.y = orientation.z;
		angles.z = -orientation.y;

		transform.localEulerAngles = angles;
	}
}
