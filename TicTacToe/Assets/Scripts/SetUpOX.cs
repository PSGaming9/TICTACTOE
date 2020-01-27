using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetUpOX : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    //public string playerside;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetSpace()
    {
        buttonText.text = GameController.instance.GetPlaySide();
        button.interactable = false;
        GameController.instance.Endturn();
    }

    public void SetGameController(GameController controller)
    {
        GameController.instance = controller;
    }
}
