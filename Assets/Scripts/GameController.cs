using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public bool isEndGame;
    bool isStartFirstTime=true;

    //for Point UI
    int gamePoint = 0;
    public Text txtPoint;

    //UI for end game panel
    public GameObject pnlEndGame;
    public Text txtEndPoint;
    public Button btnRestart;

    //different restart button
    public Sprite btnIdle, btnHover, btnClick;

    // Start is called before the first frame update
    void Start()
    {
        isStartFirstTime = true;
        Time.timeScale = 0;
        isEndGame = false;
        pnlEndGame.SetActive(false);

        //add listener to restart button
        btnRestart.onClick.AddListener(RestartGame);
        //btnRestart.OnPointerEnter();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButtonDown(0) && isStartFirstTime) //reload the scene after end game.
            {
                StartGame();
                
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) //when game start
            {
                Time.timeScale = 1;
            }
        }
    }

    //public void RestartButtonClick()
    //{
    //    btnRestart.GetComponent<Image>().sprite = btnClick;
    //}
    //public void RestartButtonHover()
    //{
    //    btnRestart.GetComponent<Image>().sprite = btnHover;
    //}
    //public void RestartButtonIdle()
    //{
    //    btnRestart.GetComponent<Image>().sprite = btnIdle;
    //}

    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    void RestartGame()
    {
        StartGame();
    }

    public void EndGame()
    {
        isStartFirstTime = false;
        isEndGame = true;
        Time.timeScale = 0; //freeze everything when end game
        pnlEndGame.SetActive(true); //set the panel to blur background when end game
        txtEndPoint.text = "Your point: " + gamePoint.ToString(); //display point at end game
    }
}
