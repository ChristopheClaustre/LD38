/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/

public class PlanetBuilder :
    MonoBehaviour
{
    /***************************************************
	 ***  UNITY GUI PROPERTY    ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    [SerializeField]
    private GameObject m_cityPrefab;
    [SerializeField, Range(0, 15)]
    private int m_tileNumber = 15;
    [SerializeField, Range(0, 5)]
    private int m_cityNumber = 2;
    [SerializeField, Range(1, 5)]
    private int m_mountainNumber = 1;
    [SerializeField, Range(1, 5)]
    private int m_seaNumber = 1;

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
    public void Start()
    {
        if (m_cityNumber + m_mountainNumber + m_seaNumber > m_tileNumber)
        {
            Debug.LogError("Error in planet building configuration : too much city and relief");
        }

        // create all the cities
        int l_cityToAdd = m_cityNumber;
        int l_mountainToAdd = m_mountainNumber;
        int l_seaToAdd = m_seaNumber;

        List<GameObject> l_cities = new List<GameObject>();
        for (int i = 0; i < m_tileNumber; ++i)
        {
            GameObject l_go = Instantiate(m_cityPrefab, transform);
            l_cities.Add(l_go);

            City.KindCity l_kind = City.KindCity.ePrairie;
            if (l_cityToAdd > 0)
            {
                l_cityToAdd--;
                l_kind = City.KindCity.eCity;
            }
            else if (l_mountainToAdd > 0)
            {
                l_mountainToAdd--;
                l_kind = City.KindCity.eMountain;
            }
            else if (l_seaToAdd > 0)
            {
                l_seaToAdd--;
                l_kind = City.KindCity.eSea;
            }

            l_go.GetComponentInChildren<City>().becomeSomethingAwesome(l_kind);
        }

        // rotate the cities
        l_cities = l_cities.OrderBy(item => Random.value).ToList();
        float l_ratio = 360.0f / m_tileNumber;
        for (int i = 0; i < m_tileNumber; ++i)
        {
            l_cities[i].gameObject.transform.Rotate(new Vector3(0, 0, l_ratio * i));
        }
    }

    // Update is called once per frame
    public void Update()
    {

    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    
}