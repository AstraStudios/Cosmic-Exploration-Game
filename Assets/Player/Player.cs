using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GenericSingleton<Player>
{
    float health = 100f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        if (health < 0)
        {
            Time.timeScale = 0;
            GunController gunController = gameObject.GetComponentInChildren<GunController>();
            gunController.canShoot = false;
        }
    }

    public void TakeDamage()
    {
        health -= 10f;
    }
}
