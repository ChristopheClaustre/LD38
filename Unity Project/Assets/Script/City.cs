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
    private KindCity m_kind = KindCity.ePrairie;
    [SerializeField]
    private List<GameObject> m_buildingsGO = new List<GameObject>();

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

    public enum KindCity
    {
        ePrairie = 0,
        eMountain,
        eSea,
        eCity
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

    public KindCity A_kind
    {
        get
        {
            return m_kind;
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private List<Building> m_buildings = new List<Building>();
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

        // creation population
        if (m_population <= 0)
        {
            m_population = Random.Range(1, 11);
        }

        // get the buildings
        getActiveBuildings();
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
        if (m_kind == KindCity.eCity)
        {
            m_population += Planet.A_instance.A_birthRatio * getSatisfactionCoeff();
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
        return 1; /// CHANGER MOI, CHANGER MOI, CHANGER MOI
    }

    public double getWaterConsumption()
    {
        return m_population * Config.m_consumptionWaterPerHabitant;
    }

    public double getMoneyProduction()
    {
        return m_population * Config.m_productionMoneyPerHabitant;
    }

    public double getEnergyProduction()
    {
        double l_consumption = m_population * Config.m_consumptionEnergyPerHabitant;
        double l_production = 0.5; /// CHANGER MOI, CHANGER MOI, CHANGER MOI
        return l_production - l_consumption;
    }

    public double getPollutionProduction()
    {
        double l_prod;
        switch (m_kind)
        {
            case KindCity.eMountain:
                l_prod = -10;
                break;
            case KindCity.eSea:
                l_prod = -10;
                break;
            case KindCity.ePrairie:
                l_prod = -10;
                break;
            case KindCity.eCity:
                l_prod = 70; /// CHANGER MOI, CHANGER MOI, CHANGER MOI
                break;
            default:
                l_prod = 0;
                break;
        }
        return l_prod;
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

    public void becomeSomethingAwesome(KindCity p_kind)
    {
        if (m_kind == KindCity.ePrairie)
        {
            m_kind = p_kind;
            m_name = Namer.getName(p_kind);

            switch (p_kind)
            {
                case KindCity.ePrairie:
                    break;
                case KindCity.eCity:
                    GetComponentInChildren<SpriteRenderer>().sprite = Config.m_spriteCity;
                    break;
                case KindCity.eMountain:
                    GetComponentInChildren<SpriteRenderer>().sprite = Config.m_spriteMountain;
                    break;
                case KindCity.eSea:
                    GetComponentInChildren<SpriteRenderer>().sprite = Config.m_spriteSea;
                    break;
                default:
                    break;
            }
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void getActiveBuildings()
    {
        m_buildings.Clear();

        foreach (var l_go in m_buildingsGO)
        {
            m_buildings.Add(getActiveBuilding(l_go));
        }
    }

    private static Building getActiveBuilding(GameObject p_go)
    {
        foreach (var l_building in p_go.GetComponentsInChildren<Building>())
        {
            if (l_building.enabled)
            {
                return l_building;
            }
        }

        return null;
    }

    private void updateWindStrength()
    {
        m_windStrength = (e_WindStrenght) Random.Range(0, (int) e_WindStrenght.eMax);
        m_timerWind = Random.Range(Config.m_limitTimerWind.x, Config.m_limitTimerWind.y);
    }

}
