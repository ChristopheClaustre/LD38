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

	private int[] existingLvls = {0,0,0,0,0,0};
	private Vector3[] newLvlPos = {Vector3.zero,Vector3.zero,Vector3.zero,Vector3.zero,Vector3.zero,Vector3.zero};
	private int dice;
	private List<Sprite> lightSprites;
	private List<Sprite> darkSprites;
	
    /***************************************************
	 ***  METHODS               ************************
	 ***************************************************/

    /********  PUBLIC           ************************/

    // Use this for initialization
    public void Start() {
        newLvlPos[0].x = -0.21f;
        newLvlPos[0].y = -0.08f;
        newLvlPos[1].x = -0.16f;
        newLvlPos[1].y = -0.07f;
        newLvlPos[2].x = -0.08f;
        newLvlPos[2].y = -0.06f;
        newLvlPos[3].x = 0.08f;
        newLvlPos[3].y = -0.06f;
        newLvlPos[4].x = 0.16f;
        newLvlPos[4].y = -0.07f;
        newLvlPos[5].x = 0.21f;
        newLvlPos[5].y = -0.08f;

        darkSprites = new List<Sprite>{m_spriteDarkZero,m_spriteDarkOne,m_spriteDarkTwo,m_spriteDarkBalc,m_spriteDarkPlant};
        lightSprites = new List<Sprite>{m_spriteLightZero,m_spriteLightOne,m_spriteLightTwo,m_spriteLightBalc,m_spriteLightPlant};
	}
	
	// Update is called once per frame
	public void Update()
    {
		City city = gameObject.GetComponent<City>();
		Transform parentPlace = gameObject.GetComponent<Transform>();

        int l_existingCities = existingLvls[0] + existingLvls[1] + existingLvls[2] + existingLvls[3] + existingLvls[4] + existingLvls[5];
        if (city.A_kind == City.e_City.eCity && city.A_population / 100 > l_existingCities)
		{
			dice = Random.Range(0,30);
            int l_idPosition = dice % 6;
            int l_idSprite = dice % 5;

			GameObject newLvl = Instantiate(m_prefab,parentPlace,false);
			Transform newLvlTr = newLvl.GetComponent<Transform>();
			SpriteRenderer newLvlR = newLvl.GetComponent<SpriteRenderer>();

            // set sprite
            if ( 1 == l_idPosition || l_idPosition == 4)
			{
				newLvlR.sprite = lightSprites[l_idSprite];
			}
			else
			{
				newLvlR.sprite = darkSprites[l_idSprite];
			}

            // set sorting order
			if ( 0 == l_idPosition || l_idPosition == 5)
			{
				newLvlR.sortingOrder = 1;
			}

            // translate
            newLvlPos[l_idPosition].x += 0.01f * Mathf.RoundToInt(Random.Range(-1.0f, 1.0f));
            newLvlTr.Translate(newLvlPos[l_idPosition]);
            newLvlPos[l_idPosition].y += 0.03f;

            // update existing buildings
            existingLvls[l_idPosition] += 1;
		}
	}
	
    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}
