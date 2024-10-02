﻿using UnityEngine;
using System;

[CreateAssetMenu]
[Serializable]
public class TimeObject : ScriptableObject
{
    [Header("All variables are derived from Time")]
    [SerializeField] private float time = 0f;

    public int day = 0;
    public int hour = 0;
    public int minute = 0;
    public string dayString = "";
    public string timeString = "";

    public TimeObject()
    {
        UpdateVars();
    }

    public TimeObject(float value)
    {
        Set(value);
    }

    public void Set(float newTime)
    {
        time = newTime;
        UpdateVars();
    }

    public float GetTime()
    {
        return time;
    }

    public void Inc(float increment)
    {
        time += increment;
        UpdateVars();
    }

    public void SetNextDay(float newHour)
    {
        time = (day * 24f) + newHour; // +1 day is done in UpdateVars for displaying
        UpdateVars();
    }

    private void UpdateVars()
    {
        day = (int)(time / 24f) + 1; // Days start at day 1
        hour = (int)(time % 24f);
        minute = (int)((time - (int)time) * 60f);
        dayString = "Day " + day;
        timeString = hour.ToString("00") + ":" + minute.ToString("00");
    }
}