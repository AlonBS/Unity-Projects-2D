﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    Defender defender;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnMouseDown()
    {
        if (!defender)
            return;

        AttemptToPlaceAt(GetSquareClicked());
    }

    public void SetSelectedSpawnder(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.StarCost;

        if (starDisplay.HaveEnoughStars(defenderCost)) {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }

    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickedPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickedPos);
        worldPos.x = Mathf.RoundToInt(worldPos.x);
        worldPos.y = Mathf.RoundToInt(worldPos.y);

        return worldPos;
    }


    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, transform.rotation) as Defender;
    }
}