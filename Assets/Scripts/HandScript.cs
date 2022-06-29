using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandScript : MonoBehaviour
{
    public enum HandType { Rock, Paper, Scissors };
    private HandType type;
    protected float xMinBounds;
    protected float xMaxBounds;
    protected float yMinBounds;
    protected float yMaxBounds;
    protected float margin = 40;
    protected GameManager gameManager;

    public HandType Type {
        get => type;
        set {
            type = value;
            if (gameManager == null) Setup();
            gameObject.GetComponent<SpriteRenderer>().sprite = gameManager.handSprites[(int)value];
        }
    }

    void Start()
    {
        Setup();
    }

    private void Update()
    {
        Move();
    }

    protected virtual void Setup()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject canvas = GameObject.Find("Canvas");
        RectTransform rect = canvas.GetComponent<RectTransform>();
        xMinBounds = rect.position.x - rect.rect.width / 2 + margin;
        xMaxBounds = rect.position.x + rect.rect.width / 2 - margin;
        yMinBounds = rect.position.y - rect.rect.height / 2 + margin;
        yMaxBounds = rect.position.y + rect.rect.height / 2 - margin;
        transform.parent = canvas.transform;
    }

    protected abstract void Move();

    public abstract void LoseGame();
}