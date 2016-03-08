using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SpawnGhoul(GameObject ghoul)
	{
		GameObject myGhoul = Instantiate (ghoul);
		myGhoul.transform.position = transform.position;
	}
}
