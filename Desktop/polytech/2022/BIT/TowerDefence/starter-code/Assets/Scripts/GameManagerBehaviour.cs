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
    public bool gameOver = false;

    public int Gold
        {   
                get { return gold; }
                set
            {
                gold = value;
                goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
            }
  
        }

    private int wave;
    public int Wave
        {
            get { return wave; }
            set
            {
                wave = value;
                if (!gameOver)
                {
                    for (int i = 0; i < nextWaveLabels.Length; i++)
                    {
                        nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                    }
                }
                waveLabel.text = "WAVE: " + (wave + 1);
            }
        }


    void Start()
    {
        Gold = 1000;
        Wave = 0;
    }

    
    void Update()
    {
        
    }
}
