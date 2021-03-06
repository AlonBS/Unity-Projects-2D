﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour {


    [SerializeField] float baseLifes = 3;
    float numOfLives;

    Text livesText;

    // Use this for initialization
    void Start()
    {

        livesText = GetComponent<Text>();
        numOfLives = baseLifes - PlayerSettings.GetDifficulty();
        UpdateDisplay();
    }


    private void UpdateDisplay()
    {
        livesText.text = numOfLives.ToString();
    }


    public void TakeLives(int amount)
    {
        numOfLives -= amount;
        UpdateDisplay();
        if (numOfLives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLooseLevel();
        }
    }

}
