using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
    [SerializeField]
    private GUISkin skin;

    private int leftScore = 0;
    private int rightScore = 0;

    private Rect leftArea;
    private Rect rightArea;

	void Start () 
    {
        leftArea = new Rect(
            Screen.width / 2.0f - 100.0f,
            15.0f,
            90.0f,
            50.0f);

        rightArea = new Rect(
            Screen.width / 2.0f + 10.0f,
            15.0f,
            90.0f,
            50.0f);
	}

	void OnGUI () 
    {
        GUI.skin = skin;
        GUI.Label(leftArea, leftScore.ToString());
        GUI.Label(rightArea, rightScore.ToString());
	}

    void OnEnable()
    {
        Goal.OnLeftGoal += OnLeftGoal;
        Goal.OnRightGoal += OnRightGoal;
    }

    void OnDisable()
    {
        Goal.OnLeftGoal -= OnLeftGoal;
        Goal.OnRightGoal -= OnRightGoal;
    }

    void OnLeftGoal()
    {
        rightScore++;
    }

    void OnRightGoal()
    {
        leftScore++;
    }
    void Update()
    {
        if (leftScore == 11 || rightScore == 11)
            Application.Quit();
    }
}
