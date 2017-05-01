/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/

public class Namer :
    MonoBehaviour
{
    /***************************************************
	 ***  UNITY GUI PROPERTY    ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    [SerializeField]
    private TextAsset m_cities;
    [SerializeField]
    private TextAsset m_mountains;
    [SerializeField]
    private TextAsset m_seas;

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

    [SerializeField]
    private static List<string> m_citiesDictionary;
    [SerializeField]
    private static List<string> m_mountainsDictionary;
    [SerializeField]
    private static List<string> m_seasDictionary;

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start()
    {
        // retrieve the cities names
        fillDictionary();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public static string getName(City.KindCity p_kind)
    {
        switch (p_kind)
        {
            case City.KindCity.ePrairie:
                return "Just a fucking prairie";
            case City.KindCity.eCity:
                return m_citiesDictionary[Random.Range(0, m_citiesDictionary.Count)];
            case City.KindCity.eMountain:
                return m_mountainsDictionary[Random.Range(0, m_mountainsDictionary.Count)];
            case City.KindCity.eSea:
                return m_seasDictionary[Random.Range(0, m_seasDictionary.Count)];
            default:
                return "";
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void fillDictionary()
    {
        fillDico(m_cities.text.Split('\n'), ref m_citiesDictionary);
        fillDico(m_mountains.text.Split('\n'), ref m_mountainsDictionary);
        fillDico(m_seas.text.Split('\n'), ref m_seasDictionary);
    }

    private static void fillDico(string[] l_raw, ref List<string> l_out)
    {
        l_out = new List<string>();

        foreach (var l_line in l_raw)
        {
            if (!l_line.StartsWith("#") && !l_line.StartsWith(" #") && !(l_line == ""))
            {
                l_out.Add(l_line);
            }
        }
    }
}