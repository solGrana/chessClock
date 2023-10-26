using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeSelection : MonoBehaviour
{
    public Dropdown dropdown; // Asigns object Dropdown from Inspector.
    public ChessClockManager chessClockManager;

    public int selectedTimeInMinutes = 10; //  default = 10 minutes.


    void Start()
    {
        // listens Dropdown event to know when selection is changed.
        dropdown.onValueChanged.AddListener(UpdateSelectedTime);
    }
   /* public void SetInitialTime(int minutes)
    {
        // chessClockManager.SetInitialTime(minutes);
        chessClockManager.RestartClock();
    }*/

    public void UpdateSelectedTime(int index)
    {
        // update var with selected time in minutes
        selectedTimeInMinutes = index switch
        {
            0 => 1,    // Op 0  Dropdown represents 1 minute.
            1 => 5,    // Op 1  Dropdown represents 5 minutes.
            2 => 10,   // Op 2  Dropdown represents 10 minutes.
            3 => 20,   // Op 3  Dropdown represents 20 minutes.
            _ => 10,   // default = 10 minutes.
        };
        Debug.Log("Entro al Update selecteed time");
        Debug.Log($"selecteed time: {selectedTimeInMinutes}");

        // updates clock with new time selected
        chessClockManager.SetInitialTime(selectedTimeInMinutes);
        chessClockManager.RestartClock();
        // save var in playerprefs
        PlayerPrefs.SetInt("SelectedMinutes", selectedTimeInMinutes);
    }
}
