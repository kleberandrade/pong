using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour 
{
    private GameObject ball;

	void Start () 
    {
        ball = GameObject.Find("Ball");
        StartCoroutine("Counting");
	}

    IEnumerator Counting()
    {
        for (int number = 3; number > 0; number--)
        {
            guiText.enabled = true;
            guiText.text = number.ToString();
            yield return new WaitForSeconds(0.5f);
            guiText.enabled = false;
            yield return new WaitForSeconds(0.5f);
        }

        // Ready
        guiText.enabled = true;
        guiText.text = "Ready";
        yield return new WaitForSeconds(0.5f);
        guiText.enabled = false;
        yield return new WaitForSeconds(0.2f);

        // Go!
        guiText.enabled = true;
        guiText.text = "Go!";
        yield return new WaitForSeconds(0.5f);
        guiText.enabled = false;

        ball.SendMessage("Initialize");
    }
}
