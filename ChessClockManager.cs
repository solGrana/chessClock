using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChessClockManager : MonoBehaviour
{
    [Header ("Texts")] 
    public Text player1TimeText;
    public Text player2TimeText;
    public Text whoseTurnText;


    private float player1Time;
    private float player2Time;
    private bool isPlayer1Turn = true;
    private bool isPaused = true;

    [Header ("Game Objects")] 
    public GameObject gameplayUI;
    public GameObject pausePanel;
    public GameObject startPanel;

    int storedMinutes = 1;



    private void Start()
    {
        SetInitialTime(10); // initial time 10 minutes each
        UpdateTimeDisplays();
        PlayerPrefs.SetInt("SelectedMinutes", storedMinutes);
    }

    private void Update()
    {
        storedMinutes = PlayerPrefs.GetInt("SelectedMinutes");
        UpdateTimeDisplays();

        if (!isPaused)
        {
            if (isPlayer1Turn)
            {
                player1Time -= Time.deltaTime;
                if (player1Time <= 0)
                {
                    // Manejar el final del tiempo para el jugador 1.
                }
            }
            else
            {
                player2Time -= Time.deltaTime;
                if (player2Time <= 0)
                {
                    // Manejar el final del tiempo para el jugador 2.
                }
            }
            
        }
    }

    public void TogglePause()
    {
        //pause game
        isPaused = true; 
        // activate pause panel and deactivate gameplay UI
        gameplayUI.SetActive(false);
        pausePanel.SetActive(true);
        
        // update text to show whose turn it is
        UpdateTurnText();
    }

    private void UpdateTurnText()
    {
        if (isPlayer1Turn)
        {
            whoseTurnText.text = "Black's turn";
        }
        else
        {
            whoseTurnText.text = "White's turn";
        }
    }

    public void Resume()
    {
        isPaused = false;
        // deactivate pause panel and activate gameplay UI
        gameplayUI.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void TogglePlayersTurn()
    {
        isPlayer1Turn = !isPlayer1Turn;
        isPaused = false;
    }
    public void ClickPlayer1()
    {
        //player 1 click his button
        isPlayer1Turn = false;
        isPaused = false;
    }
    public void ClickPlayer2()
    {
        //player 2 click his button
        isPlayer1Turn = true;
        isPaused = false;
    }

    public void RestartClock()
    {
        isPaused = true;
        UpdateTimeDisplays();
        gameplayUI.SetActive(true);
        pausePanel.SetActive(false);
        startPanel.SetActive(false);
    }

    public void StartGame()
    {
        isPaused = true;
        UpdateTimeDisplays();
        gameplayUI.SetActive(true);
        pausePanel.SetActive(false);
        startPanel.SetActive(false);
        SetInitialTime(storedMinutes);
    }

    public void SetInitialTime(int minutes)
    {
        player1Time = player2Time = minutes * 60;
        Debug.Log($"p1 time: {player1Time}");
        Debug.Log($"p2 time: {FormatTime(player2Time)}");
    }

    private void UpdateTimeDisplays()
    {
        player1TimeText.text = FormatTime(player1Time);
        player2TimeText.text = FormatTime(player2Time);
    }

    private string FormatTime(float time) //time =  minutes * 60
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
