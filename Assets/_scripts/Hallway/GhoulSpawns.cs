using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GhoulSpawns : MonoBehaviour {

	public Spawner[] frontSpawners;
	public Spawner[] backSpawners;
	public bool spawnFromAnywhere;
	private List<Spawner> allSpawners = new List<Spawner>();

	public GameObject AngryGhoul;
	public GameObject ScaryGhoul;


	// Use this for initialization
	void Awake () {
		foreach (Spawner s in frontSpawners) {
			allSpawners.Add (s);
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void spawnGhouls()
	{
		GameObject chosenGhoul;
		if (Random.Range (0, 1) > 0)
			chosenGhoul = AngryGhoul;
		else
			chosenGhoul = ScaryGhoul;

		int chosenSpawner = Random.Range (0, allSpawners.Count-1);
		allSpawners [chosenSpawner].SpawnGhoul ( chosenGhoul);
	}
}
