using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PunchBag : MonoBehaviour {
	public bool selected;
	public int pointsGained;
	public int hits = 0;

	public Material Red;
	public Material Neutral;
	public Text myScoreText;
	public AudioSource hitSound;
	public AudioSource bellSound;

	// Use this for initialization
	void Start () {
		updateMyScoreMeter ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	void OnCollisionExit(Collision col)
	{
		print ("collision");
		if (selected) {
			hits++;
			playPunch ();
			updateMyScoreMeter ();
		}
	}

	public void enterSelected()
	{
		selected = true; 
		//color = red;
		GetComponent<Renderer>().material = Red;
		playBell ();
	}

	public void exitSelected()
	{
		selected = false;
		//color = none;
		GetComponent<Renderer>().material = Neutral;
	}

	private void updateMyScoreMeter()
	{
		myScoreText.text = "Hits: " + hits;
	}

	private void playPunch()
	{
		hitSound.time = .17f;
		hitSound.Play ();
	}
	public void playBell()
	{
		bellSound.Play ();
	}
}
