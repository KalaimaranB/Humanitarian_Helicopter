using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float timeRemaining;
    public bool timerIsRunning = false;
    public string TimeDisplay;

    public event EventHandler TimerFinished;

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                TimerFinished?.Invoke(this, EventArgs.Empty);
                timerIsRunning = false;
            }
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        TimeDisplay = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public void PauseTimer()
    {
        timerIsRunning = false;
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void SetTimer(float time)
    {
        timeRemaining = time;
    }

    public Timer(float timerTime)
    {
        timeRemaining = timerTime;
    }
}
