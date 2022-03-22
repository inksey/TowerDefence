using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    public Text goldLabel;
    private int gold;
    public Text waveLabel;
    public GameObject[] nextWaveLabels;

    public int Gold
        {   
                get { return gold; }
                set
            {
                gold = value;
                goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
            }
  
        }


    void Start()
    {
        Gold = 1000;
    }

    
    void Update()
    {
        
    }
}
