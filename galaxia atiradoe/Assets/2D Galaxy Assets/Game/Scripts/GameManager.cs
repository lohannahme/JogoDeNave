using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public GameObject player;
    private UIManager _uimanager;
    private SpawnManager _spawnManager;

    private void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity);
                _uimanager.ShowImage();
                _uimanager.scoreText.text = "Score: ";
                gameOver = false;
                _spawnManager.StartRoutines();
            }
        }
        
    }
}
