using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hand : MonoBehaviour
{
    public enum HandType { Rock, Paper, Scissors };
    private Sprite[] handSprites = new Sprite[3];
    protected HandType handType;
    protected float xMinBounds;
    protected float xMaxBounds;
    protected float yMinBounds;
    protected float yMaxBounds;
    protected float margin = 40;

    void Start()
    {
        Setup();
    }

    private void Update()
    {
        Move();
    }

    protected abstract void Setup();

    protected abstract void Move();

    protected void BasicSetup()
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
        int type = Random.Range(0, 3);
        gameObject.GetComponent<SpriteRenderer>().sprite = handSprites[type];
        handType = (HandType)type;
    }
}