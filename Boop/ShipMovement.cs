using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    [SerializeField] private float max_VerticalSpeed = 0.5f;
    [SerializeField] private float max_HorizontalSpeed = 1.0f;

	void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        if (Input.GetKey("w"))
        {
            m_Rigidbody.AddRelativeForce(Vector3.up * max_VerticalSpeed);
        }
        else if (Input.GetKey("a"))
        {
            m_Rigidbody.AddRelativeForce(-Vector3.right * max_HorizontalSpeed);
        }
        else if (Input.GetKey("s"))
        {
            m_Rigidbody.AddRelativeForce(-Vector3.up * max_HorizontalSpeed * max_VerticalSpeed);
        }
        else if (Input.GetKey("d"))
        {
            m_Rigidbody.AddRelativeForce(Vector3.right * max_HorizontalSpeed);
        }
	}
}
