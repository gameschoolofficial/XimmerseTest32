using UnityEngine;
using System.Collections;

public class target : MonoBehaviour {

	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter(Collision collision){

		Instantiate (explosionPrefab, transform.position, transform.rotation);
		print ("Target Hit");
		//Destroy (gameObject);
	}
}
