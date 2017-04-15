using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10f ;
    public float rotationspeed = 10f;
    public float saut = 1f;
    private Transform TargetCamera;
    private float speed2;
    public float run;
    private int jump;
    private int time;
    GameObject l;
    Animator anim;
    GameObject player;
    healthBarre Barredevie ;
    apnee Barredapnee ;
    Animation anime;
    public int dmg;
    public int Life;
    public int life;
    public int apnee;
    public  int Dmg;
	
   
    // Use this for initialization

    void Start ()
    {
        // on crre une nouvelle barre de vie et d'apnee 
        Barredapnee = new apnee();
        Barredevie = new healthBarre();
        // on recupere l'objet apnee barre et on la desactive 
        l = GameObject.Find("apnee barre");
        l.SetActive(false);
        // on recupere l'objet Camera associe au player
        TargetCamera = GameObject.Find("Camera").transform;
        // on initialise l'anim a l'animateur du personnage 
        anim = this.GetComponent<Animator>();
        // on set les valeur associe a la barre de vie a la vie et a l'apnee;
        life = Life;
        Barredevie.max = life;
       
        Barredevie.valeur = life;
        Barredapnee.max = apnee;
        anim.SetTime(1);
        Dmg = dmg;
    }

    // Update is called once per frame
    void Update()
    {

       // verifi si la camera est sous l'eau ou non ;
        if (TargetCamera.transform.position.y <= 5f)
        {
            l.SetActive(true);
            Barredapnee.valeur -= 0.1f;
        }
        else
        {
           if (Barredapnee.valeur < Barredapnee.max)
            {
                Barredapnee.valeur += 1;
            }
            else
            {
                l.SetActive(false);
            }
         }

        if (Input.GetKey("joystick button 1"))
        {
            Barredevie.valeur -= dmg;
        }
        if (Input.GetKey("joystick button 6"))
        {
            Barredevie.valeur += dmg;
        } 

        if (TargetCamera.transform.position.y <= 5)
        {
            speed2 = 0.05f;
        }
       else
        {
            speed2 = speed;
        }

        if (Barredapnee.valeur == 0)
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
