using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	
	[SerializeField] private float speed = 10.0f;
	[SerializeField] private float jumpForce = 400.0f;
	private bool grounded;
	private Rigidbody rb3d;
	//public static int nextLevel; //Decides the next level to load
	public GameObject laserProj;

	void OnCollisionEnter(Collision col)
	{
		grounded = true;
	}

	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.tag == "PortalEF" && Input.GetKey ("e")) {
			Application.LoadLevel(2);
		}
		
		if (col.gameObject.tag == "PortalS" && Input.GetKey ("e")) {
			Application.LoadLevel(3);
		}
		
		if (col.gameObject.tag == "PortalC" && Input.GetKey ("e")) {
			Application.LoadLevel(4);
		}
	}

	// Use this for initialization
	void Start () {
		rb3d = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D)) {
			Vector3 temp = transform.position;
			temp.x += speed * Time.deltaTime;
			rb3d.transform.position = temp;
		}

		if (Input.GetKey (KeyCode.A)) {
			Vector3 temp = transform.position;
			temp.x -= speed * Time.deltaTime;
			rb3d.transform.position = temp;
		}

		if (Input.GetKey (KeyCode.W) && grounded) {
			rb3d.AddForce(Vector3.up * jumpForce);
			grounded = false;
		}

		if (Input.GetMouseButtonDown (0)) {
			Instantiate (laserProj, rb3d.transform.position, Quaternion.identity);
		}
	}
}
