using UnityEngine;
using System.Collections;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] private float min_Speed = 5.0f;
    [SerializeField] private float max_Speed = 10.0f;
    [SerializeField] private float min_EulerAngleVelocity = 20.0f;
    [SerializeField] private float max_EulerAngleVelocity = 50.0f;
    private Rigidbody m_Rigidbody;

	void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.AddForce(new Vector3(Random.Range(min_Speed, max_Speed), 0, 0), ForceMode.VelocityChange);
        if (Random.Range(0, 2) == 0)
        {
            min_EulerAngleVelocity = -min_EulerAngleVelocity;
            max_EulerAngleVelocity = -max_EulerAngleVelocity;
        }
	}

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Random.Range(min_EulerAngleVelocity, max_EulerAngleVelocity)) * Time.deltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }

    void Update()
    {
        if (gameObject.transform.position.x > 15.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision _Col)
    {
        if (_Col.gameObject.tag == "Asteroid")
        {
            //Play animation
        }
        if (_Col.gameObject.tag == "Player")
        {
        }
    }
}
