using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilemanager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] tilePrefabs;
    public GameObject Tokens;


    private Transform player;
    private float spawner = -4.0f;
    private Queue<int> tileQueue = new Queue<int>();
    private int bounce = 0;
    private bool safezone = true;
    private float playerLocation = 1;
    private System.Random num = new System.Random();
    private Queue<GameObject> used;
    private Queue<GameObject> coins;
    void Start()
    {
        used = new Queue<GameObject>();
        coins = new Queue<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tileQueue.Enqueue(0);
        tileQueue.Enqueue(0);
        tileQueue.Enqueue(0);
        tileQueue.Enqueue(5);
        tileQueue.Enqueue(5);
        for (int i = 0; i < 30; i++) {
            createTile();
        }
        for (int i = 0; i < 30; i++)
        {
            spawnT();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Mathf.Floor(player.position.z) > playerLocation)
        {
            playerLocation = Mathf.Floor(player.position.z);
            createTile();
            spawnT();
            if (playerLocation > 9)
            {
                safezone = false;
            }
            if (playerLocation > 40 && playerLocation% 2 == 0 ) {
                if (coins.Count != 0)
                {
                    deleteCoin(coins.Dequeue());
                }
            }
        }
    }
    void createTile() {
          
            if (bounce%3 != 0)
            {
                tileQueue.Enqueue(num.Next(0, 9));
            }
            else if(bounce % 3 == 0)
            {
                tileQueue.Enqueue(num.Next(9, 14));                
            }
            bounce++;
    }

    void deleteTile() {
        Destroy(used.Dequeue());
    }
    void deleteCoin(GameObject passedCoin) {
        Destroy(passedCoin);
    }
    void spawnT(int prefabNum =-1)
    {
        int newtile = tileQueue.Dequeue();
        GameObject hall;        
        hall = Instantiate(tilePrefabs[newtile]) as GameObject;
        used.Enqueue(hall);        
        hall.transform.SetParent(transform);
        hall.transform.position = Vector3.forward * spawner;

        // coin spawner that rand. places a coin at the top of the hall in the middle left, top, or right 
        // also begin to despawn passed tiles
        if (safezone == false)
        {
            deleteTile();
            if (newtile % 2 == 0)
            {
                GameObject token;
                token = Instantiate(Tokens) as GameObject;
                coins.Enqueue(token);
                token.transform.SetParent(transform);
                Vector3 spawnpoint = new Vector3();
                spawnpoint.z = 1 * spawner;
                spawnpoint.x = -1 + newtile % 3;
                spawnpoint.y = -0.6f;
                token.transform.position = spawnpoint;
            }
        }

        spawner += 1;
    }

}
