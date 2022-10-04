using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cameralook : MonoBehaviour
{
	public Image background;
	public InputField consoleInput;
	public Text consoleAccess;
	public string middleUserAccess;
	public string userAccess;
    public float minAngle = -45.0f;
    public float maxAngle = 45.0f;
    public float Sensitivity {
	get { return sensitivity; }
	set { sensitivity = value; }
	}
	[Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
	[Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
	[Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

	Vector2 rotation = Vector2.zero;
	const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
	const string yAxis = "Mouse Y";

	void Start(){
		middleUserAccess = "[root-SYSTEM]>";
        userAccess = "<color=yellow>" + middleUserAccess + "</color>";
        consoleAccess.text = userAccess;


	}

	void Update(){
    	if ( Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene("SampleScene");
		}
        Cursor.visible = false;
        rotation.x = Mathf.Clamp (rotation.x, minAngle, maxAngle);
		rotation.x += Input.GetAxis(xAxis) * sensitivity;
		rotation.y += Input.GetAxis(yAxis) * sensitivity;
		rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
		var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
		var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

		transform.localRotation = xQuat * yQuat; //Quaternions seem to rotate more consistently than EulerAngles. Sensitivity seemed to change slightly at certain degrees using Euler. transform.localEulerAngles = new Vector3(-rotation.y, rotation.x, 0);
	}
}
