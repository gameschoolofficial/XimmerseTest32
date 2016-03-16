using UnityEngine;
using System.Collections;
using Ximmerse.CrossInput;

public class PunchGameManager : MonoBehaviour {

	public PunchBag[] PunchingBags;
	public int totalHits;
	[HideInInspector]public static PunchGameManager main;
	private bool firstTime = true;
	public int bagSelectPeriod;
	public GameObject Podium;

	private bool startedBoxing = false;

	// Use this for initialization
	void Awake () {
		main = this;
		totalHits = 0;
	
	}

	public void StartBoxing()
	{
		startedBoxing = true;
		Podium.gameObject.SetActive (false);
		StartCoroutine (switchSelectedPunchingBag (0));
	}
	
	// Update is called once per frame
	void Update () {
		 

		if (!startedBoxing && CrossInputManager.GetAxis ("Left_Trigger") > .8f && CrossInputManager.GetAxis ("Right_Trigger") > .8f)
			StartBoxing ();
		if (Input.GetKeyUp (KeyCode.T))
			StartBoxing ();
	
	}

	public void AddHits(int additionalHit)
	{
		totalHits += additionalHit;
	}



	IEnumerator switchSelectedPunchingBag(int lastBag)
	{
		int waitTime = 10;
		int nextBag = lastBag + 1;//Random.Range (1, PunchingBags.Length - 1);
		if (nextBag > PunchingBags.Length - 1)
			nextBag = 0;

		if (firstTime) {
			PunchingBags [0].enterSelected ();
			waitTime = 10;
			firstTime = false;
			lastBag = 0;
		} else {
			
		
			PunchingBags [nextBag].enterSelected ();
			waitTime = bagSelectPeriod;
		}

		yield return new WaitForSeconds (bagSelectPeriod);

		PunchingBags [lastBag].exitSelected ();
		StartCoroutine (switchSelectedPunchingBag (nextBag));
	}
}
