using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ColorEnum { White, Black, Orange };

public class RandomEnumGenerator : MonoBehaviour
{
    public ColorEnum GenerateRandomColorEnum()
    {
        Array values = Enum.GetValues(typeof(ColorEnum));
        System.Random random = new System.Random();

        return (ColorEnum)values.GetValue(random.Next(values.Length));
    }
}