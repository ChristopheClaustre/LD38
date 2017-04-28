/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
    public GameObject m_cityNameText;
    public GameObject m_populationText;

    //UI Text Button
    [Header("Button")]
    public GameObject[] m_destroyButtons = new GameObject[4] { null, null, null, null };
    public GameObject[] m_upgradeButtons = new GameObject[4] { null, null, null, null };

    //UI Panels
    [Header("Panel")]
    public GameObject m_shopPanel;
    public List<GameObject> m_buildingPanels = new List<GameObject>() { null, null, null, null };

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
    public Sprite m_iconLockSprite;


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
    private bool[] m_isReadyToDestroyZone = new bool[4] { false, false, false, false };
    private int m_selectedId = -1;

    private const String LAST_MESSAGE_DESTROY = "SURE ?";
    private const String NORMAL_MESSAGE_DESTROY = "Destroy";

    private double m_lastConsoCoal;
    private double m_lastConsoWater;
    private double m_lastConsoMoney;
    private double m_lastConsoEnergy;
    private double m_lastConsoPollution;

    private List<Building> m_buildings_list;

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

    public void showShop(int p_id)
    {
        m_shopPanel.SetActive(m_selectedId != p_id);
        m_selectedId = (m_selectedId == p_id)? -1 : p_id;
    }

    public void ShowZone(int p_id)
    {
        m_destroyButtons[p_id].GetComponentInChildren<Text>().text = NORMAL_MESSAGE_DESTROY;
        m_buildingPanels[p_id].SetActive(!m_buildingPanels[p_id].activeSelf);

        if (m_selectedId == p_id)
        {
            showShop(p_id);
        }
    }

    public void DestroyZone(int p_id)
    {
        if (!m_isReadyToDestroyZone[p_id])
        {
            m_destroyButtons[p_id].GetComponentInChildren<Text>().text = LAST_MESSAGE_DESTROY;
            m_isReadyToDestroyZone[p_id] = true;
        }
        else
        {
            m_cityGO.GetComponentInChildren<City>().changeBuilding(p_id, "Park");
            m_isReadyToDestroyZone[p_id] = false;
        }
    }

    public void scrollShop()
    {
        m_shopBuildings.transform.localPosition = new Vector3(0, m_shopScrollBar.value*400, 0);
    }

    public void changeBuilding(string p_name)
    {
        m_cityGO.GetComponentInChildren<City>().changeBuilding(m_selectedId, p_name);
        showShop(m_selectedId);
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    private void initializeUI()
    {
        m_shopPanel.SetActive(false);
        m_buildingPanels[0].SetActive(false);
        m_buildingPanels[1].SetActive(false);
        m_buildingPanels[2].SetActive(false);
        m_buildingPanels[3].SetActive(false);

        m_isReadyToDestroyZone = new bool[4] { false, false, false, false };

        m_lastConsoCoal = 0;
        m_lastConsoWater = 0;
        m_lastConsoMoney = 0;
        m_lastConsoEnergy = 0;
        m_lastConsoPollution = 0;
        /*
        m_buildings_panel.Add(m_zonePanel[0]);
        m_buildings_panel.Add(m_zonePanel[1]);
        m_buildings_panel.Add(m_zonePanel[2]);
        m_buildings_panel.Add(m_zonePanel[3]);*/
    }

    private void updateUI()
    {
        if (m_cityGO != null)
        {
            m_buildings_list = m_cityGO.GetComponentInChildren<City>().A_buildings;

            //**********************************
            //UPDATE PRODUCTION
            //**********************************
            // update UI
            m_populationText.GetComponent<Text>().text = "" + Math.Floor(m_cityGO.GetComponentInChildren<City>().A_population);
            m_cityNameText.GetComponent<Text>().text = m_cityGO.GetComponentInChildren<City>().m_name;

            //Update Coal comsumption
            double l_coalConso = Math.Floor(m_cityGO.GetComponentInChildren<City>().getCoalProduction());
            updateRessource(l_coalConso, m_lastConsoCoal, m_coalGo);
            m_lastConsoCoal = l_coalConso;

            //Update Water comsumption
            double l_waterConso = Math.Floor(m_cityGO.GetComponentInChildren<City>().getWaterProduction());
            updateRessource(l_waterConso, m_lastConsoWater, m_waterGo);
            m_lastConsoWater = l_waterConso;

            //Update Money production
            double l_moneyConso = Math.Floor(m_cityGO.GetComponentInChildren<City>().getMoneyProduction());
            updateRessource(l_moneyConso, m_lastConsoMoney, m_moneyGo);
            m_lastConsoMoney = l_moneyConso;

            //Update Energie production
            double l_energyConso = Math.Floor(m_cityGO.GetComponentInChildren<City>().getEnergyProduction());
            updateRessource(l_energyConso, m_lastConsoEnergy, m_energyGo);
            m_lastConsoEnergy = l_energyConso;

            //Update Pollution production
            double l_pollutionConso = Math.Floor(m_cityGO.GetComponentInChildren<City>().getPollutionProduction());
            updateRessource(l_pollutionConso, m_lastConsoPollution, m_pollutionGo);
            m_lastConsoPollution = l_pollutionConso;


            //**********************************
            //UPDATE BUILDINGS
            //**********************************
            
            for (int i = 0; i < m_buildings_list.Count; ++i)
            {
                //Destroy button interactibility
                m_destroyButtons[i].GetComponent<Button>().interactable = m_buildings_list[i].m_canBeDestroy;

                //Upgrade button interactibility
                m_upgradeButtons[i].GetComponent<Button>().interactable = m_buildings_list[i].A_coeffUpgrades.Count > 0;

                //Update coal
                if (!m_buildings_list[i].A_production[(int)Building.Ressource.eCoal].m_change)
                {
                    m_buildingPanels[i].transform.Find("Coal").GetComponent<Text>().text = " --";
                }
                else
                {
                    m_buildingPanels[i].transform.Find("Coal").GetComponent<Text>().text = "" + m_buildings_list[i].A_production[(int)Building.Ressource.eCoal].m_value;
                }
                //Update water
                if (!m_buildings_list[i].A_production[(int)Building.Ressource.eWater].m_change)
                {
                    m_buildingPanels[i].transform.Find("Water").GetComponent<Text>().text = " --";
                }
                else
                {
                    m_buildingPanels[i].transform.Find("Water").GetComponent<Text>().text = "" + m_buildings_list[i].A_production[(int)Building.Ressource.eWater].m_value;
                }

                if (!m_buildings_list[i].A_production[(int)Building.Ressource.eMoney].m_change)
                {
                    m_buildingPanels[i].transform.Find("Money").GetComponent<Text>().text = " --";
                }
                else
                {
                    m_buildingPanels[i].transform.Find("Money").GetComponent<Text>().text = "" + m_buildings_list[i].A_production[(int)Building.Ressource.eMoney].m_value;
                }

                if (!m_buildings_list[i].A_production[(int)Building.Ressource.eEnergy].m_change)
                {
                    m_buildingPanels[i].transform.Find("Energy").GetComponent<Text>().text = " --";
                }
                else
                {
                    m_buildingPanels[i].transform.Find("Energy").GetComponent<Text>().text = "" + m_buildings_list[i].A_production[(int)Building.Ressource.eEnergy].m_value;
                }

                if (!m_buildings_list[i].A_production[(int)Building.Ressource.ePollution].m_change)
                {
                    m_buildingPanels[i].transform.Find("Pollution").GetComponent<Text>().text = " --";
                }
                else
                {
                    m_buildingPanels[i].transform.Find("Pollution").GetComponent<Text>().text = "" + m_buildings_list[i].A_production[(int)Building.Ressource.ePollution].m_value;
                }
                
                if (!m_buildings_list[i].gameObject.GetComponent<SpriteRenderer>().enabled)
                {
                    m_buildings_list[i].gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    m_buildingPanels[i].transform.parent.transform.Find("zone").GetComponent<Image>().sprite = m_buildings_list[i].gameObject.GetComponent<SpriteRenderer>().sprite;
                    m_buildings_list[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    m_buildingPanels[i].transform.parent.transform.Find("zone").GetComponent<Image>().sprite = m_buildings_list[i].gameObject.GetComponent<SpriteRenderer>().sprite;
                }
                
            }

        }
    }

    private void updateRessource(double l_production, double m_lastProduction, GameObject m_go)
    {
        //Update Pollution production
        m_go.GetComponentInChildren<Text>().text = "" + Math.Abs(l_production);
        if (l_production >= m_lastProduction)
            m_go.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowUpSprite;
        else
            m_go.transform.Find("fleche_prod").GetComponent<Image>().sprite = m_iconArrowDownSprite;

        if (l_production >= 0)
            m_go.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconPlusSprite;
        else
            m_go.transform.Find("Panel").transform.Find("Signe").GetComponent<Image>().sprite = m_iconMinusSprite;
    }
    
}
