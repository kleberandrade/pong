using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour 
{
    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

	private void Start()
	{
		Button playButton = transform.GetChild (0).GetComponent<Button> ();
		playButton.onClick.AddListener (delegate { PlayGame (); });
		Button exitButton = transform.GetChild (1).GetComponent<Button> ();
		exitButton.onClick.AddListener (delegate { Exit (); });
	}

	public void PlayGame()
	{
        m_AudioSource.Play();
		SceneManager.LoadScene ("Table");
	}

	public void Exit()
	{
        m_AudioSource.Play();
		Application.Quit ();
	}
}
