using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
    [SerializeField]
    private GUISkin skin;
    [SerializeField]
    private AudioClip audioButtonClick;
    [SerializeField]
    private Texture2D background;
    private Rect area;

	void Start () 
    {
        area = new Rect(
            Screen.width / 2.0f - 150.0f,
            Screen.height * 0.45f,
            300.0f,
            400.0f);
	}
	
	void OnGUI () 
    {
        if (skin)
            GUI.skin = skin;

        if (background)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background, ScaleMode.StretchToFill, true, 1.0f);

        GUILayout.BeginArea(area);
        GUILayout.BeginVertical("box");
        if (GUILayout.Button("SINGLE PLAYER"))
        {
            ButtonClick();
            Application.LoadLevel("Level");
        }

        if (GUILayout.Button("MULTIPLAYER"))
        {
            ButtonClick();
            Application.LoadLevel("Level");
        }

        if (GUILayout.Button("CREDITS"))
        {
            ButtonClick();
            Application.LoadLevel("Credits");
        }

        if (GUILayout.Button("EXIT"))
        {
            ButtonClick();
            Application.Quit();
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
	}

    void ButtonClick()
    {
        if (audioButtonClick)
            AudioSource.PlayClipAtPoint(audioButtonClick, transform.position);
    }
}

