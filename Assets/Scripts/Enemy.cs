using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Originally made for a old game jam but was modified
public class Enemy : MonoBehaviour
{
    //[SerializeField] bool infinateSight = false;
    float health = 100f;

    [SerializeField] float movementSpeed = 1f;

    [SerializeField] Transform player;

    public bool invunrable = false;

    // Shooting variables
    [SerializeField] GameObject firePoint;
    [SerializeField] GameObject enemyGun;

    float facingAngle = 0f;
    LineRenderer lineRenderer;
    float waitTime = 2f;
    bool isShooting = false;

    void Start()
    {
        health = 100f;

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = .1f;
        lineRenderer.endWidth = .1f;
    }

    void Update()
    {
        // movement
        if ((Vector3.Distance(transform.position, player.position) >= 8f && Vector3.Distance(transform.position, player.position) <= 20f))
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * movementSpeed * Time.deltaTime);
        }
        // attack the player
        if (Vector3.Distance(transform.position, player.position) <= 8f)
        {
            if (!isShooting)
                FireGun();
        }

        if (health < 0)
            Destroy(gameObject);

        FacePlayer(player.position);
    }

    void FacePlayer(Vector3 playerPos)
    {
        Vector3 direction = playerPos - transform.position;
        facingAngle = Vector2.SignedAngle(Vector2.right, direction);
        enemyGun.transform.eulerAngles = new Vector3(0, 0, facingAngle - 90);
    }

    void FireGun()
    {
        StartCoroutine(ShootWithDelay());
    }

    IEnumerator ShootWithDelay()
    {
        isShooting = true;

        Debug.Log("Enemy is shooting...");
        RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, firePoint.transform.up);
        Debug.Log("Enemy has fired");

        yield return new WaitForSeconds(waitTime);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Debug.Log("Hit the player!!!");
            Player player = hit.transform.GetComponent<Player>();
            player.TakeDamage();
        }
        else
        {
            Debug.Log("Did not hit the player");
        }

        // Draw a line
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePoint.transform.position);
        lineRenderer.SetPosition(1, hit.transform.position);

        isShooting = false;
    }

    // Public functions
    public void TakeDamage()
    {
        health -= 15;
    }
}
