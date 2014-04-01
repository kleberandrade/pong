using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour 
{
    [SerializeField]
    private float speed = 15.0f;
    private float move;
    [SerializeField]
    private PlayerType type;
    private static PlayerType playerCollider = PlayerType.None;

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

    void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.CompareTag("Ball"))
        {
            Player.playerCollider = type;
        }
    }

    void AIMovement()
    {

    }

    void OnPlayerUp()
    {
        if (type == playerCollider)
        {
            Vector3 scale = transform.localScale;
            scale.y += 1.0f;
            transform.localScale = scale;
            Debug.Log(tag + " Up");
        }
    }

    void OnPlayerDown()
    {
        if (type == playerCollider)
        {
            Vector3 scale = transform.localScale;
            scale.y -= 1.0f;
            transform.localScale = scale;
            Debug.Log(tag + " Down");
        }
    }
}

public enum PlayerType
{
    None,
    Left,
    Right,
    AI
}