using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    [SerializeField] private float ySpeed = 0.5f;
    [SerializeField] private float xSpeed = 1.0f;
    [SerializeField] private float m_RotateSpeed = 2.5f;
    private float max_VerticalSpeed;
    private float max_HorizontalSpeed;
    private Vector3 direction;
    private Quaternion m_TurnTo;
    private bool m_bCrash;
    

    void Crash()
    {
        m_Rigidbody.useGravity = true;
        GetComponent<Collider>().enabled = false;
        m_bCrash = true;
        direction = (new Vector3(transform.position.x - 6.0f, transform.position.y - 10.0f, transform.position.z) - transform.position).normalized;
        m_TurnTo = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, m_TurnTo, Time.deltaTime * m_RotateSpeed);
    }

	void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        max_VerticalSpeed = ySpeed * 5.0f;
        max_HorizontalSpeed = xSpeed * 5.0f;
	}

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.0f, 9.0f), Mathf.Clamp(transform.position.y, -3.5f, 5.0f), 0);
        if (m_bCrash == true)
        {
            m_Rigidbody.AddForce(new Vector3(-10, 0, 0));
            if (m_Rigidbody.position.y == 3.5f)
            {
                //Application.LoadLevel(2);
            }
        }
    }

	void FixedUpdate()
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

    void OnCollisionEnter()
    {
        Crash();
    }
}
