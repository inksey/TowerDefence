using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour
{
    public List<GameObject> enemiesInRange;
   
   void OnTriggerEnter2D (Collider2D other)
{
    if (other.gameObject.tag.Equals("Enemy"))
        enemiesInRange.Add(other.gameObject);
}

void OnTriggerExit2D (Collider2D other)
{
    if (other.gameObject.tag.Equals("Enemy"))
        enemiesInRange.Remove(other.gameObject);
}

    void Start()
    {
        enemiesInRange = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
