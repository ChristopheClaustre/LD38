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
    [SerializeField]
    private double m_sunlight = 1;
    [SerializeField]
    private double m_coeffPositionSunlight = 1;
    [SerializeField]
    private double m_coeffCloudSunlight = 1;

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

    public void OnTriggerEnter2D(Collider2D p_other)
    {
        switch(p_other.gameObject.name)
        {
            case "CloudFirstHalf":
                m_coeffCloudSunlight = 0.5;
                break;
            case "CloudMiddle":
                m_coeffCloudSunlight = 0;
                break;
            case "CloudSecondHalf":
                m_coeffCloudSunlight = 0.5;
                break;
            case "CloudOff":
                m_coeffCloudSunlight = 1;
                break;
            case "LightZoneFirstHalf":
                m_coeffPositionSunlight = 0.75;
                break;
            case "LightZoneMiddle":
                m_coeffPositionSunlight = 1;
                break;
            case "LightZoneSecondHalf":
                m_coeffPositionSunlight = 0.75;
                break;
            case "LightZoneOff":
                m_coeffPositionSunlight = 0;
                break;
            default:
                break;
        }

        m_sunlight = m_coeffPositionSunlight * m_coeffCloudSunlight;
    }
    /*
    public void OnTriggerExit2D(Collider2D p_other)
    {
        switch (p_other.gameObject.name)
        {
            case "CloudFirstHalf":
                // nothing
                break;
            case "CloudMiddle":
                // nothing
                break;
            case "CloudSecondHalf":
                m_coeffCloudSunlight = 1;
                break;
            case "LightZoneFirstHalf":
                // nothing
                break;
            case "LightZoneMiddle":
                // nothing
                break;
            case "LightZoneSecondHalf":
                // nothing
//                m_coeffPositionSunlight = 0;
                break;
            default:
                break;
        }

        m_sunlight = m_coeffPositionSunlight * m_coeffCloudSunlight;
    }
    */
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
