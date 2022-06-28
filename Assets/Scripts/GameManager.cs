using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum HandType {Rock, Paper, Scissors};

    public GameObject handPrefab;
    public Sprite[] handSprites;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        int type = Random.Range(0, 3);
        player.GetComponent<SpriteRenderer>().sprite = handSprites[type];
        player.GetComponent<PlayerScript>().handType = (HandType)type;

        for (int i = 0; i < 10; i++)
        {
            GameObject hand = Instantiate(handPrefab);
            type = Random.Range(0, 3);
            hand.GetComponent<SpriteRenderer>().sprite = handSprites[type];
            hand.GetComponent<HandScript>().handType = (HandType)type;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
