using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour 
{
    public PlayerType m_PlayerType;
    private GameManager m_GameManager;

    private void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }

	private void OnTriggerEnter(Collider hit) 
    {
        if (m_PlayerType == PlayerType.Left)
            m_GameManager.AddRightScore();

        if (m_PlayerType == PlayerType.Right)
            m_GameManager.AddLeftScore();
    }
}
