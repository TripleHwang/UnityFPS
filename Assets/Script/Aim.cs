using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {
    RaycastHit hit;
    Vector3 fwd;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd, Color.green);
	}
    public void Shot()
    {
        int layerMask = (-1) - ((1 << LayerMask.NameToLayer("Ground")));
        Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity,layerMask);
        if (hit.collider)
        {
            if(hit.collider.tag=="Enemy")
                hit.collider.gameObject.SendMessage("Attacked");   
        }
    }
}