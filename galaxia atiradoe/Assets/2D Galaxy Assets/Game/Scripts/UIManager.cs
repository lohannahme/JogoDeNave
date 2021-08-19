using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lifes;
    public Image livesImageDisplay;
    public Image uiImage;
    public Text scoreText;
    public int score;
   
   
    public void UpdateLives(int currentLifes)
    {
        livesImageDisplay.sprite = lifes[currentLifes];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void ShowImage()
    {
        uiImage.enabled = !uiImage.enabled;
        
    }
    
}
