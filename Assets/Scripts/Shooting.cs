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
		RpcFire(weaponHolder.position,weaponHolder.rotation);
    }

	[ClientRpc]
	void RpcFire(Vector3 position, Quaternion rotation){
		var arrowIns = (GameObject)Instantiate(
            arrow,
            position,
            rotation);

        // Add velocity to the bullet
        arrowIns.GetComponent<Rigidbody>().velocity = arrowIns.transform.forward * 30;
	}
		
}
//aa