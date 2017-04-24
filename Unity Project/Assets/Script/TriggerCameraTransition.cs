/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using UnityEngine.UI;
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

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    private CameraTransition m_camTransitionSc;
    private Camera m_closeViewCamera;
    private GameObject m_cityCameraCanvas;
    private CityUI m_cityUIScript;

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        m_camTransitionSc = GameObject.FindWithTag("CameraTransition").GetComponent<CameraTransition>();
        m_closeViewCamera = gameObject.transform.parent.gameObject.GetComponent<City>().m_closeViewCamera;
        m_cityCameraCanvas = m_camTransitionSc.m_cityCameraCanvas;
        m_cityCameraCanvas.GetComponent<GraphicRaycaster>().enabled = false;
        m_cityUIScript = GameObject.Find("City Camera Canvas").GetComponent<CityUI>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clic = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (gameObject.GetComponent<Collider2D>().bounds.Contains(new Vector3(clic.x, clic.y,0)))
                OnMouseDown();
        }

    }

    public void OnMouseDown()
    {

        if (m_camTransitionSc != null && m_closeViewCamera != null)
        {
            if(! m_camTransitionSc.m_isOnCity)
            {
                m_cityCameraCanvas.GetComponent<GraphicRaycaster>().enabled = true;
                m_cityUIScript.A_cityGO = gameObject.transform.parent.gameObject;
                m_closeViewCamera.gameObject.SetActive(true);
                m_cityCameraCanvas.GetComponent<Canvas>().worldCamera = m_closeViewCamera;
                m_camTransitionSc.ActiveTansitionMainToTarget(m_closeViewCamera);
            }
        }
           
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
}


