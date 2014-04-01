using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour 
{
    [SerializeField]
    private PlayerType type;
    private GameObject ball;
    private GameObject score;

    void Start()
    {
        ball = GameObject.Find("Ball");
        score = GameObject.Find("Score");
    }

	void OnTriggerEnter (Collider hit) 
    {
        if (type == PlayerType.Left)
        {
            score.SendMessage("RightScoreUp");
            ball.SendMessage("LeftStartImpulse");
        }

        if (type == PlayerType.Right)
        {
            score.SendMessage("LeftScoreUp");
            ball.SendMessage("RightStartImpulse");
        }
	}
}
