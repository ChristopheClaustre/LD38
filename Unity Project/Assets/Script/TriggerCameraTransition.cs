/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/


public class TriggerCameraTransition : MonoBehaviour {

    /***************************************************
	 ***  UNITY GUI PROPERTY    ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

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
    private CameraTransition m_camTransitionSc;
    private Camera m_closeViewCamera;
    private GameObject m_cityCameraCanvas;
    private CityUI m_cityUIScript;

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/


    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        m_camTransitionSc = GameObject.FindWithTag("CameraTransition").GetComponent<CameraTransition>();
        m_closeViewCamera = gameObject.transform.parent.gameObject.GetComponent<City>().m_closeViewCamera;
        m_cityUIScript = GameObject.Find("City Camera Canvas").GetComponent<CityUI>();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (m_camTransitionSc != null && m_closeViewCamera != null)
        {
            m_cityUIScript.A_cityGO = gameObject.transform.parent.gameObject;
            m_closeViewCamera.gameObject.SetActive(true);
            m_camTransitionSc.ActiveTansitionMainToTarget(m_closeViewCamera);
        }
           
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
}


