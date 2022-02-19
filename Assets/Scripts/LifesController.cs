using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesController : MonoBehaviour
{
    [SerializeField] private int lifeCount = 5;
    [SerializeField] private List<GameObject> lifes;
    
    [SerializeField] private EndWindowController endWindowController;
    [SerializeField] private ColumnMove columnMove;
    private void Update()
    {
        if (lifeCount < 1)
        {
            endWindowController.ShowEndWindow();
            columnMove.EndColumnMove();
        }
    }

    public void TakeLife()
    {
        lifes[lifeCount-1].SetActive(false);
        lifes.RemoveAt(lifeCount-1);
        lifeCount--;
    }
}
