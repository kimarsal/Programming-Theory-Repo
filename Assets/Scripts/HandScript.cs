using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandScript : MonoBehaviour
{
    public enum HandType { Rock, Paper, Scissors };
    protected Sprite[] handSprites = new Sprite[3];
    private HandType type;
    protected float xMinBounds;
    protected float xMaxBounds;
    protected float yMinBounds;
    protected float yMaxBounds;
    protected float margin = 40;

    public HandType Type {
        get => type;
        set {
            type = value;
            gameObject.GetComponent<SpriteRenderer>().sprite = handSprites[(int)value];
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
        GameObject canvas = GameObject.Find("Canvas");
        RectTransform rect = canvas.GetComponent<RectTransform>();
        xMinBounds = rect.position.x - rect.rect.width / 2 + margin;
        xMaxBounds = rect.position.x + rect.rect.width / 2 - margin;
        yMinBounds = rect.position.y - rect.rect.height / 2 + margin;
        yMaxBounds = rect.position.y + rect.rect.height / 2 - margin;
        transform.parent = canvas.transform;

        handSprites[0] = Resources.Load<Sprite>("Rock");
        handSprites[1] = Resources.Load<Sprite>("Paper");
        handSprites[2] = Resources.Load<Sprite>("Scissors");
    }

    protected abstract void Move();

    public abstract void LoseGame();
}