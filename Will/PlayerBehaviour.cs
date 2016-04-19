using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	
	[SerializeField] private float speed = 10.0f;
	[SerializeField] private float jumpForce = 400.0f;
	private bool grounded;
	private Rigidbody rb3d;
	private float hp = 1.0f;
	private bool invincible;
	public GameObject laserProj;
	public Image health;

	void OnCollisionEnter(Collision col)
	{
		grounded = true;

		if (col.gameObject.tag == "mobs" && !invincible) {
			Debug.Log(hp);
			hp -= 0.1f;
			invincible = true;
			Invoke("offInvin", 3.0f);
		}
	}

	void offInvin()
	{
		invincible = false;
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
			Vector3 position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f);
			position = Camera.main.ScreenToWorldPoint (position);
			GameObject go = Instantiate(laserProj, transform.position, Quaternion.identity) as GameObject;
			go.transform.LookAt(position);
			go.GetComponent<Rigidbody>().AddForce(go.transform.forward * 1000);
		}

		health.fillAmount = hp;
	}
}
