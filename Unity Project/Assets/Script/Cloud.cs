/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/

public class Cloud : MonoBehaviour
{
    /***************************************************
	 ***  UNITY GUI PROPERTY    ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    public GameObject m_pivot;

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

    public float m_beginningOrientation = 24;
    public float m_velocityCoeff = 0.2f;
    public double m_TTL = 0;
    public int m_rainedQuantity = 100;

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/
    // Use this for initialization
    public void Start()
    {
        // generation
        m_beginningOrientation = Random.Range(0, 360);
        m_velocityCoeff = Random.Range(Config.m_limitVelocityCoeff.x, Config.m_limitVelocityCoeff.y);
        m_TTL = Random.Range(Config.m_limitTTL.x, Config.m_limitTTL.y);
        m_rainedQuantity = Random.Range((int) Config.m_limitRainedQuantity.x, (int) Config.m_limitRainedQuantity.y);
        
        // scaling function of rainedQuantity
        m_pivot.transform.rotation = Quaternion.Euler(0, 0, m_beginningOrientation);
    }

    // Update is called once per frame
    public void Update()
    {
        // set velocity cloud
        GetComponent<Animator>().SetFloat("ArcVelocity", m_velocityCoeff / Config.m_timeUnit);

        // update TTL
        m_TTL -= Config.m_deltaTime;

        if (m_TTL <= 0)
        {
            Planet.A_instance.rain(m_rainedQuantity);
            Destroy(this.gameObject);
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}