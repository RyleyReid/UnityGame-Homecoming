using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class deathmenu : MonoBehaviour
{
    public Text scoreText;
    public Text tokenText;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleEndMenu(float points, int tokens) {
        gameObject.SetActive(true);
        scoreText.text = ((int)points).ToString();
        tokenText.text = tokens.ToString();
    }

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMain() {
        SceneManager.LoadScene("Menu");
    }
}
