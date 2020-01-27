using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Player
{
    public Image panel;
    public Button button;

}
[System.Serializable]
public class PlayerColor
{
    public Color PanelColor;
}

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text[] buttontext;
    private string playerSide = "X";

    public GameObject Winninpanel;
    public Text Wintext;
    public GameObject PlayAgain;
    public Text turn;
    public GameObject ResetBtn;
    private int moveCount = 0;

    public Player PLayerX;
    public Player PLayerO;
    public PlayerColor ActiveColor;
    public PlayerColor inactiveColor;

    public AudioSource PlayerXAudio;
    public AudioSource PlayerOAudio;

    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        Winninpanel.SetActive(false);
        PlayAgain.SetActive(false);
        turn.text = "Choose Side!";
        ResetBtn.SetActive(false);
        setPlayerButtons(true);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSatringSide(string Startingside)
    {
        playerSide = Startingside;
        if (playerSide == "X")
        {
            SetPanelColor(PLayerX, PLayerO);
            turn.text = "X turn";

        }
        else
        {
            SetPanelColor(PLayerO, PLayerX);
            turn.text = "O turn";
        }
        StartGame();
    }

    void StartGame()
    {
        SetBoardInteractable(true);
        setPlayerButtons(false);
    }

    public void ControllTheGame()
    {
        for (int i = 0; i < buttontext.Length; i++)
        {
            buttontext[i].GetComponentInParent<SetUpOX>().SetGameController(this);
        }
    }
    public string GetPlaySide()
    {
        return playerSide;
    }
    public void Endturn()
    {

        //Debug.Log("Trun completed");

        if (buttontext[0].text == playerSide && buttontext[1].text == playerSide && buttontext[2].text == playerSide)
        {
            GameOver();
        }


        else if (buttontext[0].text == playerSide && buttontext[3].text == playerSide && buttontext[6].text == playerSide)
        {
            GameOver();
        }


        else if (buttontext[0].text == playerSide && buttontext[4].text == playerSide && buttontext[8].text == playerSide)
        {
            GameOver();
        }


        else if (buttontext[1].text == playerSide && buttontext[4].text == playerSide && buttontext[7].text == playerSide)
        {
            GameOver();
        }


        else if (buttontext[3].text == playerSide && buttontext[4].text == playerSide && buttontext[5].text == playerSide)
        {
            GameOver();
        }


        else if (buttontext[6].text == playerSide && buttontext[7].text == playerSide && buttontext[8].text == playerSide)
        {
            GameOver();
        }


        else if (buttontext[2].text == playerSide && buttontext[5].text == playerSide && buttontext[8].text == playerSide)
        {
            GameOver();
        }


        else if (buttontext[2].text == playerSide && buttontext[4].text == playerSide && buttontext[6].text == playerSide)
        {
            GameOver();
        }
        else
        {
            ChangeSide();
        }

        if (moveCount >= 1)
            ResetBtn.SetActive(true);

    }


    private void SetPanelColor(Player newplayer, Player oldpplayer)
    {
        newplayer.panel.color = ActiveColor.PanelColor;
        oldpplayer.panel.color = inactiveColor.PanelColor;
    }

    private void GameOver()
    {
        for (int i = 0; i < buttontext.Length; i++)
        {
            buttontext[i].GetComponentInParent<Button>().interactable = false;
        }
        SetPlayerColorInactive();
        setText("" + playerSide + " Win This Game");
    }
    private void ChangeSide()
    {
        moveCount++;
        if (playerSide == "X")
        {
            playerSide = "O";
            turn.text = "" + playerSide + " turn";
            SetPanelColor(PLayerO, PLayerX);
            PlayerXAudio.Play();
        }
        else
        {
            playerSide = "X";
            turn.text = "" + playerSide + " turn";
            SetPanelColor(PLayerX, PLayerO);
            PlayerOAudio.Play();
        }
        if (moveCount >= 9)
        {
            setText("It's Draw");
        }

    }
    void setText(string value)
    {
        Winninpanel.SetActive(true);
        Wintext.text = value;
        PlayAgain.SetActive(true);
        turn.gameObject.SetActive(false);
        ResetBtn.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttontext.Length; i++)
        {
            //Debug.Log("Value" + toggle);
            buttontext[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void setPlayerButtons(bool toogle)
    {
        PLayerX.button.gameObject.SetActive(toogle);
        PLayerO.button.gameObject.SetActive(toogle);
    }

    void SetPlayerColorInactive()
    {
        PLayerO.panel.color = inactiveColor.PanelColor;
        PLayerX.panel.color = inactiveColor.PanelColor;
    }
}
