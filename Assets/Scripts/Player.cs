using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour 
{
    [SerializeField]
    private float speed = 15.0f;
    [SerializeField]
    private PlayerType type;

    private float move;

	void Update () 
    {
#if UNITY_EDITOR || UNITY_WEBPLAYER || UNITY_STANDALONE

        // Left Player
	    if (type == PlayerType.Left)
            move = Input.GetAxis("VerticalLeft") * speed;

        // Right Player
        if (type == PlayerType.Right)
            move = Input.GetAxis("VerticalRight") * speed;

#elif UNITY_ANDROID

        foreach (var touch in Input.touches)
        {
            if (type == PlayerType.Left && touch.position.x < Screen.width / 2.0f)
                move = touch.position.y - Camera.main.WorldToScreenPoint(transform.position).y;

            if (type == PlayerType.Right && touch.position.x >= Screen.width / 2.0f) 
                move = touch.position.y - Camera.main.WorldToScreenPoint(transform.position).y;
        }

#endif

        // Artificial Intelligence Player
        if (type == PlayerType.AI)
        {
            AIMovement();   
        }

        rigidbody.velocity = Vector3.forward * move;
	}

    void AIMovement()
    {

    }
}

public enum PlayerType
{
    Left,
    Right,
    AI
}