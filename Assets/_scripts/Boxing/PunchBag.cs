using UnityEngine;
using System.Collections;

public class PunchBag : MonoBehaviour {
	public bool selected;
	public int pointsGained;
	public int hits;

	public Material Red;
	public Material Neutral;

	// Use this for initialization
	void Start () {
		enterSelected ();
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	void OnCollisionExit(Collision col)
	{
		print ("collision");
		if (selected) {
			pointsGained += 100;
			hits++;
		}
	}

	void enterSelected()
	{
		selected = true; 
		//color = red;
		GetComponent<Renderer>().material = Red;
	}

	void exitSelected()
	{
		selected = false;
		//color = none;
		GetComponent<Renderer>().material = Neutral;
	}
}
