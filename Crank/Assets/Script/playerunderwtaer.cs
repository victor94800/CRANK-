using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerunderwtaer : MonoBehaviour {

	// Use this for initialization

	// on crre une nouvelle barre  d'apnee 
	// player physique
	public float water_speed;
	public float gravity;

	apnee Barredapnee;
	GameObject barre_apnee;
	public GameObject water;
	private CharacterController cc;
	public GameObject camera;
	public GameObject playerlookat;
	//player stat 
	public int apnee;
	private Vector3 movevector;
	public float rotX;
	public float rotY;
	public float rotatespeed;
	public bool swim =false;
	public float sensibility;
	private Animator anim;
	
	private void OnEnable()
	{
		//playerlookat.transform.Translate(0, -3, 0);
		Barredapnee.valeur = apnee;
	}
	private void OnDisable()
	{
		if (swim == true)
		{
			playerlookat.transform.Translate(0, 3f, 0);
			swim = false;
		}
		this.GetComponent<player4>().enabled = true;
		barre_apnee.SetActive(false);
	}
	void Start ()
	{
		anim = GameObject.Find("Player").GetComponent<Animator>();
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
		movevector = Vector3.zero;
		if (water.GetComponent<UnderWater>().isunderwater)
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
		
		if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
		{
			if (swim == false)
			{

				playerlookat.transform.Translate(0, -3f, 0);
			}
			swim = true;
		}
		else
		{
			if (swim == true)
			{
				playerlookat.transform.Translate(0, 3, 0);
			}
			swim = false;
			
		}
		if (Input.GetAxis("Horizontal2") > 0.5 || Input.GetAxis("Horizontal2") < -0.5)
		{
			transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal2") * Time.deltaTime * sensibility, 0f));
		}
		transform.RotateAround(camera.transform.position, Vector3.up, Input.GetAxis("Horizontal") * rotatespeed * Time.deltaTime);
		//cc.Move(Vector3.up * -gravity);
		movevector.z = Input.GetAxis("Vertical") * water_speed;
		//movevector.x = Input.GetAxis("Horizontal");
		if (Input.GetKey("joystick button 5"))
		{
			movevector.y -= gravity * Time.deltaTime;
		}
		if (Input.GetKey("joystick button 0"))
		{
			movevector.y += gravity * Time.deltaTime;
		}

		movevector = transform.TransformDirection(movevector);
		cc.Move(movevector * Time.deltaTime);
		anim.SetBool("walk", swim);
		
	}
}
