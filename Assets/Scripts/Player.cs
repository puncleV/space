using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float xPadding = 1f;
    [SerializeField] float yPadding = 1f;
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
    }

    private void setUpWorldBoundaries ()
    {
        Camera gameCamera = Camera.main;

        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    private void move()
    {
        transform.position = new Vector2(getNewXPos(), getNewYPos());
    }

    private float getNewXPos()
    {
        var deltaX = Input.GetAxis("Horizontal");
        var newXPos = transform.position.x + deltaX * Time.deltaTime * speed;

        return Mathf.Clamp(newXPos, minX + xPadding, maxX - xPadding);
    }

    private float getNewYPos()
    {
        var deltaY = Input.GetAxis("Vertical");
        var newYPos = transform.position.y + deltaY * Time.deltaTime * speed;

        return Mathf.Clamp(newYPos, minY + yPadding, maxY - yPadding);
    }

}
