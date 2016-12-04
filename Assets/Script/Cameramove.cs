using UnityEngine;
using System.Collections;

public class Cameramove : MonoBehaviour {

	public Vector3 cameraVector;
	public int turnspeed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		cameraVector = new Vector3 (-Input.GetAxis("Mouse Y"), 0, 0);
		transform.Rotate (cameraVector * turnspeed);
	}
}
