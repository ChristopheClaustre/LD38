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
    private string m_filenameCitiesDictionary = "cities.txt";
    [SerializeField]
    private string m_filenameMountainsDictionary = "mountains.txt";
    [SerializeField]
    private string m_filenameSeasDictionary = "seas.txt";

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
        StreamReader l_sr = new StreamReader(Application.dataPath + "/" + m_filenameCitiesDictionary);
        string l_cities = l_sr.ReadToEnd();
        l_sr.Close();

        l_sr = new StreamReader(Application.dataPath + "/" + m_filenameMountainsDictionary);
        string l_mountains = l_sr.ReadToEnd();
        l_sr.Close();

        l_sr = new StreamReader(Application.dataPath + "/" + m_filenameSeasDictionary);
        string l_seas = l_sr.ReadToEnd();
        l_sr.Close();

        fillDico(l_cities.Split('\n'), ref m_citiesDictionary);
        fillDico(l_mountains.Split('\n'), ref m_mountainsDictionary);
        fillDico(l_seas.Split('\n'), ref m_seasDictionary);
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