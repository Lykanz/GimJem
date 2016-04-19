using UnityEngine;
using System.Collections;

public class GunFire : MonoBehaviour
{
    public GameObject m_Laser;
    private bool m_bLoaded;

    void Reloading()
    {
        m_bLoaded = true;
    }

    void Start()
    {
        m_bLoaded = true;
    }

	void Update ()
    {
        if (Input.GetKeyDown("space") && m_bLoaded == true)
        {
            Vector3 temp = gameObject.transform.position;
            temp.x -= 1.5f;
            GameObject laser = Instantiate(m_Laser, temp, Quaternion.identity) as GameObject;
            m_bLoaded = false;
            Invoke("Reloading", 1.0f);
        }
	}
}
