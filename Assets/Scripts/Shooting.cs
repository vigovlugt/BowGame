using UnityEngine;
using UnityEngine.Networking;
public class Shooting : NetworkBehaviour {
	
	[SerializeField]
	private GameObject arrow;

	[SerializeField]
	private Transform weaponHolder;

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0)){
			CmdFire();
		}
	}
	[Command]
    void CmdFire()
    {
		print("shoot");
		var arrowIns = (GameObject)Instantiate(arrow,weaponHolder.position,weaponHolder.rotation);

        // Add velocity to the bullet
        
		NetworkServer.Spawn(arrowIns);
    }
		
}
//aa