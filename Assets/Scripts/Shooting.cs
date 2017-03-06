using UnityEngine;
using UnityEngine.Networking;
public class Shooting : NetworkBehaviour {
	
	[SerializeField]
	private GameObject Arrow;

	[SerializeField]
	private GameObject weaponHolder;

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0)){
			Fire();
		}
	}

	void Fire(){
		GameObject arrow = (GameObject)Instantiate(Arrow,weaponHolder.transform.position,weaponHolder.transform.rotation);
		Arrow arrowScript = arrow.GetComponent<Arrow>();
		arrowScript.shooter = gameObject;
		arrowScript.shooterCam = Camera.main.transform;
		CmdFire(arrow);
	}


	[Command]
	void CmdFire(GameObject arrow){
		NetworkServer.SpawnWithClientAuthority(arrow,gameObject);
		
	}

}
