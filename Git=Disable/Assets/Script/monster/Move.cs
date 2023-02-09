using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D PlayerRigidbody;

    private void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        PlayerRigidbody.velocity = newVelocity;
    }
}

