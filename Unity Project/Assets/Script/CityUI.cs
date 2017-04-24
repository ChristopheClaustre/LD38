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
    [Header("Game Object Resource")]
    public GameObject m_coalGo;
    public GameObject m_waterGo;
    public GameObject m_moneyGo;
    public GameObject m_energyGo;
    public GameObject m_pollutionGo;

    [Header("Text")]
    public GameObject m_populationText;
    //UI Text Button
    public GameObject m_destroyZone0Text;
    public GameObject m_destroyZone1Text;
    public GameObject m_destroyZone2Text;
    public GameObject m_destroyZone3Text;

    //UI Panels
    [Header("Panel")]
    public GameObject m_shopPanel;
    public GameObject m_zone0Panel;
    public GameObject m_zone1Panel;
    public GameObject m_zone2Panel;
    public GameObject m_zone3Panel;

    //UI Building
    [Header("ShopBuilding")]
    public GameObject m_shopBuildings;

    //UI Scroll
    [Header("ScrollBar")]
    public Scrollbar m_shopScrollBar;

    //UI Sprite
    [Header("Sprite")]
    public Sprite m_iconArrowUpSprite;
    public Sprite m_iconArrowDownSprite;
    public Sprite m_iconPlusSprite;
    public Sprite m_iconMinusSprite;
    

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
    private bool isReadyToDestroyZone0;
    private bool isReadyToDestroyZone1;
    private bool isReadyToDestroyZone2;
    private bool isReadyToDestroyZone3;

    private const String LAST_MESSAGE_DESTROY = "SURE ?";
    private const String NORMAL_MESSAGE_DESTROY = "Destroy";

    private double m_lastConsoCoal;
    private double m_lastConsoWater;
    private double m_lastConsoMoney;
    private double m_lastConsoEnergy;
    private double m_lastConsoPollution;

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
        m_destroyZone0Text.GetComponent<Text>().text = NORMAL_MESSAGE_DESTROY;
        m_zone0Panel.SetActive(!m_zone0Panel.activeSelf);

        //m_shopPanel.SetActive(false);
    }

    public void showZone1()
    {
        m_destroyZone1Text.GetComponent<Text>().text = NORMAL_MESSAGE_DESTROY;
        m_zone1Panel.SetActive(!m_zone1Panel.activeSelf);
        //m_shopPanel.SetActive(false);
    }

    public void showZone2()
    {
        m_destroyZone2Text.GetComponent<Text>().text = NORMAL_MESSAGE_DESTROY;
        m_zone2Panel.SetActive(!m_zone2Panel.activeSelf);
        //m_shopPanel.SetActive(false);
    }

    public void showZone3()
    {
        m_destroyZone3Text.GetComponent<Text>().text = NORMAL_MESSAGE_DESTROY;
        m_zone3Panel.SetActive(!m_zone3Panel.activeSelf);
        //m_shopPanel.SetActive(false);
    }


    public void DestroyZone0()
    {
        if(!isReadyToDestroyZone0)
        {
            m_destroyZone0Text.GetComponent<Text>().text = LAST_MESSAGE_DESTROY;
            isReadyToDestroyZone0 = true;
        }
        else
        {
            Debug.Log("Not yet implemented");
            isReadyToDestroyZone0 = false;
        }
    }

    public void DestroyZone1()
    {
        if (!isReadyToDestroyZone1)
        {
            m_destroyZone1Text.GetComponent<Text>().text = LAST_MESSAGE_DESTROY;
            isReadyToDestroyZone1 = true;
        }
        else
        {
            Debug.Log("Not yet implemented");
            isReadyToDestroyZone1 = false;
        }
    }

    public void DestroyZone2()
    {
        if (!isReadyToDestroyZone2)
        {
            m_destroyZone2Text.GetComponent<Text>().text = LAST_MESSAGE_DESTROY;
            isReadyToDestroyZone2 = true;
        }
        else
        {
            Debug.Log("Not yet implemented");
            isReadyToDestroyZone2 = false;
        }
    }

    public void DestroyZone3()
    {
        if (!isReadyToDestroyZone3)
        {
            m_destroyZone3Text.GetComponent<Text>().text = LAST_MESSAGE_DESTROY;
            isReadyToDestroyZone3 = true;
        }
        else
        {
            Debug.Log("Not yet implemented");
            isReadyToDestroyZone3 = false;
        }
    }

    public void scrollShop()
    {
        m_shopBuildings.transform.localPosition = new Vector3(0, m_shopScrollBar.value*400, 0);
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

        isReadyToDestroyZone0 = false;
        isReadyToDestroyZone1 = false;
        isReadyToDestroyZone2 = false;
        isReadyToDestroyZone3 = false;

        m_lastConsoCoal = 0;
        m_lastConsoWater = 0;
        m_lastConsoMoney = 0;
        m_lastConsoEnergy = 0;
        m_lastConsoPollution = 0;
    }

    private void updateUI()
    {
        if (m_cityGO != null)
        {
            // update UI
            m_populationText.GetComponent<Text>().text = "" + Math.Floor(m_cityGO.GetComponentInChildren<City>().A_population);

            //Update Coal comsumption
            double l_coalConso = Math.Floor(m_cityGO.GetComponentInChildren<City>().getCoalConsumption());
            m_coalGo.GetComponentInChildren<Text>().text = "" + Math.Abs(l_coalConso);
            if (l_coalConso >= m_lastConsoCoal)
                m_coalGo.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowUpSprite;
            else
                 m_coalGo.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowDownSprite;

            if(l_coalConso >= 0)
                m_coalGo.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconPlusSprite;
            else
                m_coalGo.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconMinusSprite;
            m_lastConsoCoal = l_coalConso;
            

            //Update Water comsumption
            double l_waterConso = Math.Floor(m_cityGO.GetComponentInChildren<City>().getWaterConsumption());
            m_waterGo.GetComponentInChildren<Text>().text = "" + Math.Abs(l_waterConso);
            if (l_waterConso >= m_lastConsoWater)
                m_waterGo.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowUpSprite;
            else
                m_waterGo.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowDownSprite;

            if (l_waterConso >= 0)
                m_waterGo.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconPlusSprite;
            else
                m_waterGo.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconMinusSprite;
            m_lastConsoWater = l_waterConso;

            //Update Moner production
            double l_moneyConso = Math.Floor(m_cityGO.GetComponentInChildren<City>().getMoneyProduction());
            m_moneyGo.GetComponentInChildren<Text>().text = "" + Math.Abs(l_moneyConso);
            if (l_moneyConso >= m_lastConsoMoney)
                m_moneyGo.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowUpSprite;
            else
                m_moneyGo.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowDownSprite;

            if (l_moneyConso >= 0)
                m_moneyGo.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconPlusSprite;
            else
                m_moneyGo.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconMinusSprite;
            m_lastConsoMoney = l_moneyConso;

            //Update Energie production
            double l_energyConso = Math.Floor(m_cityGO.GetComponentInChildren<City>().getEnergyProduction());
            m_energyGo.GetComponentInChildren<Text>().text = "" + Math.Abs(l_energyConso);
            if (l_energyConso >= m_lastConsoEnergy)
                m_energyGo.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowUpSprite;
            else
                m_energyGo.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowDownSprite;

            if (l_energyConso >= 0)
                m_energyGo.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconPlusSprite;
            else
                m_energyGo.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconMinusSprite;
            m_lastConsoEnergy = l_energyConso;

            //Update Pollution production
            double l_pollutionConso = Math.Floor(m_cityGO.GetComponentInChildren<City>().getPollutionProduction());
            m_pollutionGo.GetComponentInChildren<Text>().text = "" + Math.Abs(l_pollutionConso);
            if (l_pollutionConso >= m_lastConsoPollution)
                m_pollutionGo.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowUpSprite;
            else
                m_pollutionGo.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowDownSprite;

            if (l_pollutionConso >= 0)
                m_pollutionGo.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconPlusSprite;
            else
                m_pollutionGo.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconMinusSprite;
            m_lastConsoPollution = l_pollutionConso;
        }
    }
    

}
