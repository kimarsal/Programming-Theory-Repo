using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        for (int i = 0; i < 12; i++)
        {
            GameObject hand = Instantiate(enemyPrefab);
            hand.GetComponent<EnemyScript>().Type = (HandScript.HandType)(i % 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
