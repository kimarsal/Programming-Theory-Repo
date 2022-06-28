using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Hand
{
    public float speed = 100f;

    protected override void Setup()
    {
        BasicSetup();
    }

    protected override void Move()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

        if (transform.position.x < xMinBounds) transform.position = new Vector3(xMinBounds, transform.position.y, 0);
        else if (transform.position.x > xMaxBounds) transform.position = new Vector3(xMaxBounds, transform.position.y, 0);
        if (transform.position.y < yMinBounds) transform.position = new Vector3(transform.position.y, yMinBounds, 0);
        else if (transform.position.y > yMaxBounds) transform.position = new Vector3(transform.position.y, yMaxBounds, 0);
    }
}
