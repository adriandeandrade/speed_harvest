﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    #region Singleton
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            return;
        }
    }
    #endregion

    private void Start()
    {
        
    }
}
