using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GenericSingleton<Player>
{
    public float health = 100f; 

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        Death();
    }

    public void TakeDamage()
    {
        health -= 10f;
    }

    void Death()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
            GunController gunController = gameObject.GetComponentInChildren<GunController>();
            gunController.canShoot = false;
        }
    }
}
