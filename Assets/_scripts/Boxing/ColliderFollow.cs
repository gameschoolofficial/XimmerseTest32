using UnityEngine;
using System.Collections;

public class ColliderFollow : MonoBehaviour {

	public BoxCollider m_BoxCollider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		m_BoxCollider.center = transform.position;
	
	}
}
