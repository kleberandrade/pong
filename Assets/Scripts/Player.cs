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
        // Left Player
	    if (type == PlayerType.Left)
        {
#if UNITY_EDITOR || UNITY_WEBPLAYER || UNITY_STANDALONE
            move = Input.GetAxis("VerticalLeft") * speed;
#elif UNITY_ANDROID

#endif
        }

        // Right Player
        if (type == PlayerType.Right)
        {
#if UNITY_EDITOR || UNITY_WEBPLAYER || UNITY_STANDALONE
            move = Input.GetAxis("VerticalRight") * speed;
#elif UNITY_ANDROID

#endif
        }

        // Artificial Intelligence Player
        if (type == PlayerType.AI)
        {

        }

        rigidbody.velocity = Vector3.forward * move;
	}
}

public enum PlayerType
{
    Left,
    Right,
    AI
}