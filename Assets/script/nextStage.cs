using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextStage : MonoBehaviour {

	gerak komponenGerak;

	// Use this for initialization
	void Start () {
		komponenGerak = GameObject.Find("player").GetComponent<gerak>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Player" && komponenGerak.koin == 9) {
			Application.LoadLevel (2);
		}
	}
}
