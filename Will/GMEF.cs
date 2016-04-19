using UnityEngine;
using System.Collections;

public class GMEF : MonoBehaviour {

	public GameObject Mob1;
	public GameObject Mob2;
	public GameObject Mob3;
	public GameObject Mob4;
	public GameObject Player;
	private float EFTimer = 600.0f; //Timer for Enchanted Forest Biome
	private float STimer = 600.0f; //Timer for Spore Biome
	private float CTimer = 600.0f; //Timer for Crystal Biome
	private float mobTimer = 5.0f;
	private int mobCount = 0;
	public static GMEF instance = null;

	void Awake(){
	if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		Time.timeScale = 1f;

		DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mobTimer -= Time.deltaTime;// Resets spawn time every 5 seconds
		MobSpawner ();

		//Timers countdown for the different biomes
		if (Application.loadedLevel == 2) {
			EFTimer -= Time.deltaTime;
		}

		if (Application.loadedLevel == 3) {
			STimer -= Time.deltaTime;
		}

		if (Application.loadedLevel == 4) {
			CTimer -= Time.deltaTime;
		}
	}

	void MobSpawner(){
		if (mobCount < 10) {
			if (mobTimer <= 0)
			{
				int type1 = Random.Range(0, 2);
				int type2 = Random.Range(0, 2);

				if (type1 == 0 && type2 == 0)
				{
					//ground melee
					Instantiate(Mob1);
				}

				if (type1 == 0 && type2 == 1)
				{
					//ground range
					Instantiate(Mob2);
				}

				if (type1 == 1 && type2 == 0)
				{
					//air melee
					Instantiate(Mob3);
				}

				if (type1 == 1 && type2 == 1)
				{
					//air range
					Instantiate(Mob4);
				}

				mobCount ++;
				mobTimer += 5.0f;
			}
		}
	}

	public void LoadLevels(){
	
	}
}
