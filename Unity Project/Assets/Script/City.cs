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

    public string m_name = "";

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    [SerializeField]
    private e_City m_kind = e_City.eField;

    /***************************************************
	 ***  SUB-CLASSES           ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    public enum e_WindStrenght
    {
        eNull = 0,
        eLow,
        eMedium,
        eHigh,
        eMax
    }

    public enum e_City
    {
        eRelief = 0,
        eField,
        eCity,
        eMax
    }

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

    public double A_sunlight
    {
        get
        {
            return m_sunlight;
        }
    }

    public e_City A_kind
    {
        get
        {
            return m_kind;
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private List<Building> m_buildings;
    [SerializeField]
    private double m_population = 0;
    private double m_sunlight = 1;
    private double m_positionCoeff = 1;
    private double m_cloudCoeff = 1;
    private e_WindStrenght m_windStrength;

    private double m_timerWind = 0;

    /***************************************************
     ***  METHODS               ************************
     ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        updateWindStrength();
//        m_closeViewCamera = GetComponentInChildren<Camera>();

        // creation population
        if (m_population == 0)
        {
            m_population = Random.Range(1, 11);
        }

    }

    // Update is called once per frame
    public void Update()
    {
        // update wind
        m_timerWind -= Config.m_deltaTime;

        if (m_timerWind <= 0)
        {
            updateWindStrength();
        }

        // update population
        if (m_kind == e_City.eCity)
        {
            m_population += Config.m_baseProductionPopulation * getSatisfactionCoeff() * Config.m_deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D p_other)
    {
        switch(p_other.gameObject.name)
        {
            case "CloudFirstHalf":
                m_cloudCoeff = 0.5;
                break;
            case "CloudMiddle":
                m_cloudCoeff = 0;
                break;
            case "CloudSecondHalf":
                m_cloudCoeff = 0.5;
                break;
            case "CloudOff":
                m_cloudCoeff = 1;
                break;
            case "LightZoneFirstHalf":
                m_positionCoeff = 0.75;
                break;
            case "LightZoneMiddle":
                m_positionCoeff = 1;
                break;
            case "LightZoneSecondHalf":
                m_positionCoeff = 0.75;
                break;
            case "LightZoneOff":
                m_positionCoeff = 0;
                break;
            default:
                break;
        }

        m_sunlight = m_positionCoeff * m_cloudCoeff;
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

    public double getEnergyProduction()
    {
        return 0.5;
    }

    public double getPollutionProduction()
    {
        return 0;
    }

    public double getSatisfactionCoeff()
    {
        double l_pollution = getPollutionProduction();

        int i = 0;
        while (l_pollution >= Config.m_satisfactionThreshold[i] && i+1 < Config.m_satisfactionCoeff.Count)
        {
            ++i;
        }

        return Config.m_satisfactionCoeff[i];
    }

    public double getWindStrengthCoeff()
    {
        return Config.m_windStrengthCoeff[(int) m_windStrength];
    }

    public void killEveryone(double p_killRatio)
    {
        m_population -= (p_killRatio * m_population);
    }

    public void becomeSomethingAwesome(e_City p_kind)
    {
        if (m_kind == e_City.eField)
        {
            m_kind = p_kind;
            switch (p_kind)
            {
                case e_City.eField:
                    break;
                case e_City.eCity:
                    GetComponentInChildren<SpriteRenderer>().sprite = Config.m_spriteCity;
                    break;
                case e_City.eRelief:
                    GetComponentInChildren<SpriteRenderer>().sprite =
                        (Random.Range(0, 1000) % 2 == 0) ? Config.m_spriteMountain : Config.m_spriteSea;
                    break;
                default:
                    break;
            }
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void updateWindStrength()
    {
        m_windStrength = (e_WindStrenght) Random.Range(0, (int) e_WindStrenght.eMax);
        m_timerWind = Random.Range(Config.m_limitTimerWind.x, Config.m_limitTimerWind.y);
    }

}
