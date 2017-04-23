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
        m_velocityCoeff = Random.Range(-1.0f, 1.0f);
        m_TTL = Random.Range(0.2f, 3.0f);
        m_rainedQuantity = Random.Range(800, 1200);

        // set velocity cloud
        GetComponent<Animator>().SetFloat("ArcVelocity", m_velocityCoeff / Planet.A_instance.A_timeUnit);
        
        m_pivot.transform.localScale *= m_rainedQuantity / 1000.0f;
        m_pivot.transform.rotation = Quaternion.Euler(0, 0, m_beginningOrientation);
    }

    // Update is called once per frame
    public void Update()
    {
        m_TTL -= Planet.A_deltaTime;

        if (m_TTL <= 0)
        {
            Planet.A_instance.rain(m_rainedQuantity);
            Destroy(this.gameObject);
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}