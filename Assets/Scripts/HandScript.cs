using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    private Vector3 newPosition;
    private float xMinBounds;
    private float xMaxBounds;
    private float yMinBounds;
    private float yMaxBounds;
    private float xSpeed;
    private float ySpeed;
    private float margin = 40;
    public GameManager.HandType handType;

    // Start is called before the first frame update
    void Start()
    {
        SetupEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void SetupEnemy()
    {
        GameObject canvas = GameObject.Find("Canvas");
        RectTransform rect = canvas.GetComponent<RectTransform>();
        xMinBounds = rect.position.x - rect.rect.width / 2 + margin;
        xMaxBounds = rect.position.x + rect.rect.width / 2 - margin;
        yMinBounds = rect.position.y - rect.rect.height / 2 + margin;
        yMaxBounds = rect.position.y + rect.rect.height / 2 - margin;
        xSpeed = Random.Range(50f, 100f);
        ySpeed = Random.Range(50f, 100f);
        transform.parent = canvas.transform;
        transform.position = GetRandomSpawnPosition();
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3((Random.value < 0.5f ? xMinBounds - margin : xMaxBounds + margin), (Random.value < 0.5f ? yMinBounds - margin : yMaxBounds + margin), 0);
    }

    private void MoveEnemy()
    {
        transform.Translate(new Vector3(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime));

        if (transform.position.x < xMinBounds) xSpeed = Mathf.Abs(xSpeed);
        else if (transform.position.x > xMaxBounds) xSpeed = -Mathf.Abs(xSpeed);
        if (transform.position.y < yMinBounds) ySpeed = Mathf.Abs(ySpeed);
        else if (transform.position.y > yMaxBounds) ySpeed = -Mathf.Abs(ySpeed);
    }
}
