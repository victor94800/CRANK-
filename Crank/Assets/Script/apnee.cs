using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class apnee : MonoBehaviour {

    static Image Barre2;
    static Text Txt2;
    public float max { get; set; }
    private float Valeur;// valeur de la braae de vie 
    public float valeur // valuer public qui permet de modifier valeur
    {
        get { return Valeur; }
        set
        {
            Valeur = Mathf.Clamp(value, 0, max);

            if (Barre2 != null)
            {
                Barre2.fillAmount = (1 / max) * Valeur;
                Txt2.text = Barre2.fillAmount * 100 + "%";
            }

        }
    }
    void Start()
    {
        Barre2 = GetComponent<Image>();
        
        Txt2 = transform.FindChild("apnee").GetComponent<Text>();
        Txt2.text = Barre2.fillAmount * 100 + "%";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
