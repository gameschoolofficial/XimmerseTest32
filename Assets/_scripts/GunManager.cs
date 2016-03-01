using UnityEngine;
using System.Collections;
using Ximmerse.CrossInput;

public class GunManager : MonoBehaviour {

	public Rigidbody bulletPrefab;
	public Transform rightGunTip;
	public Transform leftGunTip;

	public int gunspeed;
	public int totalAmmo;

	private int leftGunAmmo;
	private int rightGunAmmo;

	private bool releaseLeftTrigger = true;
	private bool releaseRightTrigger = true;

	// Use this for initialization
	void Start () {

		leftGunAmmo = totalAmmo;
		rightGunAmmo = totalAmmo;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (CrossInputManager.GetButtonUp ("Left_Trigger")) {
		
			releaseLeftTrigger = true;
		}
		if (CrossInputManager.GetButtonUp ("Right_Trigger")) {
		
			releaseRightTrigger = true;
		}

		if (CrossInputManager.GetButtonDown ("Left_Trigger") && releaseLeftTrigger){

			if(leftGunAmmo > 0){
				shoot (leftGunTip);
				leftGunAmmo--;
				releaseLeftTrigger = false;
			} else {
				print ("Reload!!!");
			}
		}

		if (CrossInputManager.GetButtonDown ("Right_Trigger") && releaseRightTrigger){
			
			shoot (rightGunTip);
			rightGunAmmo--;
			releaseRightTrigger = false;
		}

	}

	public void shoot(Transform barrelEnd){
	
		Rigidbody bulletInstance;
		bulletInstance = Instantiate(bulletPrefab, barrelEnd.position, barrelEnd.rotation ) as Rigidbody;
		bulletInstance.AddForce(barrelEnd.forward * gunspeed);
		//print ("shooting bullet");
	}

	public void reload(int gunHand){
	
		//add 
		if (gunHand == 0) {
		
			leftGunAmmo = totalAmmo;
		}
		if (gunHand == 1) {
			
			rightGunAmmo = totalAmmo;
		}
	}
}
