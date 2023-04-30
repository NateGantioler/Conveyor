using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static int score;
    static int correctPackagePoints;
    static int wrongPackagePoints;

    public static void AddScore()
    {
        score += correctPackagePoints;
    }
    public static void SubtractScore()
    {
        score -= wrongPackagePoints;
    }

}
