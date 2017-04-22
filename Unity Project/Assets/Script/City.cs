/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/


public class City : MonoBehaviour
{
    /***************************************************
	 ***  UNITY GUI PROPERTY    ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    /***************************************************
	 ***  SUB-CLASSES           ************************
	 ***************************************************/

    /********  PUBLIC           ************************/
    public Camera CloseViewCamera;
    public List<Building> buildings;
    public int population;

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    /***************************************************
	 ***  ATTRIBUTES            ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }
    public int getProductionPollution(double deltaTime)
    {
        return 0;
    }
    public int getProductionArgent(double deltaTime)
    {
        return 0;
    }
    public int getConsomationEau(double deltaTime)
    {
        return 0;
    }
    public int getConsomationEnergie(double deltaTime)
    {
        return 0;
    }
    public int getVent()
    {
        return 0;
    }
    public int getEnsoleillement()
    {
        return 0;
    }
    public float getSatisfaction()
    {
        return 0;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}
