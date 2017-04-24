using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
	public GameObject water;
    private float speed2;
    
    private int time;
    GameObject barre_apnee;
    
    GameObject player;
    healthBarre Barredevie ;
    
    
    public int dmg;
    public int Life;
    public int life;
    public int apnee;
    public  int Dmg;


	// Use this for initialization


	// need objects 
	public GameObject Gamecontroller;

    void Start ()
    {
        // on crre une nouvelle barre de vie et d'apnee 
       
        Barredevie = new healthBarre();
        // on recupere l'objet apnee barre et on la desactive 
       
        barre_apnee.SetActive(false);
		// on recupere l'objet Camera associe au player
		
        // on initialise l'anim a l'animateur du personnage 
        
        // on set les valeur associe a la barre de vie a la vie et a l'apnee;
        life = Life;
        Barredevie.max = life;
       
        Barredevie.valeur = life;
        
       
        Dmg = dmg;

		if (Gamecontroller != null )
		{
			life = Gamecontroller.GetComponent<GameController>().life;
			Barredevie.max = life;

			Barredevie.valeur = life;
		}
		else
		{
			life = Life;
			Barredevie.max = life;

			Barredevie.valeur = life;
			
			
			Dmg = dmg;
		}
    }

    // Update is called once per frame
    void Update()
    {
     if (this.GetComponent<playerunderwtaer>().apnee == 0)
        {
            Barredevie.valeur -= dmg;
        }
        if (Barredevie.valeur == 0 )
        {
           // anim.Play("Death1");
        }
     }
   
    private void OnTriggerEnter(Collider hit)
        {
       
        if (hit.transform.tag == "Esword" )
        {
            life -= 1;
            Barredevie.valeur -=1 ;
        }


    
    }





}
