using UnityEngine;
using System.Collections;

public class PunchGameManager : MonoBehaviour {

	public PunchBag[] PunchingBags;
	public int totalHits;
	[HideInInspector]public static PunchGameManager main;
	private bool firstTime = true;
	public int bagSelectPeriod;

	// Use this for initialization
	void Awake () {
		main = this;
		totalHits = 0;
	
	}

	void Start()
	{
		StartCoroutine (switchSelectedPunchingBag (0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddHits(int additionalHit)
	{
		totalHits += additionalHit;
	}

	IEnumerator switchSelectedPunchingBag(int lastBag)
	{
		int waitTime = 10;
		int nextBag = Random.Range (0, PunchingBags.Length - 1);

		if (firstTime) {
			PunchingBags [0].enterSelected ();
			waitTime = 20;
			firstTime = false;
		} else {

			PunchingBags [lastBag].exitSelected ();
			PunchingBags [nextBag].enterSelected ();
			waitTime = bagSelectPeriod;
		}

		yield return new WaitForSeconds (bagSelectPeriod);
		StartCoroutine (switchSelectedPunchingBag (nextBag));
	}
}
