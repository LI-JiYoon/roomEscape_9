using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUI : MonoBehaviour
{
    public GameObject achievementPanel; 

    private void Start()
    {
        achievementPanel.SetActive(false); 
    }

    public void OnClickIcon()
    {
        achievementPanel.SetActive(!achievementPanel.activeSelf);
    }
}
