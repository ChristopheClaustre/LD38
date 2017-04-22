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
    public Camera cameraMain;
    public Camera cameraCity;
    public Camera cameraTarget;
    public float animationTime;
    public Button buttonMainToTarget;
    public Button buttonTargetToMain;
    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    private float startTime;
    private Transform startTransform;
    private Transform targetTransform;
    private float startSizeAttribute;
    private float targetSizeAttribute;
    private bool isOnTransition;
    private bool isOnMain = true;
    private bool isOnTarget = false;

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {

        Button btnMainToTarget = buttonMainToTarget.GetComponent<Button>();
        btnMainToTarget.onClick.AddListener(ActiveTansitionMainToTarget);
        Button btnTargetToMain = buttonTargetToMain.GetComponent<Button>();
        btnTargetToMain.onClick.AddListener(ActiveTansitionTargetToMain);
    }

    // Update is called once per frame
    public void Update()
    {
        if (isOnTransition)
            updateCameraTransition();
        else if (isOnMain && cameraMain.GetComponent<Camera>().targetDisplay != 0)
        {
            cameraMain.targetDisplay = 0;
            gameObject.GetComponent<Camera>().targetDisplay = 2;
        }
        else if (isOnTarget && cameraCity.GetComponent<Camera>().targetDisplay != 0)
        {
            cameraCity.targetDisplay = 0;
            gameObject.GetComponent<Camera>().targetDisplay = 2;
        }
    }

    private void ActiveTansitionMainToTarget()
    {
        if (isOnMain)
        {
            cameraMain.targetDisplay = 1;
            gameObject.GetComponent<Camera>().targetDisplay = 0;
            startCameraTransitionMainToTarget();
            isOnMain = false;
            isOnTarget = true;
        }
            
    }

    private void ActiveTansitionTargetToMain()
    {
        if(isOnTarget)
        {
            cameraCity.targetDisplay = 1;
            gameObject.GetComponent<Camera>().targetDisplay = 0;
            startCameraTransitionTargetToMain();
            isOnMain = true;
            isOnTarget = false;
        }

    }

    private void startCameraTransitionTargetToMain()
    {
        cameraTarget = cameraMain;
        startTime = Time.time;
        startTransform = cameraCity.transform;
        targetTransform = cameraMain.transform;
        startSizeAttribute = cameraCity.orthographicSize;
        targetSizeAttribute = cameraMain.orthographicSize;
        isOnTransition = true;
    }

    private void startCameraTransitionMainToTarget()
    {
        cameraTarget = cameraCity;
        startTime = Time.time;
        startTransform = cameraMain.transform;
        targetTransform = cameraCity.transform;
        startSizeAttribute = cameraMain.orthographicSize;
        targetSizeAttribute = cameraCity.orthographicSize;
        isOnTransition = true;
    }

    private void updateCameraTransition()
    {
        if (Time.time < startTime + animationTime)
        {
            targetTransform = cameraTarget.transform;
            float i = (Time.time - startTime)/ animationTime;
            gameObject.transform.position = Vector3.Lerp(startTransform.position, targetTransform.position, i);
            gameObject.transform.rotation = Quaternion.Lerp(startTransform.rotation, targetTransform.rotation, i);
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(startSizeAttribute, targetSizeAttribute, i);
        }
        else
        {
            isOnTransition = false;
        }

    }


    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}

		
