using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : HandScript
{
    public float speed = 100f;

    protected override void Setup()
    {
        base.Setup();
        Type = (HandType)Random.Range(0, 3);
    }

    protected override void Move()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

        if (transform.position.x < xMinBounds) transform.position = new Vector3(xMinBounds, transform.position.y, 0);
        else if (transform.position.x > xMaxBounds) transform.position = new Vector3(xMaxBounds, transform.position.y, 0);
        if (transform.position.y < yMinBounds) transform.position = new Vector3(transform.position.x, yMinBounds, 0);
        else if (transform.position.y > yMaxBounds) transform.position = new Vector3(transform.position.x, yMaxBounds, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        int i = (int)Type;
        int j = (int)other.GetComponent<HandScript>().Type;
        int qt = 0;
        while (i != j)
        {
            i = (i + 1) % 3;
            qt++;
        }
        switch (qt)
        {
            case 1: LoseGame(); break;
            case 2: other.GetComponent<HandScript>().LoseGame(); ChangeType(); break;
        }
    }

    public override void LoseGame()
    {
        Debug.Log("Enemy wins");
        Destroy(gameObject);
    }

    private void ChangeType()
    {
        int type = ((int)Type + 1) % 3;
        gameObject.GetComponent<SpriteRenderer>().sprite = handSprites[type];
        Type = (HandType)type;
    }
}
