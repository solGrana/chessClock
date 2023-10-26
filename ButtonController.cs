using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public ChessClockManager chessClockManager;

    public void TogglePause()
    {
        chessClockManager.TogglePause();
    }

    public void Resume()
    {
        chessClockManager.Resume();
    }

    public void RestartClock()
    {
        chessClockManager.RestartClock();
    }

    public void StartGame()
    {
        chessClockManager.StartGame();
    }

    public void TogglePlayersTurn()
    {
        chessClockManager.TogglePlayersTurn();
    }

    public void ClickPlayer1()
    {
        chessClockManager.ClickPlayer1();
    }
    public void ClickPlayer2()
    {
        chessClockManager.ClickPlayer2();
    }
}
