using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int numOfKills;

    float facingAngle = 0f;

    // weapon variables
    [SerializeField] GameObject firePoint;
    public bool canShoot;

    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        numOfKills = 0;

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = .1f;
        lineRenderer.endWidth = .1f;

        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot == true)
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
        RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, firePoint.transform.up);

        if (hit.collider.CompareTag("Enemy"))
        {
            Enemy hitEnemy = hit.transform.GetComponent<Enemy>();
            hitEnemy.TakeDamage();
            if (hitEnemy.dead == true)
            {
                numOfKills++;
                Destroy(hitEnemy.gameObject);
            }
        }

        // draw a line
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePoint.transform.position);
        lineRenderer.SetPosition(1, hit.point);
    }
}
