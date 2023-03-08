using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboEventManager : MonoBehaviour
{
    public static int totalScore = 0;
    public static int comboCount = 0;
    private static int comboThreshold = 3;
    public class ComboEventArgs : EventArgs
    {
        public string data;
    }

    public delegate void ComboEvent(ComboEventArgs args);
    public static event ComboEvent Combo;

    public static void IncrementTotalScore(ComboEventArgs args)
    {
        totalScore += 100;
    }

    public static void IncrementComboCount(ComboEventArgs args)
    {
        comboCount++;
        if (comboCount >= comboThreshold)
        {
            comboCount = 0;
            SendCombo(args);
        }
    }

    public static void ResetComboCount(ComboEventArgs args)
    {
        comboCount = 0;
    }

    public static void SendCombo(ComboEventArgs args)
    {
        // Do something that triggers the event
        UnityEngine.Debug.Log("sending combo event");
        Combo?.Invoke(args);
    }
}
