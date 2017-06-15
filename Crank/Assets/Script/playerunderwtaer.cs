using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerunderwtaer : MonoBehaviour {

	// Use this for initialization

	// on crre une nouvelle barre  d'apnee 
	// player physique
	public float water_speed;
	public float gravity;
	public GameObject Global;
	apnee Barredapnee;
	public GameObject barre_apnee;
	public GameObject water;
	private CharacterController cc;
	public GameObject Camera;
	public GameObject playerlookat;
	//player stat 
	public int apnee;
	private Vector3 movevector;
	public float rotX;
	public float rotY;
	public float rotatespeed;
	public bool swim =false;
	public float verticalVelocity;
	public int life;
	
	private void OnEnable()
	{
		life = GetComponent<life>().Life;
		Barredapnee = new apnee();
		Barredapnee.max = apnee;
		Barredapnee.valeur = apnee;

	
	}
	private void OnDisable()
	{
		
		GetComponent<PlayerController>().enabled = true;
		barre_apnee.SetActive(false);
	}
	void Start ()
	{
		life = GetComponent<life>().Life;
		cc = GetComponent<CharacterController>();
		Barredapnee = new apnee();

		// on recupere l'objet apnee barre et on la desactive 
		barre_apnee = GameObject.Find("apnee barre");
		barre_apnee.SetActive(false);
		Barredapnee.max = apnee;
		Barredapnee.valeur = apnee;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Barredapnee.valeur <= 0)
		{
			Global.GetComponent<Global>().Playeralive = false;
		}
		cc = GetComponent<CharacterController>();
		movevector = Vector3.zero;
		if (water.GetComponent<UnderWater>().is_player_underwater)
		{
			barre_apnee.SetActive(true);
			Barredapnee.valeur -= 1f;
		}
		else
		{
			if (Barredapnee.valeur < Barredapnee.max)
			{
				Barredapnee.valeur += 10;
			}
			else
			{
				barre_apnee.SetActive(false);
			}
		}
		
		
		/*if (Input.GetAxis("Horizontal2") > 0.5 || Input.GetAxis("Horizontal2") < -0.5)
		{
			transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal2") * Time.deltaTime * sensibility, 0f));
		}*/
		transform.RotateAround(Camera.transform.position, Vector3.up, Input.GetAxis("Horizontal") * rotatespeed * Time.deltaTime);
		//cc.Move(Vector3.up * -gravity);
		movevector.z = Input.GetAxis("Vertical") * water_speed;
		//movevector.x = Input.GetAxis("Horizontal");
		if (Input.GetKey("joystick button 5"))
		{
			verticalVelocity = -gravity * Time.deltaTime;
		}
		else if (Input.GetKey("joystick button 0")|| Input.GetKey(KeyCode.Space))
		{
			verticalVelocity = gravity * Time.deltaTime ;
		}
		else
		{
			verticalVelocity = 0;
		}

		movevector = transform.TransformDirection(movevector);
		if (verticalVelocity != 0)
		{
			movevector.y = verticalVelocity;
		}
		
		cc.Move(movevector * Time.deltaTime);
		
		
	}
}
