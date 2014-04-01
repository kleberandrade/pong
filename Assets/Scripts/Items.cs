using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource), typeof(Light))]
public class Items : MonoBehaviour
{
    #region Events
    public delegate void ItemEvent();
    public static ItemEvent OnDarken;
    public static ItemEvent OnPlayerUp;
    public static ItemEvent OnPlayerDown;
    public static ItemEvent OnBlock;
    public static ItemEvent OnDoubleBall;
    #endregion

    [SerializeField]
    private float scaleSpeed = 0.5f;
    [SerializeField]
    private float scaleMax = 0.3f;
    [SerializeField]
    private float scale = 0.6f;
    [SerializeField]
    private float haloScale = 1.0f;
    [SerializeField]
    private AudioClip audioCollectedItem;

    private ItemType type;

    void OnEnable()
    {
        light.type = LightType.Point;
        this.type = Helper.GetRandomEnum<ItemType>();

        Vector3 pos = transform.position;
        pos.x = Random.Range(-5.0f, 5.0f);
        pos.z = Random.Range(-4.0f, 4.0f);
        this.transform.position = pos;
    }
	
	void Update () 
    {
        transform.localScale = new Vector3(
            scale + Mathf.PingPong(Time.time * scaleSpeed, scaleMax),
            scale + Mathf.PingPong(Time.time * scaleSpeed, scaleMax),
            scale + Mathf.PingPong(Time.time * scaleSpeed, scaleMax));

        light.range = haloScale + Mathf.PingPong(Time.time * scaleSpeed, scaleMax);
	}

    void OnTriggerEnter(Collider hit)
    {
        if (type == ItemType.Block)
        {
            if (OnDoubleBall != null)
                OnDoubleBall();
        }

        if (type == ItemType.Dark)
        {
            if (OnDarken != null)
                OnDarken();
        }
            
        if (type == ItemType.Up)
        {
            if (OnPlayerUp != null)
                OnPlayerUp();
        }

        if (type == ItemType.Down)
        {
            if (OnPlayerDown != null)
                OnPlayerDown();
        }

        if (type == ItemType.Double)
        {
            if (OnDoubleBall != null)
                OnDoubleBall();
        }

        if (audioCollectedItem)
            AudioSource.PlayClipAtPoint(audioCollectedItem, transform.position);

        gameObject.SetActive(false);
    }
}

public enum ItemType
{
    Block,
    Dark,
    Up,
    Down,
    Double
}