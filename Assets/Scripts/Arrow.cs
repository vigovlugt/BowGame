using UnityEngine;
using UnityEngine.Networking;
public class Arrow: NetworkBehaviour {

	public Rigidbody rb;
	private bool stuck = false;

	public GameObject shooter;

	// Use this for initialization
	void Start() {
		if (!isServer) {
			return;
		}
		rb.AddForce(shooter.GetComponentInChildren<Camera>().transform.forward * 30, ForceMode.Impulse);
		
	}
	void Update() {
		if (!isServer) {
			return;
		}

		if(!stuck && rb.velocity != Vector3.zero){
		transform.rotation = Quaternion.LookRotation(rb.velocity);
		}
	}
	void OnTriggerEnter(Collider coll)
	{
		if(stuck)
		return;

		if (!isServer) {
			return;
		}

		if(coll.gameObject.tag == "Player"){
			coll.gameObject.GetComponentInParent<Health>().TakeDamage(34);
			Debug.Log("Triggered");
		}

		stuck = true;
		rb.isKinematic = true;
		transform.SetParent(coll.transform);
	}

}