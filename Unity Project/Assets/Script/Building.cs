/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/

public class Building :
    MonoBehaviour
{
    /***************************************************
	 ***  UNITY GUI PROPERTY    ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    
    [SerializeField]
    private Production m_pollution;
    [SerializeField]
    private Production m_coal;
    [SerializeField]
    private Production m_water;
    [SerializeField]
    private Production m_money;
    [SerializeField]
    private Production m_energy;
    [SerializeField]
    private List<Upgrades> m_coeffUpgrades = new List<Upgrades>();

    /***************************************************
	 ***  SUB-CLASSES           ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    [System.Serializable]
    public class Production
    {
        public bool m_change;
        public double m_value;
    }

    [System.Serializable]
    public class Upgrade
    {
        public double m_coeff;
        public Ressource m_ressource;
    }

    [System.Serializable]
    public class Upgrades
    {
        public Upgrade[] collection;
    }

    public enum Ressource
    {
        ePollution = 0,
        eCoal,
        eWater,
        eMoney,
        eEnergy
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/


    /***************************************************
	 ***  ATTRIBUTES            ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    public Dictionary<Ressource, Production> A_production
    {
        get
        {
            return m_production;
        }
    }

    private List<Upgrades> A_coeffUpgrades
    {
        get
        {
            return m_coeffUpgrades;
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    
    private Dictionary<Ressource, Production> m_production = new Dictionary<Ressource, Production>();

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        
    }

    // This function is called when the object becomes enabled and active.
    public void OnEnable()
    {
        m_production.Clear();

        m_production.Add(Ressource.ePollution, m_pollution);
        m_production.Add(Ressource.eCoal, m_coal);
        m_production.Add(Ressource.eWater, m_water);
        m_production.Add(Ressource.eMoney, m_money);
        m_production.Add(Ressource.eEnergy, m_energy);
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void doUpgrade(Upgrade[] l_upgrade)
    {
        foreach(var l_up in l_upgrade)
        {
            Production l_prod = m_production[l_up.m_ressource];

            if (! l_prod.m_change)
            {
                l_prod.m_value = l_up.m_coeff;
            }
            else
            {
                l_prod.m_value += l_prod.m_value * l_up.m_coeff;
            }
            l_prod.m_change = true;

            m_production[l_up.m_ressource] = l_prod;
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}
