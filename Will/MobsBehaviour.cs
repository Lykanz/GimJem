using UnityEngine;
using System.Collections;

public class MobsBehaviour : MonoBehaviour {

	Rigidbody rb3d;
	Transform target;
	[SerializeField] private float speed = 1.0f;
	private float actionChange = 3.0f;
	private int action;
	private float maxdistance;
	private Transform myTransform;

	void Awake(){
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		rb3d = GetComponent<Rigidbody> ();

		GameObject go = GameObject.FindGameObjectsWithTag ("Player");

		target = go.transform;

		maxdistance = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {

		actionChange -= Time.deltaTime;

		if (actionChange == 0) {
			Invoke ("actChng", 3.0f);
			actionChange += 3.0f;
		}

		if (action == 0) {
			int direction = Random.Range (0, 2);
			Vector3 temp = transform.position;

			if (direction == 0)
			{
				temp.x += speed * Time.deltaTime;
				rb3d.transform.position = temp;
			}

			if (direction == 1)
			{
				temp.x -= speed * Time.deltaTime;
				rb3d.transform.position = temp;
			}
		}

		Debug.DrawLine (target.position, myTransform.position, Color.red);
	}
}
