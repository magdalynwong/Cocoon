using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CaterpillarBody : MonoBehaviour
{
    public PointsManager pointsManager;
    public TMP_Text pauseText;
    public TMP_Text gamePoints;
    public Button playAgainButton;
    public Button mainMenuButton;

    private void OnTriggerEnter(Collider other)
    {
        // end game if caterpillar head crashes into body 
        CaterpillarMovement caterpillarHead = other.gameObject.GetComponent<CaterpillarMovement>();
        if (caterpillarHead != null)
        {
            caterpillarHead.EndGame();
        }
    }
}
