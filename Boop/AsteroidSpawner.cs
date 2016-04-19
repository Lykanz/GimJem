using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private int number_Of_Asteroids = 20;
    [SerializeField] private int spawn_Count = 5;
    [SerializeField] private float min_Height = 50;
    [SerializeField] private float max_Height = -50;
    
    private int m_nCurrentAsteroids;
    private bool m_bIsSpawning;
    public GameObject m_Asteroid01;
    public GameObject m_Asteroid02;

    private IEnumerator SpawnAsteroid(int _nCount, int _nTime)
    {
        yield return new WaitForSeconds(_nTime);
        for (int i = 0; i < _nCount; i++)
        {
            GameObject newAsteroid = Instantiate(SelectAsteroid(), SelectHeight(min_Height, max_Height), SelectRotation()) as GameObject;
            m_nCurrentAsteroids++;
        }
        m_bIsSpawning = false;
    }
    //765 x 365
    private GameObject SelectAsteroid()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            return m_Asteroid01;
        }
        else
        {
            return m_Asteroid02;
        }
    }

    private Vector3 SelectHeight(float _fMinHeight, float _fMaxHeight)
    {
        return new Vector3(-15.0f, Random.Range(_fMinHeight, _fMaxHeight), 0);
    }

    private Quaternion SelectRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    void Start()
    {
        m_bIsSpawning = false;
    }

    void Update ()
    {
        if (m_nCurrentAsteroids <= number_Of_Asteroids && m_bIsSpawning == false)
        {
            StartCoroutine(SpawnAsteroid(Random.Range(1, spawn_Count), Random.Range(1, 3)));
            m_bIsSpawning = true;
        }
    }
}
