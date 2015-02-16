using UnityEngine;
using System.Collections;

// Gets all single sprites from folder Resources/myPath/  into array sprites
public class SpriteChanger : MonoBehaviour {

	public Sprite[] sprites;
	private SpriteRenderer spriteRenderer;
	public int index = 0;

	void Awake(){

		string myPath = "MajorArcana";
		 
		sprites = Resources.LoadAll<Sprite>(myPath);
		//Debug.Log (sprites.Length);
		//Debug.Log (myPath);
	
	}

	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;

	}

	public static void PrintValues( IEnumerable myList )  {
		foreach ( Object obj in myList )
			Debug.Log( "   {0}", obj );

	}

	public void RandomizeIndex(){
		index =  Random.Range(0, sprites.Length);
		
		spriteRenderer.sprite = sprites [index];
	}

	public void IncrementIndex(int value){
		index = index + value;
	
		spriteRenderer.sprite = sprites [index];
	}

	// Update is called once per frame
	void Update () {
		spriteRenderer.sprite = sprites[index];

	}
}
