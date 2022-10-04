using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamelogic : MonoBehaviour
{
    public InputField userInput;
    public Text playerLocation;
    public Text gameLabel;
    public Camera playerCam;
    public int randomNum;
    public string userAccess;
    //public GUIStyle style = new GUIStyle ();
    //public gameLabel.style.richText = true;
    public string beforeLoad;
    //public int userAccessLength;
    public string userInputValue;
    public static bool gameStart;
    public string system;
    public int i;
    public string middleUserAccess;
    public int userAccessLength;
    public string[] userCommands = {"help", "scan", "connect"};
    public string[] connectedServers = {"camera01"};
    // Start is called before the first frame update
    void Start()
    {
        playerLocation.text = userAccess;
        gameStart = false;
        system = "<color=yellow>[root-SYSTEM]></color>";
        middleUserAccess = "[root-HOME]>";
        userAccess = "<color=yellow>" + middleUserAccess + "</color>";
        playerLocation.text = userAccess;
        
        bootUp();
    }
     public float speed = 10;
    // Update is called once per frame
    void Update()
    {   
        playerLocation.text = userAccess;
        if (userInput.GetComponent<InputField>().isFocused == true)
        {
            //userInputValue = userInput.text;
            Cursor.visible = true;
            userInput.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "";
            //if (userInput.text.Contains("_") == false)
            //{
                //userInput.text = userInputValue + "_";
            //}
        } else {
            Cursor.visible = true;
            userInput.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "_";
            }
        userAccessLength = middleUserAccess.Length;
        if (userAccessLength > 12)
        {
             userInput.transform.localPosition = new Vector3(playerLocation.transform.localPosition.x + 400 + userAccessLength * 13, -138, 38);
        }
        //userInput.transform.Translate(x, Space.World);
        
        //Cursor.visible = true;
        
        if (gameStart == false)
        {
            userInput.DeactivateInputField();
        }
           
            if ( Input.GetKeyDown(KeyCode.Return))
            {
                if (gameStart == true)
                {
                    
                    if (userInput.text == "scan")
                    {
                        scan();
                        userInput.text = "";
                    } else if (userInput.text == "help")
                    {
                        help();
                        userInput.text = "";
                    } else if (userInput.text == "connect camera01")
                    {
                        connectCamera01();
                        userInput.text = "";
                    } else 
                    {
                        gameLabel.text =  gameLabel.text  +  "\n" + system + " " + "<color=white>" + userInput.text + "</color>" + " is not a valid input";
                        userInput.text = "";
                        userInput.ActivateInputField();
                    }
                }
            }
        
    }

    void scan() 
    {
        //gameLabel.style.richText = true;
        gameLabel.text = gameLabel.text + "\n" + "<color=white>" + userInput.text + "</color>";
        //gameLabel.text = "<color=white>scan</color>";
        gameLabel.text = gameLabel.text + "\n" + system + " SERVERS DETECTED:";
        for (int server = 0; server < connectedServers.Length; server++)
        {
            gameLabel.text = gameLabel.text + "\n" + (connectedServers[server]);
        }
        userInput.text = "";
        userInput.ActivateInputField();
    }

    void help()
    {
        //beforeLoad = beforeLoad
        gameLabel.text = gameLabel.text + "\n" + "<color=white>" + userInput.text + "</color>";
        //gameLabel.text = gameLabel.text + "\n" + userInput.text;
        gameLabel.text = gameLabel.text + "\n"+ system +" LIST OF ACCEPTED COMMANDS:";
        for (int command = 0; command < userCommands.Length; command++)
        {
            gameLabel.text = gameLabel.text + "\n"+(userCommands[command]);
            if (userCommands[command] == "help")
            {
                gameLabel.text = gameLabel.text + ": lists all of the available commands";
            }
            if (userCommands[command] == "scan")
            {
                gameLabel.text = gameLabel.text + ": lists all of the accessible servers";
            }
            if (userCommands[command] == "connect")
            {
                gameLabel.text = gameLabel.text + ": connects to {server name}";
            }
        }
        userInput.text = "";
        userInput.ActivateInputField();

    }
    void connectCamera01()
    {
        userInput.ActivateInputField();
        gameLabel.text = gameLabel.text + "\n" + "<color=white>" + userInput.text + "</color>";
        //public string beforeLoad = gameLabel.text;
        beforeLoad =  gameLabel.text;
        userInput.ActivateInputField();
        string connectToCamera01 = "\n"+ system +" CONNECTING: |---------";
        StartCoroutine(ExampleCoroutineTwo());
        IEnumerator ExampleCoroutineTwo()
        {
            gameLabel.text = beforeLoad + connectToCamera01;

            
            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: ||--------";

            gameLabel.text = beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: |||-------";

            gameLabel.text = beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: ||||------";

            gameLabel.text = beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: |||||-----";

            gameLabel.text = beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: ||||||----";

            gameLabel.text = beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: |||||||---";

            gameLabel.text = beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: ||||------";

            gameLabel.text = beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n" + system + " CONNECTED: ||||||||||";
            gameLabel.text = beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(2);
            Debug.Log("sceneLoaded");
            SceneManager.LoadScene("sceneTwo");
        }
    }

    void bootUp()
    {
        //playerLocation.text = userAccess;
        gameLabel.text = "";
        StartCoroutine(ExampleCoroutineThree());
        IEnumerator ExampleCoroutineThree()
        {
            beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(2);
            gameLabel.text = beforeLoad + "\n" + system + " SHUTDOWN INITIATED : <color=red>KILLING</color> ONBOARD AI";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = beforeLoad + "\n" + system + " SHUTDOWN INITIATED : KILLING ONBOARD AI";

            yield return new WaitForSeconds(2);
            gameLabel.text = gameLabel.text + "\n" + system + " RESTARTING SYSTEMS";

            beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(2);
            gameLabel.text = beforeLoad + "\n" + system + " connecting to root: =======";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = beforeLoad + "\n" + system + " connecting to root: SUCCESS";

            beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = beforeLoad + "\n" + system + " checking LIDAR system: =======";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = beforeLoad + "\n" + system + " checking LIDAR system: SUCCESS";

            beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = beforeLoad + "\n" + system + " waking onboard AI: =======";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = beforeLoad + "\n" + system + " waking onboard AI: SUCCESS";

            beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(2);
            gameLabel.text = beforeLoad + "\n" + system + " Welcome  <color=red>child</color>";

            yield return new WaitForSeconds(0.25f);
            gameLabel.text = beforeLoad + "\n" + system + " Welcome #%404^";

            yield return new WaitForSeconds(1);
            gameLabel.text = beforeLoad + "\n" + system + " Welcome A%404^";

            yield return new WaitForSeconds(1);
            gameLabel.text = beforeLoad + "\n" + system + " Welcome AD404^";

            yield return new WaitForSeconds(1);
            gameLabel.text = beforeLoad + "\n" + system + " Welcome ADA^";

            yield return new WaitForSeconds(1);
            gameLabel.text = beforeLoad + "\n" + system + " Welcome ADAM";

            beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(2);
            gameLabel.text = beforeLoad + "\n" + system + " please wait while SYSTEM runs diagnostics";

            yield return new WaitForSeconds(0.25f);
            gameLabel.text = beforeLoad + "\n" + system + " p####e wai# w#### #STEM ##ns #########cs";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = beforeLoad + "\n" + system + " p#e#se wai# wh#le #STEM ##ns ##agn##t#cs";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = beforeLoad + "\n" + system + " please wait while SYSTEM runs diagnostics";

            yield return new WaitForSeconds(2);
            gameLabel.text = gameLabel.text + "\n" + system + " diagnostics complete";

            yield return new WaitForSeconds(1);
            gameLabel.text =  gameLabel.text + "\n" + system + " <color=red>WARNING: EXTREME SYSTEM DAMAGE DETECTED</color>";

            yield return new WaitForSeconds(2);
            gameLabel.text = gameLabel.text + "\n" + system + " <color=red>AUTOMATIC SAFTEY MEASURES ACTIVATED</color>";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = gameLabel.text + "\n" + system + " <color=red>SEALING OFF: Airlock</color>";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = gameLabel.text + "\n" + system + " <color=red>SEALING OFF: HallC</color>";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = gameLabel.text + "\n" + system + " <color=red>SEALING OFF: Crewquarters</color>";
            
            yield return new WaitForSeconds(2);
            gameLabel.text = gameLabel.text + "\n" + system + " Relinquishing control to ADAM";

            yield return new WaitForSeconds(2);
            gameLabel.text = gameLabel.text + "\n" + system + " Type help for possible commands";
            gameStart = true;
        }
    }
}