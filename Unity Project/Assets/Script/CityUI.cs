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

    //UI Panels
    public GameObject m_shopPanel;
    public GameObject m_zone0Panel;
    public GameObject m_zone1Panel;
    public GameObject m_zone2Panel;
    public GameObject m_zone3Panel;


    public GameObject m_shopBuildings;

    //UI Scroll
    public Scrollbar shopScrollBar;


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
        initializeUI();
        updateUI();
    }

    // Update is called once per frame
    public void Update()
    {
        updateUI();
    }

    public void showShop()
    {
        m_shopPanel.SetActive(!m_shopPanel.activeSelf);
    }

    public void showZone0()
    {
        m_zone0Panel.SetActive(!m_zone0Panel.activeSelf);
        //m_shopPanel.SetActive(false);
    }

    public void showZone1()
    {
        m_zone1Panel.SetActive(!m_zone1Panel.activeSelf);
        //m_shopPanel.SetActive(false);
    }

    public void showZone2()
    {
        m_zone2Panel.SetActive(!m_zone2Panel.activeSelf);
        //m_shopPanel.SetActive(false);
    }

    public void showZone3()
    {
        m_zone3Panel.SetActive(!m_zone3Panel.activeSelf);
        //m_shopPanel.SetActive(false);
    }

    public void scrollShop()
    {
        m_shopBuildings.transform.localPosition = new Vector3(0, shopScrollBar.value*400, 0);
        //m_shopPanel.SetActive(false);
    }


    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    private void initializeUI()
    {
        m_shopPanel.SetActive(false);
        m_zone0Panel.SetActive(false);
        m_zone1Panel.SetActive(false);
        m_zone2Panel.SetActive(false);
        m_zone3Panel.SetActive(false);
    }

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
