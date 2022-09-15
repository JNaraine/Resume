using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayB : MonoBehaviour
{
    private Button button;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(playGame);
        player = GameObject.Find("Player").GetComponent<Player>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //When player click play the game will start
    public void playGame()
    {

        player.StartGame();
        Debug.Log(gameObject.name + " was clicked");
    }
}
