using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(GUIText))]
public class GameManager : MonoBehaviour 
{
    #region Events
    public delegate void GameEvent();
    public static GameEvent OnGameStart;
    #endregion

    [SerializeField]
    private List<string> texts;

    void Start()
    {
        StartCoroutine("Counter");
    }

    IEnumerator Counter()
    {
        foreach (string text in texts)
        {
            guiText.enabled = true;
            guiText.text = text;
            yield return new WaitForSeconds(0.5f);
            guiText.enabled = false;
            yield return new WaitForSeconds(0.5f);
        }

        if (OnGameStart != null)
            OnGameStart();
    }
}
