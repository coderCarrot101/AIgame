using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class programminglogic : MonoBehaviour
{
    public InputField playerInputArea;
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


    void Start()
    {

    }

    public closers openClosers = new closers("{", "(");
    public closers closedClosers = new closers("}", ")");
    public statements ifStatement = new statements("if");
    public integers one = new integers("1");
    public integers zero = new integers("0");

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {

        }
        //An if statement that will check and see if the user inputs certain text
        str = playerInputArea.text.Replace(" ", string.Empty);
        str = str.Replace("\n", string.Empty);
        if (str.Contains(ifStatement.Ifer + openClosers.Paren + one.Io + closedClosers.Paren + openClosers.Bracket + closedClosers.Bracket) ) {
            Debug.Log("test");
        }

    }
}
