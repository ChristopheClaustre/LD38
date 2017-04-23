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
    private GameObject startTransform;
    private GameObject targetTransform;
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
        startTransform = new GameObject();
        targetTransform = new GameObject();
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


    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    private void ActiveTansitionMainToTarget()
    {
        if (isOnMain && !isOnTransition)
        {
            cameraMain.targetDisplay = 1;
            gameObject.GetComponent<Camera>().targetDisplay = 0;
            startCameraTransitionMainToTarget();
            isOnMain = false;
            isOnTarget = true;
        }
        //Only append when player click again
        else if (isOnTarget)
        {
            isOnTransition = false;
        }
    }

    private void ActiveTansitionTargetToMain()
    {
        if (isOnTarget && !isOnTransition)
        {
            cameraCity.targetDisplay = 1;
            gameObject.GetComponent<Camera>().targetDisplay = 0;
            startCameraTransitionTargetToMain();
            isOnMain = true;
            isOnTarget = false;
        }
        //Only append when player click again
        else if (isOnMain)
        {
            isOnTransition = false;
        }
    }

    private void startCameraTransitionTargetToMain()
    {
        cameraTarget = cameraMain;
        startTime = Time.time;
        startTransform.transform.position = cameraCity.transform.position;
        startTransform.transform.rotation = cameraCity.transform.rotation;
        startTransform.transform.localScale = cameraCity.transform.localScale;

        targetTransform.transform.position = cameraMain.transform.position;
        targetTransform.transform.rotation = cameraMain.transform.rotation;
        targetTransform.transform.localScale = cameraMain.transform.localScale;
        
        startSizeAttribute = cameraCity.orthographicSize;
        targetSizeAttribute = cameraMain.orthographicSize;
        isOnTransition = true;
    }

    private void startCameraTransitionMainToTarget()
    {
        cameraTarget = cameraCity;
        startTime = Time.time;
        
        startTransform.transform.position = cameraMain.transform.position;
        startTransform.transform.rotation = cameraMain.transform.rotation;
        startTransform.transform.localScale = cameraMain.transform.localScale;

        targetTransform.transform.position = cameraCity.transform.position;
        targetTransform.transform.rotation = cameraCity.transform.rotation;
        targetTransform.transform.localScale = cameraCity.transform.localScale;

        Vector3 temp = targetTransform.transform.rotation.eulerAngles;
        temp.z += (((animationTime / Planet.A_instance.A_timeUnit) * 360.0f)) % 360.0f ;
        targetTransform.transform.rotation = Quaternion.Euler(temp);

        startSizeAttribute = cameraMain.orthographicSize;
        targetSizeAttribute = cameraCity.orthographicSize;
        isOnTransition = true;
    }

    private void updateCameraTransition()
    {
        if (Time.time < startTime + animationTime)
        {
            targetTransform.transform.position = cameraTarget.transform.position;
            float i = (Time.time - startTime) / animationTime;
            gameObject.transform.position = Vector3.Lerp(startTransform.transform.position, targetTransform.transform.position, i);
            gameObject.transform.rotation = Quaternion.Lerp(startTransform.transform.rotation, targetTransform.transform.rotation, i);
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(startSizeAttribute, targetSizeAttribute, i);
        }
        else
        {
            isOnTransition = false;
        }

    }
}

		
