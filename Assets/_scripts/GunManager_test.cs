using UnityEngine;
using System.Collections;
//using Ximmerse.CrossInput;

public class GunManager_test : MonoBehaviour {

	public Rigidbody bulletPrefab;

	//public Transform rightHandMesh;
	//public Transform leftHandMesh;

	//turn on before sending to Charlie
	//private VirtualPose leftGun_pose; 
	//private VirtualPose rightGun_pose; 


	public Transform rightGunLocation;
	public Transform leftGunLocation;

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
	
		/*

		// Release trigger to fire another bullet
		if (CrossInputManager.GetButtonUp ("Left_Trigger")) {
		
			releaseLeftTrigger = true;
		}
		if (CrossInputManager.GetButtonUp ("Right_Trigger")) {
		
			releaseRightTrigger = true;
		}

		// Setting position for the guns
		leftGun_pose = CrossInputManager.VirtualPoseReference ("Left_Hand");
		leftGunLocation.rotation = leftGun_pose.rotation;
		leftGunLocation.position = leftGun_pose.position;

		rightGun_pose = CrossInputManager.VirtualPoseReference ("Right_Hand");
		rightGunLocation.rotation = rightGun_pose.rotation;
		rightGunLocation.position = rightGun_pose.position;


		//print ("leftGun_pose is "+leftGun_pose.position);
		//print ("RightGun_pose is " + rightGun_pose.position );


		// Setting up Reload functionality
		//controllers are never set to inactive, and are placed our of range.  
		// so using this as a location, we set that space as reload space. 
		if (leftGun_pose.position.y < -500)  {
		
			if (CrossInputManager.GetButtonDown ("Left_Trigger") && releaseLeftTrigger) {
				reload (0);
			}
		}

		if (rightGun_pose.position.y < -500) {
			if (CrossInputManager.GetButtonDown ("Right_Trigger") && releaseLeftTrigger) {				
				reload (1);
			}
		}

		//
		*/

		//reload for non-XImmerse



		if (Input.GetKeyUp(KeyCode.D)) {
				reload (0);
			}



		if (Input.GetKeyUp(KeyCode.K)) {	
				reload (1);
			}



		//Shoot weapons

		//if (CrossInputManager.GetButtonDown ("Left_Trigger") && releaseLeftTrigger) {
		if (Input.GetKeyUp(KeyCode.F)) {	
			if (leftGunAmmo > 0) {
				shoot (leftGunTip);
				leftGunAmmo--;
				releaseLeftTrigger = false;
			} else {
				print ("Reload Left !!!");
				//add Reload messaging
			}
		}

//		if (CrossInputManager.GetButtonDown ("Right_Trigger") && releaseRightTrigger) {
		if (Input.GetKeyUp(KeyCode.J)) {	
			if (rightGunAmmo > 0) {
				shoot (rightGunTip);
				rightGunAmmo--;
				releaseRightTrigger = false;
			} else {
				print ("Reload Right!!!");
				//
			}
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
			print ("Left Gun Reloaded");
		}
		if (gunHand == 1) {
			
			rightGunAmmo = totalAmmo;
			print ("Right Gun Reloaded");
		}
	}
}
