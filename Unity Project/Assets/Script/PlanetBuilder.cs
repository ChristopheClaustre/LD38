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
    private string m_filenameDictionary = "cities.txt";
    [SerializeField]
    private GameObject m_cityPrefab;
    [SerializeField, Range(0, 15)]
    private int m_tileNumber = 15;
    [SerializeField, Range(0, 5)]
    private int m_cityNumber = 2;
    [SerializeField, Range(1, 5)]
    private int m_reliefNumber = 2;

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

    [SerializeField]
    private List<string> m_citiesDictionary;

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        if (m_cityNumber + m_reliefNumber > m_tileNumber)
        {
            Debug.LogError("Error in planet building configuration : too much city and relief");
        }

        // retrieve the cities names
        fillDictionary();

        // create all the cities
        int l_cityToAdd = m_cityNumber;
        int l_reliefToAdd = m_reliefNumber;

        List<GameObject> l_cities = new List<GameObject>();
        for (int i = m_tileNumber; i > 0; --i)
        {
            GameObject l_go = Instantiate(m_cityPrefab, transform);
            l_cities.Add(l_go);
            l_go.GetComponentInChildren<City>().m_name = 
                m_citiesDictionary[Random.Range(0, m_citiesDictionary.Count)];

            if (l_cityToAdd > 0)
            {
                l_cityToAdd--;
                l_go.GetComponentInChildren<City>().becomeSomethingAwesome(City.e_City.eCity);
            }
            else if (l_reliefToAdd > 0)
            {
                l_reliefToAdd--;
                l_go.GetComponentInChildren<City>().becomeSomethingAwesome(City.e_City.eRelief);
            }
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

    private void fillDictionary()
    {
        StreamReader l_sr = new StreamReader(Application.dataPath + "/" + m_filenameDictionary);
        string fileContents = l_sr.ReadToEnd();
        l_sr.Close();

        m_citiesDictionary = fileContents.Split('\n').ToList();
    }
}