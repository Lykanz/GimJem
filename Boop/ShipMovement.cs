using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    [SerializeField] private float ySpeed = 0.5f;
    [SerializeField] private float xSpeed = 1.0f;
    private float max_VerticalSpeed;
    private float max_HorizontalSpeed;

	void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        max_VerticalSpeed = ySpeed * 5.0f;
        max_HorizontalSpeed = xSpeed * 5.0f;
	}
	
	void FixedUpdate ()
    {
        if (Input.GetKey("w"))
        {
            m_Rigidbody.AddRelativeForce(Vector3.up * ySpeed);
        }
        if (Input.GetKey("s"))
        {
            m_Rigidbody.AddRelativeForce(-Vector3.up * ySpeed);
        }

        if (Input.GetKey("a"))
        {
            m_Rigidbody.AddRelativeForce(-Vector3.right * xSpeed);
        }
        
        if (Input.GetKey("d"))
        {
            m_Rigidbody.AddRelativeForce(Vector3.right * xSpeed);
        }

        if (Mathf.Abs(m_Rigidbody.velocity.x) > max_HorizontalSpeed)
        {
            m_Rigidbody.velocity = m_Rigidbody.velocity.normalized * max_HorizontalSpeed;
        }

        if (Mathf.Abs(m_Rigidbody.velocity.y) > max_VerticalSpeed)
        {
            m_Rigidbody.velocity = m_Rigidbody.velocity.normalized * max_VerticalSpeed;
        }
	}
}
