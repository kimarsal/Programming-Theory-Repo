using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameManager.HandType handType;
    private float xMinBounds;
    private float xMaxBounds;
    private float yMinBounds;
    private float yMaxBounds;
    private float margin = 40;
    public float speed = 100f;

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        RectTransform rect = canvas.GetComponent<RectTransform>();
        xMinBounds = rect.position.x - rect.rect.width / 2 + margin;
        xMaxBounds = rect.position.x + rect.rect.width / 2 - margin;
        yMinBounds = rect.position.y - rect.rect.height / 2 + margin;
        yMaxBounds = rect.position.y + rect.rect.height / 2 - margin;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

        if (transform.position.x < xMinBounds) transform.position = new Vector3(xMinBounds, transform.position.y, 0);
        else if (transform.position.x > xMaxBounds) transform.position = new Vector3(xMaxBounds, transform.position.y, 0);
        if (transform.position.y < yMinBounds) transform.position = new Vector3(transform.position.y, yMinBounds, 0);
        else if (transform.position.y > yMaxBounds) transform.position = new Vector3(transform.position.y, yMaxBounds, 0);
    }
}
