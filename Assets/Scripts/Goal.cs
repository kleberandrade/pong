using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour 
{
    #region Events
    public delegate void GoalEvent();
    public static GoalEvent OnLeftGoal;
    public static GoalEvent OnRightGoal;
    #endregion

    [SerializeField]
    private PlayerType type;
    [SerializeField]
    private AudioClip audioGoal;

	void OnTriggerEnter (Collider hit) 
    {
        if (type == PlayerType.Left)
        {
            if (OnLeftGoal != null)
                OnLeftGoal();
        }

        if (type == PlayerType.Right)
        {
            if (OnRightGoal != null)
                OnRightGoal();
        }

        if (audioGoal)
            AudioSource.PlayClipAtPoint(audioGoal, transform.position);
	}
}
