using UnityEngine;
using System.Collections;

public class DarkItem : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;

	void Update () 
    {
        transform.localScale = new Vector3(
            7.0f + Mathf.PingPong(Time.time * speed, 3),
            1.0f,
            7.0f + Mathf.PingPong(Time.time * speed, 3));
	}
}
