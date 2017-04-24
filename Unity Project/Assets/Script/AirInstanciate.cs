/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/
public class AirInstanciate : MonoBehaviour
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
	/********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
	
    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start() {
		
		GameObject planete = GameObject.Find("Planet");
		GameObject atmosphere = GameObject.Find("Atmosphere");
		
		ParticleSystem air = gameObject.GetComponent<ParticleSystem>() ;
		ParticleSystem wind = gameObject.GetComponentInChildren<ParticleSystem>() ;
		
		Transform atmoPlace = atmosphere.GetComponent<Transform>() ;
		Transform planetePlace = planete.GetComponent<Transform>() ;
		
		var airMain = air.main;
		var windMain = wind.main;
		
		airMain.simulationSpace = ParticleSystemSimulationSpace.Custom;
		windMain.simulationSpace = ParticleSystemSimulationSpace.Custom;
		
		airMain.customSimulationSpace = atmoPlace ;
		windMain.customSimulationSpace = planetePlace ;
	}
	
	// Update is called once per frame
	public void Update()
    {
	
	}
	
    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}
