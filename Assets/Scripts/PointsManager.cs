using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public TMP_Text points;
    private static float score = 0;

    public float getScore()
    {
        return score;
    }

    public void updatePoints(float pointsToIncrement)
    {
        score += pointsToIncrement;
        points.text = "Points: " + score;
    }
}

