using UnityEngine;
using System.Collections;

public class TargetObject : MonoBehaviour {

	public GameObject explosionPrefab;

	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter(Collision col){

		if (col.gameObject.tag == "Bullet") {
		
			print ("Bullet hit this object");
		}
		print ("onCollisionEnter Hit");
		Instantiate (explosionPrefab, transform.position, transform.rotation);

		//Destroy (gameObject);
	}

	void onTriggerEnter(Collision col){
		
		if (col.gameObject.tag == "Bullet") {
			
			print ("Bullet hit this object");
		}
		print ("onTriggerEnter Hit");
		Instantiate (explosionPrefab, transform.position, transform.rotation);
		
		//Destroy (gameObject);
	}


}
