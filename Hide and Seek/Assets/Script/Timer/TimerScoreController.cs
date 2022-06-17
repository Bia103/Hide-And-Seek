using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScoreController : MonoBehaviour
{
    public TMP_Text timeText;
    public int bestScore;
    public int currentTime = 0;
    public bool gameStarted = false;
    public GameObject panelStart;
    void Start()
    {
        currentTime = 0;
        if(PlayerPrefs.HasKey("bestTime")) {
            bestScore = PlayerPrefs.GetInt("bestTime");
            timeText.text = "Best score: " + bestScore;
        } else {
            bestScore = 0;
            PlayerPrefs.SetInt("bestTime", 9999);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted) {
            Debug.Log("PlzMergiFa");
            bool existingFruits = VerifyFruitsStillExist();
            Debug.Log(existingFruits);
            if(!existingFruits) {
                gameStarted = false;
                if(currentTime < bestScore || bestScore == 0) {
                    bestScore = currentTime;
                    PlayerPrefs.SetInt("bestTime", currentTime);
                    timeText.text = "Best score: " + currentTime;
                }
                panelStart.SetActive(true);
            } else {
                timeText.text = "Best score: " + bestScore + "\nCurrentTime: " + currentTime;
                currentTime = currentTime + 1;
                Debug.Log(currentTime);
            }
        }
    }

    bool VerifyFruitsStillExist() {
        GameObject[] destroyableFruits = GameObject.FindGameObjectsWithTag("DestroyableFruits");
        if(destroyableFruits.Length == 0)
            return false;
        return true;
    }

    public void InstantiateGame() {
        gameStarted = true;
        currentTime = 0;
    }
}
