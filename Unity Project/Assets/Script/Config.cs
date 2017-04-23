/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/

public class Config :
    MonoBehaviour
{
    /***************************************************
	 ***  UNITY GUI PROPERTY    ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    public int m_timeUnit_GUI;
    public int m_deltaTime_GUI;

    public double m_killingCoeff_GUI;

    public Vector2 m_limitTimerWind_GUI = new Vector2(0.1f, 0.5f);
    public Vector2 m_limitVelocityCoeff_GUI = new Vector2(-0.5f, 1.0f);
    public Vector2 m_limitTTL_GUI = new Vector2(0.2f, 2.0f);
    public Vector2 m_limitRainedQuantity_GUI = new Vector2(800, 1200);

    public List<double> m_satisfactionCoeff_GUI = new List<double> { 0.5, 0.75, 1, 1.15 };
    public List<int> m_satisfactionThreshold_GUI = new List<int> { 20, 10, 5, 2 };
    public List<double> m_windStrengthCoeff_GUI = new List<double> { 0.25, 0.75, 1, 2 };

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

    public static int m_timeUnit;
    public static double m_deltaTime;

    public static double m_killingCoeff;

    public static Vector2 m_limitTimerWind;
    public static Vector2 m_limitVelocityCoeff;
    public static Vector2 m_limitTTL;
    public static Vector2 m_limitRainedQuantity;

    public static List<double> m_satisfactionCoeff;
    public static List<int> m_satisfactionThreshold;
    public static List<double> m_windStrengthCoeff;

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        Update();
    }

    // Update is called once per frame
    public void Update()
    {
        m_timeUnit = m_timeUnit_GUI;
        m_deltaTime = Time.deltaTime / m_timeUnit;
        m_killingCoeff = m_killingCoeff_GUI;
        m_limitTimerWind = m_limitTimerWind_GUI;
        m_limitVelocityCoeff = m_limitVelocityCoeff_GUI;
        m_limitTTL = m_limitTTL_GUI;
        m_limitRainedQuantity = m_limitRainedQuantity_GUI;

        m_satisfactionCoeff.Clear();
        m_satisfactionCoeff.AddRange(m_satisfactionCoeff_GUI);
        m_satisfactionThreshold.Clear();
        m_satisfactionThreshold.AddRange(m_satisfactionThreshold_GUI);
        m_windStrengthCoeff.Clear();
        m_windStrengthCoeff.AddRange(m_windStrengthCoeff_GUI);
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}