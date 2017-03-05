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
			CmdFire();
		}
	}

	[Command]
	void CmdFire(){
		GameObject arrow = (GameObject)Instantiate(Arrow,weaponHolder.transform.position,weaponHolder.transform.rotation);
		arrow.GetComponent<Arrow>().shooter = gameObject;
		Physics.IgnoreCollision(GetComponentInChildren<Collider>(),arrow.GetComponent<Collider>());
		NetworkServer.Spawn(arrow);
		
		
    
	}

}
