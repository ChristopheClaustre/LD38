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
 
public class CameraTransition : MonoBehaviour
{
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
    public Camera m_cameraMain;
    public float m_animationTime;
    public Button m_buttonMainToTarget;
    public Button m_buttonTargetToMain;
    public bool m_isOnCity;
    public GameObject m_cityCameraCanvas;
    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    private float m_startTime;
    private Camera m_cameraTarget;
    private Camera m_cameraCity;
    private GameObject m_goStartTransform;
    private GameObject m_goTargetTransform;
    private float m_startSizeAttribute;
    private float m_targetSizeAttribute;
    private bool m_isOnTransition = false;
    private bool m_isOnMain = true;
    private bool m_isOnTarget = false;

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        m_goStartTransform = new GameObject("m_goStartTransform");
        m_goTargetTransform = new GameObject("m_goTargetTransform");
        Button btnTargetToMain = m_buttonTargetToMain.GetComponent<Button>();
        btnTargetToMain.onClick.AddListener(ActiveTansitionTargetToMain);
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (m_isOnTransition)
            updateCameraTransition();
        else if (m_isOnMain && m_cameraMain.GetComponent<Camera>().targetDisplay != 0)
        {
            m_cameraMain.targetDisplay = 0;
            gameObject.GetComponent<Camera>().targetDisplay = 2;
            gameObject.transform.position = m_goTargetTransform.transform.position;
            gameObject.transform.rotation = m_goTargetTransform.transform.rotation;
        }
        else if (m_isOnTarget && m_cameraCity.GetComponent<Camera>().targetDisplay != 0)
        {
            m_cameraCity.targetDisplay = 0;
            gameObject.GetComponent<Camera>().targetDisplay = 2;
            gameObject.transform.position = m_goTargetTransform.transform.position;
            gameObject.transform.rotation = m_goTargetTransform.transform.rotation;
        }
        m_isOnCity = m_isOnTarget;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    public void ActiveTansitionMainToTarget(Camera p_cameraCity)
    {
        if (m_isOnMain && !m_isOnTransition)
        {
            m_cameraCity = p_cameraCity;
            m_cameraMain.targetDisplay = 1;
            gameObject.GetComponent<Camera>().targetDisplay = 0;
            startCameraTransitionMainToTarget();
            m_isOnMain = false;
            m_isOnTarget = true;
        }
        ////Only append when player click again
        //else if (m_isOnTarget)
        //{
        //    m_isOnTransition = false;
        //}
    }

    private void ActiveTansitionTargetToMain()
    {
        if (m_isOnTarget && !m_isOnTransition)
        {
            m_cameraCity.gameObject.SetActive(false);
            m_cityCameraCanvas.GetComponent<GraphicRaycaster>().enabled = false;
            m_cameraCity.targetDisplay = 1;
            gameObject.GetComponent<Camera>().targetDisplay = 0;
            startCameraTransitionTargetToMain();
            m_isOnMain = true;
            m_isOnTarget = false;
        }
        //Only append when player click again
        //else if (m_isOnMain)
        //{
        //    m_isOnTransition = false;
        //}
    }

    private void startCameraTransitionTargetToMain()
    {
        m_cameraTarget = m_cameraMain;
        m_startTime = Time.time;
        m_goStartTransform.transform.position = m_cameraCity.transform.position;
        m_goStartTransform.transform.rotation = m_cameraCity.transform.rotation;
        m_goStartTransform.transform.localScale = m_cameraCity.transform.localScale;

        m_goTargetTransform.transform.position = m_cameraTarget.transform.position;
        m_goTargetTransform.transform.rotation = m_cameraTarget.transform.rotation;
        m_goTargetTransform.transform.localScale = m_cameraTarget.transform.localScale;
        
        m_startSizeAttribute = m_cameraCity.orthographicSize;
        m_targetSizeAttribute = m_cameraTarget.orthographicSize;
        m_isOnTransition = true;
    }

    private void startCameraTransitionMainToTarget()
    {
        m_cameraTarget = m_cameraCity;
        m_startTime = Time.time;

        m_goStartTransform.transform.position = m_cameraMain.transform.position;
        m_goStartTransform.transform.rotation = m_cameraMain.transform.rotation;
        m_goStartTransform.transform.localScale = m_cameraMain.transform.localScale;

        m_goTargetTransform.transform.position = m_cameraTarget.transform.position;
        m_goTargetTransform.transform.rotation = m_cameraTarget.transform.rotation;
        m_goTargetTransform.transform.localScale = m_cameraTarget.transform.localScale;

        Vector3 temp = m_goTargetTransform.transform.rotation.eulerAngles;
        temp.z += (((m_animationTime / Config.m_timeUnit) * 360.0f)) % 360.0f ;
        m_goTargetTransform.transform.rotation = Quaternion.Euler(temp);

        m_startSizeAttribute = m_cameraMain.orthographicSize;
        m_targetSizeAttribute = m_cameraTarget.orthographicSize;
        m_isOnTransition = true;
    }

    private void updateCameraTransition()
    {
        if (Time.time < m_startTime + m_animationTime)
        {
            m_goTargetTransform.transform.position = m_cameraTarget.transform.position;
            float i = (Time.time - m_startTime) / m_animationTime;
            gameObject.transform.position = Vector3.Lerp(m_goStartTransform.transform.position, m_goTargetTransform.transform.position, i);
            gameObject.transform.rotation = Quaternion.Lerp(m_goStartTransform.transform.rotation, m_goTargetTransform.transform.rotation, i);
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(m_startSizeAttribute, m_targetSizeAttribute, i);
        }
        else
        {
            m_isOnTransition = false;
        }

    }
}

		
