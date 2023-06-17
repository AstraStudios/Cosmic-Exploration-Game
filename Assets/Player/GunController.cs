using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    float facingAngle = 0f;

    // weapon variables
    [SerializeField] float damage;
    [SerializeField] GameObject firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FacePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    void FacePosition(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        facingAngle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3(0, 0, facingAngle - 90);
    }

    void Shoot()
    {
        Debug.Log("Shooting...");
        RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, firePoint.transform.up);
        Debug.Log("Fired sucessfully");

        if (hit.collider.CompareTag("Enemy"))
        {
            Enemy.Instance.health -= 15;
            print("Hit an enemy");
        }
    }
}
