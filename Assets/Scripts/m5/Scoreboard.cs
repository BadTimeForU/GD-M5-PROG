using UnityEngine;
using TMPro;
using System;

public class Scoreboard : MonoBehaviour
{
    private int score = 0;
    private TMP_Text textField;

    private void Start()
    {
        textField = GetComponent<TMP_Text>();

        
        Pickup.OnPickupCollected += AddPickupPoints;

        
        UpdateScoreText();
    }

    private void AddPickupPoints()
    {
        score += 50;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        textField.text = "Score: " + score;
    }

    private void OnDestroy()
    {
        
        Pickup.OnPickupCollected -= AddPickupPoints;
    }
}
