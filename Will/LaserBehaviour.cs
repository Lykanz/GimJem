using UnityEngine;
using System.Collections;

public class LaserBehaviour : MonoBehaviour {

	Rigidbody rb3d;

	// Use this for initialization
	void Start () {
		rb3d = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = (Input.mousePosition - rb3d.transform.position).normalized;
		rb3d.AddForce (dir * 5.0f);
	}
}
