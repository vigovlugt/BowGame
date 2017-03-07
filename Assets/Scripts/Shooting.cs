using UnityEngine;
using UnityEngine.Networking;
public class Shooting : NetworkBehaviour {
	
	[SerializeField]
	private GameObject arrow;

	[SerializeField]
	private Transform weaponHolder;
	private float force;
	[SerializeField]
	private Camera cam;
	private float fov;
	void Start()
	{
		fov = cam.fieldOfView;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			if(force < 2){
			force += Time.deltaTime;
			
			}else{
				force = 2;
			}
			Debug.Log(force);
		}
		cam.fieldOfView = fov - force * 5;
		if(Input.GetMouseButtonUp(0)){
			if(force >= 0.5f){
			CmdFire(force);
			}
			force = 0f;
		}
	}
	[Command]
    void CmdFire(float force)
    {
		print("shoot");
		Vector3 pos = new Vector3(transform.position.x,transform.position.y + 0.8f,transform.position.z);

		GameObject arrowIns = (GameObject)Instantiate(arrow,pos,weaponHolder.rotation);
		Arrow arrowScript = arrowIns.GetComponent<Arrow>();
        // Add velocity to the bullet
		arrowScript.force = force;
		NetworkServer.Spawn(arrowIns);
		Destroy(arrowIns, 5.0f);
    }
		
}
//aa