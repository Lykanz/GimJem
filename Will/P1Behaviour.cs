using UnityEngine;
using System.Collections;

public class P1Behaviour : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
		//Display the button to press
		}
	}
}
