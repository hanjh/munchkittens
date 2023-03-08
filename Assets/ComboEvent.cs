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
        if (CountdownTimer.isTimerActive)
        {
            totalScore += 100;
        }
    }

    public static void IncrementComboCount(ComboEventArgs args, AudioSource comboSoundEffect)
    {
        comboCount++;
        UnityEngine.Debug.Log(comboCount + ", " + comboThreshold);
        if (comboCount >= comboThreshold)
        {
            SendCombo(args, comboSoundEffect);
        }
    }

    public static void ResetComboCount(ComboEventArgs args)
    {
        comboCount = 0;
    }

    public static void SendCombo(ComboEventArgs args, AudioSource comboSoundEffect)
    {
        // Do something that triggers the event
        comboSoundEffect.Play();
        UnityEngine.Debug.Log("sending combo event");
        Combo?.Invoke(args);
    }
}
