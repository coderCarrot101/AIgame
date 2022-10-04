using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movetest : MonoBehaviour
{
    public int i;
    public string pattern;
    public Text gameLabel;
    void Start()
    {
        i = 15;
    }
    public float speed = 10;
    void Update()
    {    
        pattern = @"\n";
        if ( Input.GetKeyDown(KeyCode.Return))
        {
            
            //foreach (Match match in Regex.Matches(gameLabel.text, pattern))
            //{
            i++;
            Debug.Log(i);
            //}
    
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f )
        {
            if(transform.localPosition.y <= -200)
            {
                 Vector3 scrollUp = new Vector3(0, 10000, 0);
            transform.Translate(scrollUp * Time.deltaTime, Space.World);
            }
            
        }
        if(i >= 20)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f )
            {
                
                Vector3 scrollDown = new Vector3(0, -10000, 0);
                transform.Translate(scrollDown * Time.deltaTime, Space.World);
            }
        }
    }
}
