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
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void OnMouseDown()
    {
        Debug.Log(m_camTransitionSc);
        if(m_camTransitionSc)
            m_camTransitionSc.ActiveTansitionMainToTarget(m_closeViewCamera);
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
}


