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

    public GameObject m_pivotRotation;
    public GameObject m_pivotDisparation;

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
    public double m_waterQuantity = 100;

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    public double m_ratioWaterTTL;

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
        m_waterQuantity = Random.Range(Config.m_limitRainedQuantity.x, Config.m_limitRainedQuantity.y);

        // rotation
        m_pivotRotation.transform.rotation = Quaternion.Euler(0, 0, m_beginningOrientation);

        // compute ratio
        m_ratioWaterTTL = m_waterQuantity / m_TTL;
    }

    // Update is called once per frame
    public void Update()
    {
        // set velocity cloud
        GetComponent<Animator>().SetFloat("ArcVelocity", m_velocityCoeff / Config.m_timeUnit);

        // update waterQuantity
        double l_rain = Config.m_deltaTime * m_ratioWaterTTL;
        m_waterQuantity -= l_rain;
        Planet.A_instance.rain(l_rain);

        // set velocity of the animation of progressive disapearing
//        m_pivotDisparation.GetComponent<Animator>().SetFloat("ArcVelocity", (float) m_TTL / Config.m_timeUnit);
        m_pivotDisparation.transform.localScale = Vector3.one * ((float)m_waterQuantity / Config.m_limitRainedQuantity.y);

        // destroy object ??
        if (m_waterQuantity <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}