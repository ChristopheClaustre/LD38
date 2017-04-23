/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/

public class CityUI :
    MonoBehaviour
{
    /***************************************************
	 ***  UNITY GUI PROPERTY    ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // UI
    public GameObject m_populationText;
    public GameObject m_coalText;
    public GameObject m_waterText;
    public GameObject m_moneyText;
    public GameObject m_energyText;
    public GameObject m_pollutionText;

    public GameObject m_cityGO;

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

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        updateUI();
    }

    // Update is called once per frame
    public void Update()
    {
        updateUI();
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void updateUI()
    {
        // update UI
        m_populationText.GetComponent<Text>().text = "" + Math.Floor(m_cityGO.GetComponent<City>().A_population);
        m_coalText.GetComponent<Text>().text = "" + m_cityGO.GetComponent<City>().getCoalConsumption();
        m_waterText.GetComponent<Text>().text = "" + m_cityGO.GetComponent<City>().getWaterConsumption();
        m_moneyText.GetComponent<Text>().text = "" + m_cityGO.GetComponent<City>().getMoneyProduction();
        m_energyText.GetComponent<Text>().text = "" + m_cityGO.GetComponent<City>().getEnergyProduction();
        m_pollutionText.GetComponent<Text>().text = "" + m_cityGO.GetComponent<City>().getPollutionProduction();
    }

}
