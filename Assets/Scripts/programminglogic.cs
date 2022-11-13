using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class programminglogic : MonoBehaviour
{
    public InputField playerInputArea;
    public Text locationLabel;
    public string playerOutput;
    public string beforeInput;
    public int i;
    public string text;
    public string ifWord;
    public string str;
     public string myCustomString;
    // Start is called before the first frame update


    public class closers
    {
        public string Bracket { get; set; }
        public string Paren { get; set; }

        public closers(string bracket, string paren) {
            Bracket = bracket;
            Paren = paren;
        }
       // Other properties, methods, events...
    }

    public class operands
    {
        public string EqualTo { get; set; }

        public operands(string equalTo) {
            EqualTo = equalTo;
        }

    }

    public class statements
    {
        public string Ifer { get; set; }

        public statements(string ifer) {
            Ifer = ifer;
        }

    }

    public class integers
    {
        public string Io { get; set; }

        public integers(string io) {
            Io= io;
        }

    }

    public class doorA
    {
        public string FuncA { get; set; }
        public string FuncB { get; set; }

        public doorA(string funcA, string funcB) {
            FuncA = funcA;
            FuncB = funcB;
        }

    }

    public class buttonA
    {
        public string FuncA { get; set; }

        public buttonA(string funcA) {
            FuncA = funcA;
        }

    }


    void Start()
    {
        locationLabel.text = "<color=yellow>" + statecontroller.middleUserAccess + "</color>" + " press escape to exit";
        if (statecontroller.middleUserAccess == "[root-DOORA]>" && statecontroller.doorOpenIf1 == false) {

            playerInputArea.text = "if (buttonA.Input == 1) { \n \n doorA.Open \n \n }";

        } else {
            playerInputArea.text = "if (buttonA.Input == 0) { \n \n doorA.Open \n \n }";
        }
    }

    public closers openClosers = new closers("{", "(");
    public closers closedClosers = new closers("}", ")");
    public statements ifStatement = new statements("if");
    public doorA startDoor = new doorA("doorA.Open", "doorA.Close");
    public buttonA startButton = new buttonA("buttonA.Input");
    public operands basicOp = new operands("==");
    public integers one = new integers("1");
    public integers zero = new integers("0");

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            
            SceneManager.LoadScene("SampleScene");
        }
        //An if statement that will check and see if the user inputs certain text
        str = playerInputArea.text.Replace(" ", string.Empty);
        str = str.Replace("\n", string.Empty);

         if (statecontroller.middleUserAccess == "[root-DOORA]>") {
            if (str.Contains(ifStatement.Ifer + openClosers.Paren + startButton.FuncA + basicOp.EqualTo + zero.Io + closedClosers.Paren
            + openClosers.Bracket + startDoor.FuncA + closedClosers.Bracket) ) {

            statecontroller.doorOpenIf1 = true;
        }
        }

    }
}
