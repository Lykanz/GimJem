using UnityEngine;
using System.Collections;

public class MobsBehaviour : MonoBehaviour {

	Rigidbody rb3d;
	GameObject Player;
	[SerializeField] private float speed = 1.0f;
	private int action;

	// Use this for initialization
	void Start () {
		rb3d = GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		Collider[] detection = Physics.OverlapSphere (transform.position, 5.0f);
		for (int i = 0; i < detection.Length; i++) {
			if (detection[i].gameObject.tag == "Player")
			{
				Debug.Log("player detect");
				
				//rotate to look at the player
				transform.LookAt(detection[i].gameObject.transform.position);
				transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation
				
				
				//move towards the player
				if (Vector3.Distance(transform.position,detection[i].gameObject.transform.position)>1f){//move if distance from target is greater than 1
					transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
				}
			}
		}
	}
}
