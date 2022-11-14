using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlPlaneFinder : CtrlGameListener
{

    public GameObject[] gameObjects;
    protected override void GameStateChanged(GameStates current, GameStates previous)
    {
        if(current == GameStates.PlayGame)
        {
            for (int i=0; i<gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
                Debug.Log("AAAA");
            }
        }
        else
        {
        
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }
        }
    }
}
