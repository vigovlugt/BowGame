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
        // Create the Bullet from the Bullet Prefab
        var arrowIns = (GameObject)Instantiate(
            arrow,
            weaponHolder.position,
            weaponHolder.rotation);

        // Add velocity to the bullet
        arrowIns.GetComponent<Rigidbody>().velocity = arrowIns.transform.forward * 6;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(arrow);
    }
		
}
//aa