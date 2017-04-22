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

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    /***************************************************
	 ***  ATTRIBUTES            ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    public Camera m_closeViewCamera;

    public double A_population
    {
        get
        {
            return m_population;
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private List<Building> m_buildings;
    private double m_population = 0;

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

    public double getCoalConsumption()
    {
        return 1;
    }

    public double getWaterConsumption()
    {
        return 1;
    }

    public double getMoneyProduction()
    {
        return 1;
    }

    public double getEnergyConsumption()
    {
        return 1;
    }

    public double getEnergyProduction()
    {
        return 0.5;
    }

    public double getPollutionProduction()
    {
        return 1;
    }

    public double getWindStrength()
    {
        return 0;
    }

    public double getSunlight()
    {
        return 0;
    }

    public double getSatisfaction()
    {
        return 0;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}
