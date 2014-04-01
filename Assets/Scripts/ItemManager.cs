using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    private int dropIndex = 0;
    [SerializeField]
    private float minTime = 5.0f;
    [SerializeField]
    private float maxTime = 10.0f;
    private float startTime = 0.0f;
    private float dropTime;

    private bool gameOver = false;
    private bool startGame = false;

    void Update()
    {
        if (startGame && !gameOver)
        {
            if (Time.time - startTime >= dropTime)
            {
                Drop();
                Initialize();
            }
        }
    }

    void Initialize()
    {
        dropTime = Random.Range(minTime, maxTime);
        startTime = Time.time;
    }
	
	void Drop () 
    {
        transform.GetChild(dropIndex).gameObject.SetActive(true);
        dropIndex = ++dropIndex % transform.childCount;
	}

    void OnGameStart()
    {
        Initialize();
        startGame = true;
    }

    void OnEnable()
    {
        GameManager.OnGameStart += OnGameStart;
    }

    void OnDisable()
    {
        GameManager.OnGameStart -= OnGameStart;
    }

}

