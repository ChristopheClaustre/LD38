﻿/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/

public class Planet : MonoBehaviour
{

    /***************************************************
	 ***  UNITY GUI PROPERTY    ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    public static Planet A_instance
    {
        get
        {
            if (! m_isSingletonInit)
            {
                m_instance = GameObject.FindObjectOfType<Planet>();
            }
            return m_instance;
        }
    }
    public double A_birthRatio
    {
        get
        {
            if (m_tooMuchPollution || m_notEnoughWater)
            {
                double l_birthRatio = 0;//  Config.m_baseProductionPopulation * Config.m_deltaTime;
                l_birthRatio -= m_waterNeeded; //Water
                l_birthRatio -= (m_extraPollution / 100) * getPopulation(); //Pollution
                return l_birthRatio;
            }
            return Config.m_baseProductionPopulation * Config.m_deltaTime;
        }
    }

    // UI
    public GameObject m_populationText;
    public GameObject m_coalText;
    public GameObject m_waterText;
    public GameObject m_moneyText;
    public GameObject m_energyText;
    public GameObject m_pollutionText;
    public GameObject m_timeText;

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

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    // singleton
    private static bool m_isSingletonInit = false;
    private static Planet m_instance;

    [SerializeField]
    private List<City> m_cities;

    // Ressources
    [SerializeField]
    private double m_coal = 10000;
    [SerializeField]
    private double m_water = 10000;
    [SerializeField]
    private double m_money = 100;
    [SerializeField]
    private double m_energy = 10000;
    [SerializeField]
    private double m_pollution = 30;
    [SerializeField]
    private double m_time = 0;

    private bool m_notEnoughWater = false;
    private double m_waterNeeded;
    private bool m_tooMuchPollution = false;
    private double m_extraPollution;

    // creation city
    private int m_createCityTentativeNumber = 0;

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        // get all the cities
        m_cities.AddRange(GetComponentsInChildren<City>());

        updateRessources();
    }

    // Update is called once per frame
    public void Update()
    {
        // set velocity planet
        GetComponent<Animator>().SetFloat("ArcVelocity", 1.0f / Config.m_timeUnit);

        // update ressources and UI
        updateRessources();

        // more population
        if (getPopulation() / 300 > m_createCityTentativeNumber)
        {
            m_cities[Random.Range(0, m_cities.Count)].becomeSomethingAwesome(City.KindCity.eCity);
            m_createCityTentativeNumber++;
        }

        // victory ?
        if (getPopulation() <= 0)
        {
            victory();
        }
    }

    public int getPopulation()
    {
        double l_population = 0;
        foreach (City l_City in m_cities)
        {
            l_population += l_City.A_population;
        }

        return (int) System.Math.Floor(l_population);
    }

    public void buySomething(int p_cost)
    {
        m_money -= p_cost;
    }

    public void rain(double p_rainingQuantity)
    {
        m_water += p_rainingQuantity;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void updateRessources()
    {
        // update ressources and UI
        m_populationText.GetComponent<Text>().text = "" + getPopulation();
        updateWater(Config.m_deltaTime);
        updateCoal(Config.m_deltaTime);
        updateMoney(Config.m_deltaTime);
        updateEnergy(Config.m_deltaTime);
        updatePollution(Config.m_deltaTime);
        m_time += Config.m_deltaTime;

        // update UI;
        m_coalText.GetComponent<Text>().text = "" + System.Math.Floor(m_coal);
        m_waterText.GetComponent<Text>().text = "" + System.Math.Floor(m_water);
        m_moneyText.GetComponent<Text>().text = "" + System.Math.Floor(m_money);
        m_energyText.GetComponent<Text>().text = "" + System.Math.Floor(m_energy);
        m_pollutionText.GetComponent<Text>().text = "" + System.Math.Floor(m_pollution);
        m_timeText.GetComponent<Text>().text = "" + System.Math.Floor(m_time);
    }

    private void victory()
    {
        Debug.Log("************ Victory !!! ************");
    }

    private void updateCoal(double p_deltaTime)
    {
        double l_production = 0;
        foreach (City l_City in m_cities)
        {
            l_production += l_City.getCoalProduction();
        }

        m_coal += l_production * p_deltaTime;
        m_coal = System.Math.Max(0, m_coal);
    }

    private void updateWater(double p_deltaTime)
    {
        double l_production = 0;
        foreach (City l_City in m_cities)
        {
            l_production += l_City.getWaterProduction();
        }

        m_water += l_production * p_deltaTime;

        if (m_notEnoughWater = m_water < 0)
        {
            m_waterNeeded = System.Math.Abs(m_water);
            m_water = 0;
        }
    }

    private void updateMoney(double p_deltaTime)
    {
        double l_production = 0;
        foreach (City l_City in m_cities)
        {
            l_production += l_City.getMoneyProduction();
        }

        m_money += l_production * p_deltaTime;
    }

    private void updateEnergy(double p_deltaTime)
    {
        double l_production = 0;

        foreach (City l_City in m_cities)
        {
            l_production += l_City.getEnergyProduction();
        }

        m_energy += l_production * p_deltaTime;
    }

    private void updatePollution(double p_deltaTime)
    {
        double l_production = 0;
        foreach (City l_City in m_cities)
        {
            l_production += l_City.getPollutionProduction();
        }

        m_pollution += l_production * p_deltaTime;

        if (m_tooMuchPollution = m_pollution > 100)
        {
            m_extraPollution = m_pollution - 100;
            m_pollution = 100;
        }

        m_pollution = System.Math.Max(0, System.Math.Min(m_pollution, 100));
    }
}
