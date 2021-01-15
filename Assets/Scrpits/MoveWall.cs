using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private Transform following;
    private Vector3 offset;
    private Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        following = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - following.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = following.position + offset;

        //X
        moveVector.x = 0f;
        transform.position = moveVector;

    }
}
