using UnityEngine;
using UnityEngine.Networking;
public class Arrow: NetworkBehaviour {

	public Rigidbody rb;
	private bool stuck = false;
	public float lifeTime;
	public float force;

	// Use this for initialization
	void Start() {
		if (!isServer) {
			return;
		}
				rb.velocity = transform.forward * force * 50;
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

		if(lifeTime <= 0.1f)
		return;

		if(coll.tag == "Arrow")
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