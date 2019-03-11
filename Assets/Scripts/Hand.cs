using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hand : MonoBehaviour {

	private List<Joycon> joycons;
	private Joycon joycon;
	public GameObject ash;
	RaycastHit hit;

	private bool didScattered;

	// Use this for initialization
	void Start () {
		joycons = JoyconManager.Instance.j;

		// joycon = joycons.Find(con => con.isLeft);
		joycon = joycons.Find(con => !con.isLeft);

		didScattered = false;
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

		// prevent calling ScatterAsh() more than once by using didScattered
		if(accel >= 2.0f && didScattered == false){
			ScatterAsh();
//			Debug.Log("Scatter");
			didScattered = true;
		}

		if(accel < 2.0f){
			didScattered = false;
		}

		if(joycon.GetButtonDown(Joycon.Button.DPAD_UP)){
			Retry();
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
		float distance = 10;
		MakeRumble();

		GameObject ashObject = Instantiate(ash, transform.position, Quaternion.identity);
//		ashObject.transform.LookAt(this.transform.position);
		Vector3 forward = new Vector3(-this.transform.forward.x, this.transform.forward.y, -this.transform.forward.z);
		ashObject.transform.rotation = Quaternion.LookRotation(forward);

		if(Physics.Raycast(ray, out hit, distance)){
			// prevent calling ChangeColor when isSakura == true
			if(hit.collider.tag == "Tree" && hit.collider.GetComponent<Treee>().isSakura == false){
				Debug.Log("***** hit! *****");
				hit.collider.SendMessage("ChangeColor");
			}
		}
	}

	private void MakeRumble(){
		joycon.SetRumble(0, -100.0f, 5.0f, 50);
	}

	private void Retry(){
		Debug.Log("RETRY");
		Scene scene = SceneManager.GetActiveScene();
//		SceneManager.LoadScene(scene.name);
		Debug.Log(scene.name);
	}
}
