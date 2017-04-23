/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
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

    public int A_pollutionBonus
    {
        get
        {
            return m_pollutionBonus;
        }
    }
    public int A_timeUnit
    {
        get
        {
            return m_timeUnit;
        }
    }
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
    public static double A_deltaTime
    {
        get
        {
            return m_deltaTime;
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

    // constant
    [SerializeField]
    private int m_timeUnit = 60;
    [SerializeField]
    private int m_pollutionBonus = 10;

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

    private static double m_deltaTime;

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        // set velocity planet
        GetComponent<Animator>().SetFloat("ArcVelocity", 1.0f / m_timeUnit);

        // get all the cities
        m_cities.AddRange(GetComponentsInChildren<City>());

        // UI
        m_populationText.GetComponent<Text>().text = "" + getPopulation();
        m_coalText.GetComponent<Text>().text = "" + Math.Round(m_coal);
        m_waterText.GetComponent<Text>().text = "" + Math.Round(m_water);
        m_moneyText.GetComponent<Text>().text = "" + Math.Round(m_money);
        m_energyText.GetComponent<Text>().text = "" + Math.Round(m_energy);
        m_pollutionText.GetComponent<Text>().text = "" + Math.Round(m_pollution);
        m_timeText.GetComponent<Text>().text = "" + Math.Floor(m_time);
    }

    // Update is called once per frame
    public void Update()
    {
        m_deltaTime = Time.deltaTime / 60;

        m_populationText.GetComponent<Text>().text = "" + getPopulation();

        updateCoal(m_deltaTime);
        m_coalText.GetComponent<Text>().text = "" + Math.Floor(m_coal);

        updateWater(m_deltaTime);
        m_waterText.GetComponent<Text>().text = "" + Math.Floor(m_water);

        updateMoney(m_deltaTime);
        m_moneyText.GetComponent<Text>().text = "" + Math.Floor(m_money);

        updateEnergy(m_deltaTime);
        m_energyText.GetComponent<Text>().text = "" + Math.Floor(m_energy);

        updatePollution(m_deltaTime);
        m_pollutionText.GetComponent<Text>().text = "" + Math.Floor(m_pollution);

        m_time += m_deltaTime;
        m_timeText.GetComponent<Text>().text = "" + Math.Floor(m_time);
    }

    public int getPopulation()
    {
        double l_population = 0;
        foreach (City l_City in m_cities)
        {
            l_population += l_City.A_population;
        }

        return (int) Math.Floor(l_population);
    }

    public void buySomething(int p_cost)
    {
        m_money -= p_cost;
    }

    public void rain(int p_rainingQuantity)
    {
        m_water += p_rainingQuantity;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void updateCoal(double p_deltaTime)
    {
        double l_consumption = 0;
        foreach (City l_City in m_cities)
        {
            l_consumption += l_City.getCoalConsumption();
        }

        m_coal -= l_consumption * p_deltaTime;
    }

    private void updateWater(double p_deltaTime)
    {
        double l_consumption = 0;
        foreach (City l_City in m_cities)
        {
            l_consumption += l_City.getWaterConsumption();
        }

        m_water -= l_consumption * p_deltaTime;
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
        double l_consumption = 0;
        double l_production = 0;

        foreach (City l_City in m_cities)
        {
            l_consumption += l_City.getEnergyProduction();
            l_production  += l_City.getEnergyConsumption();
        }

        m_energy -= l_consumption * p_deltaTime;
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
        m_pollution -= A_pollutionBonus * p_deltaTime;
    }

}
