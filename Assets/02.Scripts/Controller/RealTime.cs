using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class RealTime : MonoBehaviour
{
    public static RealTime instance;

    public string lastDay;
    public string ToDay;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        lastDay = UserData.data.lastCheckedDate.ToString("dd/MM/yyyy");
        ToDay = DateTime.Now.ToString("dd/MM/yyyy");
    }

    public bool IsNewDay()
    {
        DateTime toDay = DateTime.Now.Date;

        if (toDay != UserData.data.lastCheckedDate)
        {
            UserData.data.lastCheckedDate = toDay;
            UserData.SaveData();
            return true;
        }

        return false;
    }

    public bool IsNewWeek()
    {
        DateTime currentDate = DateTime.Now.Date;

        int lastCheckedWeek = GetWeekOfYear(UserData.data.lastCheckedDate);
        int currentWeek = GetWeekOfYear(currentDate);

        return currentWeek != lastCheckedWeek;
    }

    private int GetWeekOfYear(DateTime date)
    {
        CultureInfo culture = CultureInfo.CurrentCulture;
        Calendar calendar = culture.Calendar;

        return calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
    }
}
