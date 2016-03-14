using UnityEngine;
using System.Collections;

public class Ghoul : MonoBehaviour {

	public GameObject DeathPoof;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.Q))
		{
			die();
		}
	
	}

	void OnCollisionEnter(Collision col)
	{

		if(col.collider.tag == "bullet")
		{
			print ("Dying");
			Destroy(col.gameObject);
			die();
		}


	}

	void die()
	{
		GameObject deathPoof = Instantiate(DeathPoof);
		deathPoof.transform.position = transform.position;
		Destroy(this.gameObject);
	}


}
