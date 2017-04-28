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

    public bool m_canBeDestroy = false;
    
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
    [SerializeField]
    private int m_costPerLevel;

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
        public int m_cost;
        public Upgrade[] m_upgrades;
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

    private int m_level = 1;

    /***************************************************
	 ***  ATTRIBUTES            ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    public List<Production> A_production
    {
        get
        {
            return m_production;
        }
    }

    public List<Upgrades> A_coeffUpgrades
    {
        get
        {
            return m_coeffUpgrades;
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    
    public List<Production> m_production = new List<Production>();

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        OnEnable();
    }

    // This function is called when the object becomes enabled and active.
    public void OnEnable()
    {
        m_production.Clear();
        
        m_production.Add(m_pollution);
        m_production.Add(m_coal);
        m_production.Add(m_water);
        m_production.Add(m_money);
        m_production.Add(m_energy);

        m_level = 1;
    }

    // This function is called when the object becomes disabled.
    private void OnDisable()
    {
        OnEnable();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void doUpgrade(Upgrades l_upgrade)
    {
        foreach(var l_up in l_upgrade.m_upgrades)
        {
            Production l_prod = m_production[(int) l_up.m_ressource];

            if (! l_prod.m_change)
            {
                l_prod.m_value = l_up.m_coeff;
            }
            else
            {
                l_prod.m_value += l_prod.m_value * l_up.m_coeff;
            }
            l_prod.m_change = true;

            m_production[(int) l_up.m_ressource] = l_prod;
        }

        m_level ++;
    }

    public int getUpgradeCost()
    {
        return m_costPerLevel * m_level;
    }

    public int getDestructionCost()
    {
        return Mathf.RoundToInt(getUpgradeCost() * 1.5f);
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}
