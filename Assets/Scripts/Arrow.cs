using UnityEngine;
using UnityEngine.Networking;
public class Arrow: NetworkBehaviour {

	public Rigidbody rb;
	private bool stuck = false;

	public float lifeTime;

	// Use this for initialization
	void Start() {
		if (!isServer) {
			return;
		}
				rb.velocity = transform.forward * 30;
	}
	void Update() {
		if(!stuck && rb.velocity != Vector3.zero){
		transform.rotation = Quaternion.LookRotation(rb.velocity);
		}
		lifeTime += Time.deltaTime;

		
	}
	void OnTriggerEnter(Collider coll)
	{
		if(stuck)
		return;

		if(lifeTime <= 0.3f)
		return;

		print(lifeTime);
		if(coll.gameObject.tag == "Player"){
			coll.gameObject.GetComponentInParent<Health>().TakeDamage(34);

		}

		stuck = true;
		rb.isKinematic = true;
		transform.SetParent(coll.transform);
	}

}