using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboEventManager : MonoBehaviour
{
    public class ComboEventArgs : EventArgs
    {
        public string data;
    }

    public delegate void ComboEvent(ComboEventArgs args);
    public static event ComboEvent Combo;

    public static void SendCombo(ComboEventArgs args)
    {
        // Do something that triggers the event
        UnityEngine.Debug.Log("sending combo event");
        Combo?.Invoke(args);
    }
}
