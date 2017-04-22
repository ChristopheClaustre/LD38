/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/

public class Planet : MonoBehaviour
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

    public List<City> mCities;
    public int mWater;
    public int mCoal;
    public int mEnergy;
    public int mPollution;
    public int mTime;
    public int mTimeUnit;

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    /***************************************************
	 ***  ATTRIBUTES            ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        // get all the cities
        mCities.AddRange(GetComponentsInChildren<City>());
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void updatePollution(double deltaTime)
    {

    }

    public void updateEau(double deltaTime)
    {

    }

    public void updateCharbon(double deltaTime)
    {

    }

    public int getPopulation()
    {
        return 0;
    }

    public float getVitesseRotation()
    {
        return 0;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}
