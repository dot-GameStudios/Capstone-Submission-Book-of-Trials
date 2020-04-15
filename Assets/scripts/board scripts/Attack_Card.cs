using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack_Card : MonoBehaviour
{
    public int AttackID;
    //Ethan//
    //the name of the attack for display purposes
    public string AttackName;
    //Ethan//
    /*the damage value the attack has, called base damage
     because of any addition calculations and boosts that
     could later be applied
     such as element type advantages*/
    public int BaseDmg;
    //Ethan//
    /*this is simply the cost the card has to be put into the attack queue
     */
    public int ManaCost;
    //Ethan//
    //0-null,1-fire,2-water,3-earth,4-air,5-ice,6-lightning
    public int AttackElement;


    //Ethan//
    /*
     this simply update the camera number under 
     cameraController when the attack is triggered
     for cinemtaic atack views
         */
    public int cameraNum;

    public Texture attackImage;
}
