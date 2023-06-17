using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float speed = .25f;
    float facingAngle = 0f;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FacePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        var currSpeed = rb2D.velocity.magnitude;
        var newSpeed = currSpeed - 20 * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            rb2D.AddForce(gameObject.transform.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            rb2D.velocity = rb2D.velocity.normalized * newSpeed;
    }

    void FacePosition(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        facingAngle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3(0, 0, facingAngle-90);
    }
}
