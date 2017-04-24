/***************************************************
 *** INCLUDE                ************************
 ***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************
 *** THE CLASS              ************************
 ***************************************************/
public class TowerBuilder : MonoBehaviour
{
    /***************************************************
	 ***  UNITY GUI PROPERTY    ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

	public GameObject m_prefab;

	public Sprite m_spriteDarkZero;
	public Sprite m_spriteDarkOne;
	public Sprite m_spriteDarkTwo;
	public Sprite m_spriteDarkBalc;
	public Sprite m_spriteDarkPlant;
	public Sprite m_spriteLightZero;
	public Sprite m_spriteLightOne;
	public Sprite m_spriteLightTwo;
	public Sprite m_spriteLightBalc;
	public Sprite m_spriteLightPlant;

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

	private int[] m_existingLvls = {0,0,0,0,0,0};
	private List<Vector4> m_nextPositionBuildings = new List<Vector4>();
	private List<Sprite> lightSprites;
	private List<Sprite> darkSprites;

    private float m_arcPixelPerUnit;
    private int m_existingCities;

    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start() {
        // sprites lists
        darkSprites = new List<Sprite>{m_spriteDarkZero,m_spriteDarkOne,m_spriteDarkTwo,m_spriteDarkBalc,m_spriteDarkPlant};
        lightSprites = new List<Sprite>{m_spriteLightZero,m_spriteLightOne,m_spriteLightTwo,m_spriteLightBalc,m_spriteLightPlant};

        m_arcPixelPerUnit = 1.0f / m_spriteDarkZero.pixelsPerUnit;
        int l_number = Mathf.RoundToInt(Random.Range(Config.m_limitBuildingsNumber.x, Config.m_limitBuildingsNumber.y));
        float l_distance = Config.m_limitPlacementBuildings.y - Config.m_limitPlacementBuildings.x;
        float l_initial = Config.m_limitPlacementBuildings.x;
        float l_offset = (l_distance / (l_number - 1));

        for(int i = 0; i < l_number; ++i)
        {
            Vector4 l_vector = new Vector4();
            l_vector.x = l_initial + (l_offset * i) + Mathf.RoundToInt(Random.Range(-1.0f, 1.0f));
            l_vector.y = -10 + Mathf.RoundToInt(Random.Range(-1.0f, 1.0f));
            l_vector *= m_arcPixelPerUnit;
            // light or dark & sorting order
            l_vector.z = Mathf.RoundToInt(Random.value);
            // existing buildings
            l_vector.w = 0;

            m_nextPositionBuildings.Add(l_vector);
        }

        m_existingCities = 0;
    }
	
	// Update is called once per frame
	public void Update()
    {
		City city = gameObject.GetComponent<City>();
		Transform parentPlace = gameObject.GetComponent<Transform>();

        if (city.A_kind == City.e_City.eCity && city.A_population / 100 > m_existingCities)
		{
            int l_idPosition = Random.Range(0, m_nextPositionBuildings.Count);
            int l_idSprite = Random.Range(0, System.Math.Min(darkSprites.Count, lightSprites.Count));

			GameObject newLvl = Instantiate(m_prefab,parentPlace,false);
			Transform newLvlTr = newLvl.GetComponent<Transform>();
			SpriteRenderer newLvlR = newLvl.GetComponent<SpriteRenderer>();

            // set sprite
            if (m_nextPositionBuildings[l_idPosition].z == 0)
			{
				newLvlR.sprite = darkSprites[l_idSprite];
			}
			else
			{
				newLvlR.sprite = lightSprites[l_idSprite];
			}

            // set sorting order
            newLvlR.sortingOrder += (int) m_nextPositionBuildings[l_idPosition].z;

            // translate
            newLvlTr.Translate(m_nextPositionBuildings[l_idPosition]);
            updatePosition(l_idPosition);

            m_existingCities++;
        }
	}
	
    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void updatePosition(int p_id)
    {
        Vector4 l_temp = m_nextPositionBuildings[p_id];

        l_temp.x += m_arcPixelPerUnit * Mathf.RoundToInt(Random.Range(-1.0f, 1.0f)); // variation latéral
        l_temp.y += m_arcPixelPerUnit * 3; // + 1 étage
        l_temp.w++; // + 1 étage

        m_nextPositionBuildings[p_id] = l_temp;
    }
}
