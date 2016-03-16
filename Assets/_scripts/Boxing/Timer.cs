using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text TimerText;
	public int TotalSeconds;
	public int timeLeft;

	// Use this for initialization
	void Start () {
		timeLeft = TotalSeconds;
		StartCoroutine (countdown ());
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	IEnumerator countdown()
	{
		timeLeft -= 1;
		updateTimerText ();
		yield return new WaitForSeconds (1);
		StartCoroutine (countdown ());

	}

	private void updateTimerText()
	{
		if (timeLeft > (TotalSeconds - 20))
			TimerText.text = "Hit the Red Bag! Time Left: " + timeLeft;
		else
			TimerText.text = "Time Left: " + timeLeft;

		if (timeLeft <= 0)
			TimerText.text = "Final Score: " + PunchGameManager.main.totalHits;
	}
}
