using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaceMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    private GameObject monster;
   
    void Start()
    {
        
    }

    private bool CanPlaceMonster()
        {
        return monster == null;
        }

    void OnMouseUp()
        {
        if (CanPlaceMonster())
        {
            monster = (GameObject)Instantiate(monsterPrefab, transform.position, Quaternion.identity);

            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            // TODO: Deduct gold
        }
        } 


    void Update()
    {
        
    }
}
