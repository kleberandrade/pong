using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Ball : MonoBehaviour 
{
    public float m_RespawnTime = 2.0f;
    public float m_Speed = 3.0f;
    private Vector3 m_Origin;
    private Vector3 m_LeftImpulse = new Vector3(1.0f, 0.0f, 1.0f);
    private Vector3 m_RightImpulse = new Vector3(-1.0f, 0.0f, -1.0f);
    private Rigidbody m_Rigidbody;
    private Transform m_Transform;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
    }

    private void Start()
    {
        m_Origin = transform.position;
    }

    private IEnumerator Impulsing(Vector3 direction)
    {
        m_Rigidbody.velocity = Vector3.zero;
        m_Transform.position = m_Origin;
        yield return new WaitForSeconds(m_RespawnTime);
        direction.y = Random.Range(-1.0f, 1.0f) < 0.0f ? -1.0f : 1.0f;
        m_Rigidbody.AddForce(direction * m_Speed, ForceMode.Impulse);
    }

    public void Initialize()
    {
        if (Random.Range(-1.0f, 1.0f) < 0.0f)
            StartCoroutine(Impulsing(m_LeftImpulse));
        else
            StartCoroutine(Impulsing(m_RightImpulse));
    }

    public void Impulse(PlayerType type)
    {
        if (type == PlayerType.Left)
            StartCoroutine(Impulsing(m_LeftImpulse));

        if (type == PlayerType.Right)
            StartCoroutine(Impulsing(m_RightImpulse));
    }
}
