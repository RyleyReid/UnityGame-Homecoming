using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    private float Score = 0.0f;

    public Text scoreText;
    private bool dead = false;
    private Transform player;
    private int tokens = 0;

    public deathmenu deathmenu;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) {
            return;
        }
        Score = player.position.z;
        Score = Mathf.Clamp(Score, 0f, float.MaxValue);
        scoreText.text = (Mathf.Floor(Score)).ToString();
    }
    public void EndScore() {
        dead = true;
        tokens = GetComponent<PlayerMotor>().finalTokens();
        deathmenu.ToggleEndMenu(Score, tokens);
    }
}
