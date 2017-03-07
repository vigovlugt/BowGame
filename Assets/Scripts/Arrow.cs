using UnityEngine;
using UnityEngine.Networking;
public class Arrow: NetworkBehaviour {

	public Rigidbody rb;
	private bool stuck = false;

	// Use this for initialization
	void Start() {
		if (!isServer) {
			return;
		}
		
	}
	void Update() {

		if(!stuck && rb.velocity != Vector3.zero){
		transform.rotation = Quaternion.LookRotation(rb.velocity);
		}
	}
	void OnTriggerEnter(Collider coll)
	{

		if(stuck)
		return;

		if(coll.gameObject.tag == "Player"){
			coll.gameObject.GetComponentInParent<Health>().TakeDamage(34);

		}

		stuck = true;
		rb.isKinematic = true;
		transform.SetParent(coll.transform);
	}

}