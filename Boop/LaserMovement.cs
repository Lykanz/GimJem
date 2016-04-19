using UnityEngine;
using System.Collections;

public class LaserMovement : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

	void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.velocity = new Vector3(-5.0f, 0, 0);
	}

    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
