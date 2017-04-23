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
	public GameObject prefab;
	public Sprite spriteDarkZero;
	public Sprite spriteDarkOne ;
	public Sprite spriteDarkTwo ;
	public Sprite spriteDarkBalc ;
	public Sprite spriteDarkPlant ;
	public Sprite spriteLightZero ;
	public Sprite spriteLightOne ;
	public Sprite spriteLightTwo ;
	public Sprite spriteLightBalc ;
	public Sprite spriteLightPlant ;

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
		newLvlPos[0].x = -0.21f ;
		newLvlPos[0].y = -0.08f ;
		newLvlPos[1].x = -0.16f ;
		newLvlPos[1].y = -0.07f ;
		newLvlPos[2].x = -0.08f ;
		newLvlPos[2].y = -0.06f ;
		newLvlPos[3].x = 0.08f ;
		newLvlPos[3].y = -0.06f ;
		newLvlPos[4].x = 0.16f ;
		newLvlPos[4].y = -0.07f ;
		newLvlPos[5].x = 0.21f ;
		newLvlPos[5].y = -0.08f ;
		darkSprites = new List<Sprite>{spriteDarkZero,spriteDarkOne,spriteDarkTwo,spriteDarkBalc,spriteDarkPlant};
		lightSprites = new List<Sprite>{spriteLightZero,spriteLightOne,spriteLightTwo,spriteLightBalc,spriteLightPlant};
	}
	
	// Update is called once per frame
	public void Update()
    {
		City city = gameObject.GetComponent<City>();
		Transform parentPlace = gameObject.GetComponent<Transform>();
		if ((city.A_population/100)> (existingLvls[0]+existingLvls[1]+existingLvls[2]+existingLvls[3]+existingLvls[4]+existingLvls[5]))
		{
			dice = Random.Range(0,30);
			GameObject newLvl = Instantiate(prefab,parentPlace,false);
			Transform newLvlTr = newLvl.GetComponent<Transform>();
			SpriteRenderer newLvlR = newLvl.GetComponent<SpriteRenderer>();
			newLvlTr.Translate(newLvlPos[(dice)%6]);
			if (( 1 == ((dice)%6)) || (((dice)%6) == 4))
			{
				newLvlR.sprite = lightSprites[(dice)%5];
			}
			else
			{
				newLvlR.sprite = darkSprites[(dice)%5];
			}
			if (( 0 == ((dice)%6)) || (((dice)%6) == 5))
			{
				newLvlR.sortingOrder = 1;
			}
			newLvlPos[(dice)%6].y += 0.03f ;
			existingLvls[(dice)%6] += 1;
			
		}
	}
	
    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

}
