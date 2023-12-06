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

    public float getCurrentScore()
    {
        return score;
    }

    private void UpdatePointsText()
    {
        points.text = "Points: " + score;
    }

    public void ResetPoints()
    {
        score = 0;
        UpdatePointsText();
    }
}