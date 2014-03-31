using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody), typeof(TrailRenderer))]
public class Ball : MonoBehaviour 
{
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private float trailTimer = 0.8f;

    private Vector3 origin;
    private Vector3 leftImpulse = new Vector3(1.0f, 0.0f, 1.0f);
    private Vector3 rightImpulse = new Vector3(-1.0f, 0.0f, -1.0f);

    private TrailRenderer trail;

    void Start()
    {
        origin = transform.position;
        trail = GetComponent<TrailRenderer>();
        trail.time = trailTimer;
    }

    void StartImpulse(Vector3 side)
    {
        trail.time = 0.0f;
        rigidbody.velocity = Vector3.zero;
        side.y = Random.Range(-1.0f, 1.0f) < 0.0f ? -1.0f : 1.0f;
        transform.position = origin;
        rigidbody.AddForce(side * speed, ForceMode.Impulse);
        trail.time = trailTimer;
    }

    void LeftStartImpulse()
    {
        StartImpulse(leftImpulse);
    }

    void RightStartImpulse()
    {
        StartImpulse(rightImpulse);
    }
}
