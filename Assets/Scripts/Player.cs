using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour 
{
    public PlayerType m_Type;
    public float m_Speed = 15.0f;
    private float m_Move;
    private Transform m_Transform;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }

	void Update () 
    {
#if UNITY_EDITOR || UNITY_STANDALONE

	    if (m_Type == PlayerType.Left)
            m_Move = Input.GetAxis("VerticalLeft") * m_Speed;

        if (m_Type == PlayerType.Right)
            m_Move = Input.GetAxis("VerticalRight") * m_Speed;

#elif UNITY_ANDROID

        foreach (var touch in Input.touches)
        {
            if (m_Type == PlayerType.Left && touch.position.x < Screen.width / 2.0f)
                m_Move = touch.position.y - Camera.main.WorldToScreenPoint(m_Transform.position).y;

            if (m_Type == PlayerType.Right && touch.position.x >= Screen.width / 2.0f)
                m_Move = touch.position.y - Camera.main.WorldToScreenPoint(m_Transform.position).y;
        }

#endif

        m_Transform.Translate(Vector3.forward * m_Move * Time.deltaTime, Space.World);
	}
}

public enum PlayerType
{
    Left,
    Right
}