using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerScript : NetworkBehaviour {

	private GameObject[] nameplates;
	[SerializeField]private Camera cam;

	// Use this for initialization
	void Start () {
		if(!isLocalPlayer)
		return;
		nameplates = GameObject.FindGameObjectsWithTag("Nameplate");
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer)
		return;
		for (int i = 0; i < nameplates.Length; i++)
		{
			print (nameplates[i]);
			nameplates[i].transform.rotation = Quaternion.LookRotation(cam.transform.position);
		}
	}
}
