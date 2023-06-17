using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made for a old game jam
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
        if (Physics2D.OverlapCircle(transform.position,2f))
        {
            StartCoroutine(WaitForSeconds());
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
        Debug.Log("Enemy is shooting...");
        RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, firePoint.transform.up);
        Debug.Log("Enemy has fired");

        if (hit.collider.CompareTag("Player"))
        {
            Debug.Log("Hit the player!!!");
            Player player = hit.transform.GetComponent<Player>();
            player.TakeDamage();
        }
        Debug.Log("Did not hit the player");
        // draw a line
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePoint.transform.position);
        lineRenderer.SetPosition(1, hit.point);
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(waitTime);
        FireGun();
    }

    // Public functions
    public void TakeDamage()
    {
        health -= 15;
    }
}
