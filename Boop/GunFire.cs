using UnityEngine;
using System.Collections;

public class GunFire : MonoBehaviour
{
    public GameObject m_Laser;
    private GameObject m_Ship;
	// Use this for initialization
	void Start ()
    {
        m_Ship = GameObject.Find("SSK-IDK");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            if (gameObject.name == "SSK-IDK")
            {
                GameObject laser = Instantiate(m_Laser, gameObject.transform.position, Quaternion.identity) as GameObject;
            }
        }
	}
}
