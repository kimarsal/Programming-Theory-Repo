using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject handPrefab;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        for (int i = 0; i < 10; i++)
        {
            GameObject hand = Instantiate(handPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
