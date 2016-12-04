using UnityEngine;
using System.Collections;

public class FirstPerson : MonoBehaviour {

	public CharacterController CC;
    public int movespeed, turnspeed,Hp;
	public Vector3 playerVector;
    bool isMove;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		playerVector = new Vector3 (0, Input.GetAxis ("Mouse X"), 0);

		transform.Rotate (playerVector * turnspeed);

		if(Input.GetKey(KeyCode.W)){
			CC.Move(transform.forward * movespeed * Time.deltaTime);
            GameObject.Find("Gun").GetComponent<Fire>().anim.SetBool("IsMove", true);
		}
		if(Input.GetKey(KeyCode.S)){
			CC.Move(transform.forward * -1  * movespeed * Time.deltaTime);
            GameObject.Find("Gun").GetComponent<Fire>().anim.SetBool("IsMove", true);
		}
		if(Input.GetKey(KeyCode.A)){
			CC.Move(transform.right * -1 * movespeed * Time.deltaTime);
            GameObject.Find("Gun").GetComponent<Fire>().anim.SetBool("IsMove", true);
		}
		if(Input.GetKey(KeyCode.D)){
			CC.Move(transform.right * movespeed * Time.deltaTime);
            GameObject.Find("Gun").GetComponent<Fire>().anim.SetBool("IsMove", true);
		}


        if (Input.GetKeyUp(KeyCode.W))
        {
            CC.Move(transform.forward * movespeed * Time.deltaTime);
            GameObject.Find("Gun").GetComponent<Fire>().anim.SetBool("IsMove", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            CC.Move(transform.forward * -1 * movespeed * Time.deltaTime);
            GameObject.Find("Gun").GetComponent<Fire>().anim.SetBool("IsMove", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            CC.Move(transform.right * -1 * movespeed * Time.deltaTime);
            GameObject.Find("Gun").GetComponent<Fire>().anim.SetBool("IsMove", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            CC.Move(transform.right * movespeed * Time.deltaTime);
            GameObject.Find("Gun").GetComponent<Fire>().anim.SetBool("IsMove", false);
        }
	
	}
    void Hit()
    {
        Hp -= 5;
        print(Hp);
        if (Hp <= 0)
            Application.LoadLevel("DeadScene");
    }
}
