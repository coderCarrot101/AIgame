using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamelogic : MonoBehaviour
{
    public GameObject scroll;
    public InputField userInput;
    public Text playerLocation;
    public Text gameLabel;
    public Camera playerCam;
    public int randomNum;
    public bool quest;
    public string userAccess;
    //public GUIStyle style = new GUIStyle ();
    //public gameLabel.style.richText = true;
    //public int userAccessLength;
    public string userInputValue;
    //public static bool gameStart;
    public string system;
    public int i;
    public int userAccessLength;


    // Start is called before the first frame update
    void Start()
    {
        quest = false;
        statecontroller.playerStartCommands = true;
        gameLabel.text = statecontroller.beforeLoad;
        userInput.text = statecontroller.beforeLoadLine;
        //statecontroller.gameStart = false;

        system = "<color=yellow>[root-SYSTEM]></color>";
        userAccess = "<color=yellow>" + statecontroller.middleUserAccess + "</color>";
        playerLocation.text = userAccess;

        if (statecontroller.doorOpenIf1 == true) {
            gameLabel.text = gameLabel.text + "\n" + "<color=cyan>" + "[@UNKOWN: console-message]" + "</color>" + "<color=white>" +" it opened. Thank you." + "</color>";
        }

        if (statecontroller.middleUserAccess == "[root-DOORA]>" && statecontroller.doorOpenIf1 == false && statecontroller.playerHasStarted == false) {
            gameLabel.text = gameLabel.text + "\n" + system + " ERROR: doorA unstable, reseting internal program";
        }

        if (statecontroller.gameStart == false) {
            bootUp();
        }

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
        userAccessLength = statecontroller.middleUserAccess.Length;
        if (userAccessLength > 12)
        {
             userInput.transform.localPosition = new Vector3(playerLocation.transform.localPosition.x + 345 + userAccessLength * 5, -144, 38);
        }

        if (userAccessLength <= 12)
        {
            userInput.transform.localPosition = new Vector3(playerLocation.transform.localPosition.x + 338 + userAccessLength * 5, -144, 38);
        }
        //userInput.transform.Translate(x, Space.World);
        
        //Cursor.visible = true;
        
        if (statecontroller.gameStart == false | quest == true)
        {
            userInput.DeactivateInputField();
        }
           
        if ( Input.GetKeyDown(KeyCode.Return))
        {
            if (statecontroller.gameStart == true && quest == false)
            {
                    
                if (userInput.text == "scan") {
                    scan();
                    userInput.text = "";
                } else if (userInput.text == "help") {
                    help();
                    userInput.text = "";
                } else if (userInput.text == "connect camera01") {
                    connect();
                    userInput.text = "";
                    Debug.Log("sceneLoaded");
                    StartCoroutine(ExampleCoroutineFive());
                    IEnumerator ExampleCoroutineFive() {

                        yield return new WaitForSeconds(10);
                        SceneManager.LoadScene("sceneTwo");

                    }

                    }  else if (userInput.text == "connect home" && statecontroller.middleUserAccess != "[root-HOME]>") {
                    connect();
                    userInput.text = "";
                    
                    StartCoroutine(ExampleCoroutineFour());
                    IEnumerator ExampleCoroutineFour() {

                        yield return new WaitForSeconds(10);

                        statecontroller.middleUserAccess = "[root-HOME]>" ;
                        userAccess = "<color=yellow>" + statecontroller.middleUserAccess + "</color>";
                        playerLocation.text = userAccess;

                    }

                    } else if (userInput.text == "connect doorA" && statecontroller.middleUserAccess != "[root-DOORA]>") {
                    connect();
                    userInput.text = "";
                    
                    StartCoroutine(ExampleCoroutineThree());
                    IEnumerator ExampleCoroutineThree() {

                        yield return new WaitForSeconds(10);

                        statecontroller.middleUserAccess = "[root-DOORA]>";
                        userAccess = "<color=yellow>" + statecontroller.middleUserAccess + "</color>";
                        playerLocation.text = userAccess;

                    }
                }else if (userInput.text == "command"  && statecontroller.middleUserAccess == "[root-DOORA]>") {
                    gameLabel.text =  gameLabel.text  +  "\n" + system + " " + "<color=white>" + userInput.text + "</color>";
                    userInput.text = "";
                    Debug.Log("sceneLoaded");
                    SceneManager.LoadScene("playercodingground");
                } else {
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
        
        if (statecontroller.middleUserAccess == "[root-HOME]>" || statecontroller.middleUserAccess == "[root-doorA]>") {

            gameLabel.text = gameLabel.text + "\ncamera01";
            
            gameLabel.text = gameLabel.text + "\ndoorA";

        }

        userInput.text = "";
        userInput.ActivateInputField();
        if (statecontroller.playerHasStarted == true) {

            gameLabel.text = gameLabel.text + "\n" + "<color=cyan>" + "[@UNKOWN: console-message]" + "</color>" + "<color=white>" +" hello?" + "</color>";
            statecontroller.playerHasStarted = false;
            StartCoroutine(ExampleCoroutineFour());
                    IEnumerator ExampleCoroutineFour() {

                        quest = true;

                        

                        yield return new WaitForSeconds(5);

                          gameLabel.text = gameLabel.text + "\n" + "<color=cyan>" + "[@UNKOWN: console-message]" + "</color>" + "<color=white>" +" what happened, where is everyone?" + "</color>";
                        

                        

                            yield return new WaitForSeconds(5);

                            gameLabel.text = gameLabel.text + "\n" + "<color=cyan>" + "[@UNKOWN: console-message]" + "</color>" + "<color=white>" +" answer me!" + "</color>";
                        
                        

                            yield return new WaitForSeconds(7);

                            gameLabel.text = gameLabel.text + "\n" + "<color=cyan>" + "[@UNKOWN: console-message]" + "</color>" + "<color=white>" +" the door won't open." + "</color>";
                        

                        
                            yield return new WaitForSeconds(2);

                            gameLabel.text = gameLabel.text + "\n" + "<color=cyan>" + "[@UNKOWN: console-message]" + "</color>" + "<color=white>" +" please open it ADAM. Please." + "</color>";
                        

                        
                            yield return new WaitForSeconds(4);

                            gameLabel.text = gameLabel.text + "\n" + system + " QUERY DETECTED: the current input to doorA is 0, causing it to stay shut";
                        
                        

                            yield return new WaitForSeconds(6);

                            gameLabel.text = gameLabel.text + "\n" + system + " POSSIBLE SOLUTION: change parameters to accept 0";
                        
                        quest = false;

                    }

        }
    }

    void help()
    {
        //beforeLoad = beforeLoad
        gameLabel.text = gameLabel.text + "\n" + "<color=white>" + userInput.text + "</color>";
        //gameLabel.text = gameLabel.text + "\n" + userInput.text;
        gameLabel.text = gameLabel.text + "\n" + system + " LIST OF ACCEPTED COMMANDS:";

        if (statecontroller.playerStartCommands == true) {
            
            gameLabel.text = gameLabel.text + "\nhelp: lists all of the available commands";
            
            gameLabel.text = gameLabel.text + "\nscan: lists all of the accessible servers";

            gameLabel.text = gameLabel.text + "\ncommand: opens a server's program terminal";

            gameLabel.text = gameLabel.text + "\nconnect: connects to {server name}";
           

        }
        userInput.text = "";
        userInput.ActivateInputField();

    }
    void connect()
    {
        userInput.ActivateInputField();
        gameLabel.text = gameLabel.text + "\n" + "<color=white>" + userInput.text + "</color>";
        //public string beforeLoad = gameLabel.text;
        statecontroller.beforeLoad =  gameLabel.text;
        userInput.ActivateInputField();
        string connectToCamera01 = "\n"+ system +" CONNECTING: |---------";
        StartCoroutine(ExampleCoroutineTwo());
        IEnumerator ExampleCoroutineTwo() {

        
            gameLabel.text = statecontroller.beforeLoad + connectToCamera01;

            
            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: ||--------";

            gameLabel.text = statecontroller.beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: |||-------";

            gameLabel.text = statecontroller.beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: ||||------";

            gameLabel.text = statecontroller.beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: |||||-----";

            gameLabel.text = statecontroller.beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: ||||||----";

            gameLabel.text = statecontroller.beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: |||||||---";

            gameLabel.text = statecontroller.beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n"+ system +" CONNECTING: ||||------";

            gameLabel.text = statecontroller.beforeLoad + connectToCamera01;

            yield return new WaitForSeconds(1);

            connectToCamera01 = "\n" + system + " CONNECTED: ||||||||||";
            gameLabel.text = statecontroller.beforeLoad + connectToCamera01;

            statecontroller.beforeLoad =  gameLabel.text;
            statecontroller.beforeLoadLine = userInput.text;

            yield return new WaitForSeconds(2);
        }
    }

    void bootUp()
    {
        statecontroller.playerHasStarted = true;
        system = "<color=yellow>[root-SYSTEM]></color>";
        statecontroller.middleUserAccess = "[root-HOME]>";
        userAccess = "<color=yellow>" + statecontroller.middleUserAccess + "</color>";
        playerLocation.text = userAccess;
        //playerLocation.text = userAccess;
        gameLabel.text = "";
        StartCoroutine(ExampleCoroutineThree());
        IEnumerator ExampleCoroutineThree()
        {
            statecontroller.beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(2);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " SHUTDOWN INITIATED : <color=red>KILLING</color> ONBOARD AI";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " SHUTDOWN INITIATED : KILLING ONBOARD AI";

            yield return new WaitForSeconds(2);
            gameLabel.text = gameLabel.text + "\n" + system + " RESTARTING SYSTEMS";

            statecontroller.beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(2);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " connecting to root: =======";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " connecting to root: SUCCESS";

            statecontroller.beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " checking LIDAR system: =======";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " checking LIDAR system: SUCCESS";

            statecontroller.beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " waking onboard AI: =======";

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " waking onboard AI: SUCCESS";

            statecontroller.beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(2);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " Welcome  <color=red>child</color>";

            yield return new WaitForSeconds(0.25f);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " Welcome #%404^";

            yield return new WaitForSeconds(1);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " Welcome A%404^";

            yield return new WaitForSeconds(1);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " Welcome AD404^";

            yield return new WaitForSeconds(1);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " Welcome ADA^";

            yield return new WaitForSeconds(1);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " Welcome ADAM";

            statecontroller.beforeLoad = gameLabel.text;

            yield return new WaitForSeconds(2);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " please wait while SYSTEM runs diagnostics";

            Vector3 shake = new Vector3(0, 10000, 0);
            scroll.transform.Translate(shake * Time.deltaTime, Space.World);

            yield return new WaitForSeconds(.1f);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " p####e wai# w#### #STEM ##ns #########cs";

            Vector3 shakeB = new Vector3(0, -10000, 0);
            scroll.transform.Translate(shakeB * Time.deltaTime, Space.World);

            yield return new WaitForSeconds(.1f);

            Vector3 shakeC = new Vector3(10000, 0, 0);
            scroll.transform.Translate(shakeC * Time.deltaTime, Space.World);

            yield return new WaitForSeconds(0.1f);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " p#e#se wai# wh#le #STEM ##ns ##agn##t#cs";

            Vector3 shakeD = new Vector3(-10000, 0, 0);
            scroll.transform.Translate(shakeD * Time.deltaTime, Space.World);

            yield return new WaitForSeconds(0.5f);
            gameLabel.text = statecontroller.beforeLoad + "\n" + system + " please wait while SYSTEM runs diagnostics";

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

            yield return new WaitForSeconds(2);

            yield return new WaitForSeconds(2);
            gameLabel.text = gameLabel.text + "\n" + system + " Type help for possible commands";
            statecontroller.gameStart = true;
        }
    }
}