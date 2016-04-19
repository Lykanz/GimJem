using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadLevels : MonoBehaviour {

	public Image fader;

	public void loadLevel1()
	{
		fader.GetComponent<Animator> ().SetBool ("fade", true);
		Invoke ("ghettoLoad1", 1.9f);
	}

	void ghettoLoad1()
	{
		Application.LoadLevel (1);
	}
}
