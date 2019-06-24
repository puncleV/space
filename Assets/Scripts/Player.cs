using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
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
