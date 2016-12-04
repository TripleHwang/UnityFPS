using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public AudioSource fireSound;
	public GameObject fireEffect,player;
	//public GameObject bullet;
	public Animator anim;
	//GameObject prebullet;
	//Vector3 bulletPosition;
	//Quaternion bulletRotate;
	float timer,reloadTimer;
    public float ammo;
    bool IsReload, IsShot;
	// Use this for initialization
	void Start () {
		//bullet.SetActive (false);
		timer = 0;
        ammo = 30;
        reloadTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(ammo<=0)
            fireEffect.SetActive(false);

        if (Input.GetKeyDown(KeyCode.R))
            IsReload = true;

        if (IsReload == true && IsShot != true)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer > 1.5f)
            {
                print("장전");
                reloadTimer = 0;
                IsReload = false;
                ammo = 30;
            }
        }

		//bulletPosition = new Vector3(player.transform.position.x, player.transform.position.y -0.115f , player.transform.position.z + 2f);
		//bulletRotate = player.transform.rotation;
		if (Input.GetMouseButton(0) && ammo>0) {
             IsShot = true;
			timer += Time.deltaTime;
			if (timer > 0.1f) {
                --ammo;
				/*bullet.SetActive (true);
				prebullet = (GameObject)Instantiate (bullet, bulletPosition, bulletRotate);
				prebullet.GetComponent<Rigidbody> ().AddForce (prebullet.transform.forward * 500);*/
                transform.Find("Aim").SendMessage("Shot");
				fireEffect.SetActive (true);
				fireSound.Play ();
				timer = 0;
			} else {
				fireEffect.SetActive (false);
				//bullet.SetActive (false);
			}
		}
        else
            IsShot = false;

		if(Input.GetMouseButton(1)){
			anim.SetBool("IsAim",true);
		} 
		else if(Input.GetMouseButtonUp(1)){
			anim.SetBool("IsAim",false);
		}
	}
}
