using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlGame : MonoBehaviour
{
    public static System.Action<GameStates, GameStates> OnChangeState;

    GameStates state = GameStates.None;

    public GameStates State
    {
        get => state;
        set
        {
            if (state == value) return;
            OnChangeState?.Invoke(value, state);
            state = value;
        }
    }

    public void TargetLost()
    {
        State = GameStates.LookForGroud;
        Debug.Log("TargetLost");

    }

    public void PlaneFound()
    {
        if (State == GameStates.PlayGame) return;
        State = GameStates.PlayGame;
        Debug.Log("PlayGame");
    }
    public void Death()
    {
        State = GameStates.Death;
        this.gameObject.SetActive(false);
        Debug.Log("Death");
    }

    public void Start()
    {
        State = GameStates.LookForGroud;
        Debug.Log("PlayGame");
    }

    public void Log(string message)
    {
        Debug.Log(message);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    
}
