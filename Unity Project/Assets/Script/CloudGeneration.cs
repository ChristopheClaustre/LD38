/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/

public class CloudGeneration :
    MonoBehaviour
{
    /***************************************************
	 ***  UNITY GUI PROPERTY    ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    public Vector2 m_limitTimer = new Vector2(0.2f, 0.5f);

    public GameObject m_prefabCloud;
    
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

    private double m_timerCloud = 0;

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        computeTimer();
    }

    // Update is called once per frame
    public void Update()
    {
        m_timerCloud -= Config.m_deltaTime;

        if (m_timerCloud <= 0)
        {
            generate();
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void generate()
    {
        computeTimer();
        Instantiate(m_prefabCloud);
    }

    private void computeTimer()
    {
        m_timerCloud = Random.Range(m_limitTimer.x, m_limitTimer.y);
    }
}
