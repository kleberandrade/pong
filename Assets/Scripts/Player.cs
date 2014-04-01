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
    protected static PlayerType playerCollider = PlayerType.None;
    protected static Vector3 originScale;

    void Start()
    {
        originScale = transform.localScale;
    }

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

    void OnEnable()
    {
        Items.OnPlayerUp += OnPlayerUp;
        Items.OnPlayerDown += OnPlayerDown;
    }

    void OnDisable()
    {
        Items.OnPlayerUp -= OnPlayerUp;
        Items.OnPlayerDown -= OnPlayerDown;
    }

    void OnPlayerUp()
    {
        if (type == Player.playerCollider)
        {
            Vector3 scale = transform.localScale;
            scale.y += 0.5f;
            transform.localScale = scale;
            StartCoroutine("BackEffect");
        }
    }

    IEnumerator BackEffect()
    {
        yield return new WaitForSeconds(10.0f);
        transform.localScale = originScale;
    }

    void OnPlayerDown()
    {
        if (type == Player.playerCollider)
        {
            Vector3 scale = transform.localScale;
            scale.y -= 0.5f;
            transform.localScale = scale;
            StartCoroutine("BackEffect");
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