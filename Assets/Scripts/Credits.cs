using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    [SerializeField]
    private GUISkin skin;
    [SerializeField]
    private AudioClip audioButtonClick;
    [SerializeField]
    private Texture2D background;
    private Rect backArea;

    void Start()
    {
        backArea = new Rect(
            Screen.width - 150.0f,
            Screen.height - 50.0f,
            140.0f,
            40.0f);
    }

    void OnGUI()
    {
        if (skin)
            GUI.skin = skin;

        if (background)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background, ScaleMode.StretchToFill, true, 1.0f);

        GUILayout.BeginArea(backArea);
        if (GUILayout.Button("BACK"))
        {
            ButtonClick();
            Application.LoadLevel("Menu");
        }
        GUILayout.EndArea();
    }

    void ButtonClick()
    {
        if (audioButtonClick)
            AudioSource.PlayClipAtPoint(audioButtonClick, transform.position);
    }
}
