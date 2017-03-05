using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Health: NetworkBehaviour {
   public int maxHealth = 100;
   public int curHealth = 100;

   public bool destroyOnDeath = false;
   private NetworkStartPosition[] spawnPoints;

   void Start(){
	   if(!isLocalPlayer)
	   return;

	  spawnPoints = FindObjectsOfType<NetworkStartPosition>();
   }
   void Update(){
		if(Input.GetKey(KeyCode.Backspace)){
		Respawn();
		}

	if(!isLocalPlayer){
		return;
	}

	if (curHealth <= 0)
        {
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            } 
            else
            {
                curHealth = maxHealth;

                // called on the Server, invoked on the Clients
                Respawn();
            }
		}


   }
   public void TakeDamage(int amount){
	   if(!isLocalPlayer)
	   return;
	   
	   curHealth -= amount;

   }
   public void Respawn(){
	   if(!isLocalPlayer)
	   return;
		transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;

   }
}