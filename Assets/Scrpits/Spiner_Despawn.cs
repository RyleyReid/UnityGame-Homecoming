using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spiner_Despawn: MonoBehaviour
{ 
    private System.Random num = new System.Random();
    // Start is called before the first frame update
    void Start()
    { }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate( num.Next(1, 10), num.Next(1,10),num.Next(1, 10));
    }
}
