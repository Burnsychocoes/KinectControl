﻿using UnityEngine;
using System.Collections;


//Cette classe va agir en fonction des differents mouvements que l'on a
public class MovementController : MonoBehaviour {
    //soit on met ça à la main, soit il doit aller les chercher sur l'objet dans le start, cela dépend de où les scripts se trouvent
    public BalayageDroit balayageDroit;
    public BalayageGauche balayageGauche;
    public BalayageHaut balayageHaut;
    public CoupDePoingDroitAvant coupDePoingDroitAvant;
    public Course course;
    public BalayageDroit1 balayageDroit1;
    public BalayageGauche1 balayageGauche1;
    public BalayageHaut1 balayageHaut1;
    public CoupDePoingDroitAvant1 coupDePoingDroitAvant1;
    public Course1 course1;
    public MultiClonage multiClonage;

    public GameObject cubePrefab;
    public GameObject[] cubes;
    public int selection = 0;
    public int selected = -1;
	// Use this for initialization
	void Start () {
        balayageDroit = gameObject.GetComponent<BalayageDroit>();
       
        balayageGauche = gameObject.GetComponent<BalayageGauche>();
        
        balayageHaut = gameObject.GetComponent<BalayageHaut>();
        coupDePoingDroitAvant = gameObject.GetComponent<CoupDePoingDroitAvant>();
        course = gameObject.GetComponent<Course>();

        balayageDroit1 = gameObject.GetComponent<BalayageDroit1>();
        balayageGauche1 = gameObject.GetComponent<BalayageGauche1>();
        balayageHaut1 = gameObject.GetComponent<BalayageHaut1>();
        coupDePoingDroitAvant1 = gameObject.GetComponent<CoupDePoingDroitAvant1>();
        course1 = gameObject.GetComponent<Course1>();
        multiClonage = gameObject.GetComponent<MultiClonage>();
    }
	
	// Update is called once per frame
	void Update () {
        //pas encore de selectionné
        if(selected == -1)
        {
            cubes[selection].GetComponent<Renderer>().material.color = Color.blue;

            //augmente la selection de 1
            if (balayageDroit1.b1)
            {
                Debug.Log("Balayage droit !");
                //do sth
                cubes[selection].GetComponent<Renderer>().material.color = Color.white;
                selection++;
                if (selection == cubes.Length)
                {
                    selection = 0;

                }
                cubes[selection].GetComponent<Renderer>().material.color = Color.blue;
            }
            //diminue la selection de 1
            if (balayageGauche1.b1)
            {
                Debug.Log("Balayage gauche !");
                //do sth
                cubes[selection].GetComponent<Renderer>().material.color = Color.white;
                selection--;
                if (selection == -1)
                {
                    selection = cubes.Length - 1;

                }
                cubes[selection].GetComponent<Renderer>().material.color = Color.blue;
            }

            //selectionne le cube
            if (balayageHaut1.b1)
            {
                Debug.Log("Balayage haut !");
                //do sth
                selected = selection;
                cubes[selected].GetComponent<Renderer>().material.color = Color.red;
            }

            if(coupDePoingDroitAvant1.b1)
            {
                Debug.Log("Coup de poing avant");
            }

            if (course1.b1)
            {
                Debug.Log("Course");
            }
        }
        //après selection
        else
        {
            cubes[selected].GetComponent<Renderer>().material.color = Color.red;

            //deselectionne le cube
            if (coupDePoingDroitAvant1.b1)
            {
                Debug.Log("Coup de poing droit avant !");
                //do sth
                cubes[selected].GetComponent<Renderer>().material.color = Color.white;
                selected = -1;
            }

            //fais voler le cube
            if (course1.b1)
            {
                Debug.Log("Course !");
                //do sth
                cubes[selected].transform.Translate(new Vector3(0, 1, 0));
            }

            //duplique le cube
            if(multiClonage.b1)
            {
                Debug.Log("Multi Clonage !");
                //do sth
                Object cube = Instantiate(cubePrefab, new Vector3(cubes[cubes.Length - 1].transform.position.x+2, 0, 0), Quaternion.identity);
                cubes.SetValue(cube, cubes.Length);
            }
        }       
        

        //dernier movement pour sortir du jeu

        if (Input.GetKeyUp(KeyCode.Escape) == true)
        {
            Debug.Log("Escape !");
            //do sth
        }
	}
}
