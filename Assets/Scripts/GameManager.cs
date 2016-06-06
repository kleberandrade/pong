using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public int m_ScoreToGameover = 15;
    public Text m_ScoreText;
    private int m_LeftScore = 0;
    private int m_RightScore = 0;

    private Ball m_Ball;
    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;

    private void Start()
    {
        m_Ball = FindObjectOfType<Ball>();
        m_StartWait = new WaitForSeconds(3.0f);
        m_EndWait = new WaitForSeconds(3.0f);
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());
    }

    private IEnumerator RoundStarting()
    {
        yield return m_StartWait;
    }

    private IEnumerator RoundPlaying()
    {
        m_Ball.Initialize();

        while (!GameOver())
        {
            yield return null;
        }
    }

    private IEnumerator RoundEnding()
    {
        yield return m_EndWait;
    }

    private bool GameOver()
    {
        return (m_LeftScore + m_RightScore) == m_ScoreToGameover;
    }

    public void AddLeftScore()
    {
        m_LeftScore++;
        UpdateScore();
        m_Ball.Impulse(PlayerType.Left);
    }

    public void AddRightScore()
    {
        m_RightScore++;
        UpdateScore();
        m_Ball.Impulse(PlayerType.Right);
    }

    private void UpdateScore()
    {
        m_ScoreText.text = string.Format("{0:00} x {1:00}", m_LeftScore, m_RightScore);
    }
}
