﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerJ2 : MonoBehaviour
{
    public GameObject player;
    public int cantPoints;
    public int nextLevel;
    public float secondsTextEnd = 3.0f;
    public GameObject winnerText;
    public GameObject loserText;
    // Start is called before the first frame update
    void Start()
    {
        cantPoints = 0;
    }


    public void CapturedCoins(int points)
    {
        cantPoints += points;
    }
    
    public int GetPoints()
    {
        return cantPoints;
    }

    IEnumerator winGame()
    {
        winnerText.SetActive(true);
        yield return new WaitForSeconds(secondsTextEnd);
        
        SceneManager.LoadScene(nextLevel);
    }

    IEnumerator lostGame()
    {
        loserText.SetActive(true);
        yield return new WaitForSeconds(secondsTextEnd);
        loserText.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void finishGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Win()
    {
        StartCoroutine("winGame");
    }

    public void Lost()
    {
        StartCoroutine("lostGame");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.activeInHierarchy == false)
        {
            Lost();
        }
    }
}
