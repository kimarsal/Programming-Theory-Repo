using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : HandScript
{
    private Vector3 newPosition;
    private float xSpeed;
    private float ySpeed;

    protected override void Setup()
    {
        base.Setup();
        xSpeed = Random.Range(50f, 100f);
        ySpeed = Random.Range(50f, 100f);
        transform.position = GetRandomSpawnPosition();
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3((Random.value < 0.5f ? xMinBounds - margin : xMaxBounds + margin), (Random.value < 0.5f ? yMinBounds - margin : yMaxBounds + margin), 0);
    }

    protected override void Move()
    {
        transform.Translate(new Vector3(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime));

        if (transform.position.x < xMinBounds) xSpeed = Mathf.Abs(xSpeed);
        else if (transform.position.x > xMaxBounds) xSpeed = -Mathf.Abs(xSpeed);
        if (transform.position.y < yMinBounds) ySpeed = Mathf.Abs(ySpeed);
        else if (transform.position.y > yMaxBounds) ySpeed = -Mathf.Abs(ySpeed);
    }

    public override void LoseGame()
    {
        gameManager.EnemyLose(transform.position);
        Destroy(gameObject);
    }
}
