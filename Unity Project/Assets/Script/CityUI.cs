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

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    [SerializeField]
    private GameObject m_cityGO;

    /***************************************************
	 ***  SUB-CLASSES           ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    public GameObject A_cityGO
    {
        get
        {
            return m_cityGO;
        }

        set
        {
            m_cityGO = value;
            if (m_cityGO != null)
            {
                this.GetComponent<Canvas>().worldCamera = m_cityGO.GetComponentInChildren<Camera>();
            }
        }
    }

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
        A_cityGO = m_cityGO;
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
        if (m_cityGO != null)
        {
            // update UI
            m_populationText.GetComponent<Text>().text = "" + Math.Floor(m_cityGO.GetComponentInChildren<City>().A_population);
            m_coalText.GetComponent<Text>().text = "" + m_cityGO.GetComponentInChildren<City>().getCoalConsumption();
            m_waterText.GetComponent<Text>().text = "" + m_cityGO.GetComponentInChildren<City>().getWaterConsumption();
            m_moneyText.GetComponent<Text>().text = "" + m_cityGO.GetComponentInChildren<City>().getMoneyProduction();
            m_energyText.GetComponent<Text>().text = "" + m_cityGO.GetComponentInChildren<City>().getEnergyProduction();
            m_pollutionText.GetComponent<Text>().text = "" + m_cityGO.GetComponentInChildren<City>().getPollutionProduction();
        }
    }

}
