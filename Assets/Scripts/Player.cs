﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float xPadding = 1f;
    [SerializeField] float yPadding = 0.5f;
    [SerializeField] GameObject lazerPrefab;
    [SerializeField] float baseLazerSpeed = 10f;

    float maxX;
    float minX;
    float maxY;
    float minY;
    // Start is called before the first frame update
    void Start()
    {
        setUpWorldBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        fire();
    }

    private void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var shotPosition = new Vector3(transform.position.x, transform.position.y + yPadding, transform.position.z);
            var shot = Instantiate(lazerPrefab, shotPosition, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, baseLazerSpeed);
        }
    }

    private void setUpWorldBoundaries ()
    {
        Camera gameCamera = Camera.main;

        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;

        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yPadding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPadding;
    }

    private void move()
    {
        transform.position = new Vector2(getNewXPos(), getNewYPos());
    }

    private float getNewXPos()
    {
        var deltaX = Input.GetAxis("Horizontal");
        var newXPos = transform.position.x + deltaX * Time.deltaTime * speed;

        return Mathf.Clamp(newXPos, minX, maxX);
    }

    private float getNewYPos()
    {
        var deltaY = Input.GetAxis("Vertical");
        var newYPos = transform.position.y + deltaY * Time.deltaTime * speed;

        return Mathf.Clamp(newYPos, minY, maxY);
    }

}
