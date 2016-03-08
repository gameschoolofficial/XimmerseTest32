using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour {

	public Light[] Lights;
	private bool firstStart = true;
	public int InitialWaitTime;
	public int MinShootTime; 
	public int MaxShootTime;
	public float lowIntensity;

	public GhoulSpawns GhoulSpawner;


	// Use this for initialization
	void Start () {
		StartCoroutine (flickerTimer());

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator flickerTimer()
	{
		if (firstStart) {
			firstStart = false;
			yield return new WaitForSeconds(InitialWaitTime);
			print ("firstStart: " + firstStart);
		}
		print ("flickering");
		StartCoroutine (flickerLights());

		yield return new WaitForSeconds(Random.Range(MinShootTime, MaxShootTime));
		StartCoroutine (flickerTimer ());
	}

	IEnumerator flickerLights()
	{
		/*
		float elapsedTime = 1;

		while (elapsedTime > 0) {
			foreach (Light lite in Lights) {
				lite.intensity = Mathf.Lerp (1, 0, (elapsedTime / 1));
				elapsedTime -= Time.deltaTime;
			}
		}*/
		foreach (Light lite in Lights) {
		
			lite.intensity = lowIntensity;
		}
		yield return new WaitForSeconds (.5f);

		foreach (Light lite in Lights) {
			lite.intensity = 1;
		}
		yield return new WaitForSeconds (.5f);

		foreach (Light lite in Lights) {

			lite.intensity = lowIntensity;
		}

		yield return new WaitForSeconds (.5f);

		foreach (Light lite in Lights) {
			lite.intensity = 1;
		}
		GhoulSpawner.spawnGhouls ();
		yield return new WaitForSeconds (.5f);


	}
}
