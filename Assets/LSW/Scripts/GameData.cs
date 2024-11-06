using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public Vector3 playerPosition;  
    public List<string> collectedItems; 
    public Dictionary<string, bool> puzzleStates;  
    public float gameTime;  
}
