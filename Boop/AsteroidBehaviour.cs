using UnityEngine;
using System.Collections;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] private float min_Speed = 5.0f;
    [SerializeField] private float max_Speed = 10.0f;
    [SerializeField] private float min_EulerAngleVelocity = 20.0f;
    [SerializeField] private float max_EulerAngleVelocity = 50.0f;
    private Rigidbody m_Rigidbody;
    private Quaternion m_DeltaRotation;
    private SpriteRenderer m_SpriteRenderer;
    public Sprite Explosion;

    IEnumerator MarkForDelete(int _Time)
    {
        GetComponent<Collider>().enabled = false;
        m_Rigidbody.isKinematic = true;
        //m_DeltaRotation = transform.rotation;
        yield return new WaitForSeconds(_Time);
        Destroy(gameObject);
    }
	void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.AddForce(new Vector3(Random.Range(min_Speed, max_Speed), 0, 0), ForceMode.VelocityChange);
        m_DeltaRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Random.Range(min_EulerAngleVelocity, max_EulerAngleVelocity)) * Time.deltaTime);
        if (Random.Range(0, 2) == 0)
        {
            min_EulerAngleVelocity = -min_EulerAngleVelocity;
            max_EulerAngleVelocity = -max_EulerAngleVelocity;
        }
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
	}

    void FixedUpdate()
    {

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * m_DeltaRotation);
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
            m_SpriteRenderer.sprite = Explosion;
            StartCoroutine(MarkForDelete(1));
            //Play animation
        }
        if (_Col.gameObject.tag == "Player")
        {
            m_SpriteRenderer.sprite = Explosion;
            StartCoroutine(MarkForDelete(1));
        }
        if (_Col.gameObject.tag == "Projectile")
        {
            m_SpriteRenderer.sprite = Explosion;
            StartCoroutine(MarkForDelete(1));
        }
    }
}
