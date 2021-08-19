using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject[] powerUps;
    private GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    public void StartRoutines()
    {
        StartCoroutine(GenerateEnemy());
        StartCoroutine(GeneratePowerUps());
    }

    IEnumerator GenerateEnemy()
    {


        while (_gameManager.gameOver == false)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(4);
        }

    }

    IEnumerator GeneratePowerUps()
    {
        while (_gameManager.gameOver == false)
        {
            int randomNum = Random.Range(0, 3);
            Instantiate(powerUps[randomNum], new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(9);
        }
    }
}
