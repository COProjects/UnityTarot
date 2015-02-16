using UnityEngine;
using System.Collections;

// Gets sprites from sprite sheet set to Multilple Mode

public class SpriteChangerAtlased : MonoBehaviour {
	
	public Sprite[] sprites;
	private SpriteRenderer spriteRenderer;

	public int index = 0;
	
	void Awake(){
		// the path is a folder inside the Resources folder.
		string myPath = "spriteSheet";
		
		sprites = Resources.LoadAll<Sprite>(myPath);

		// iterate over the spritesheet sprite names
		string[] names = new string[sprites.Length];
		for(int ii=1; ii< names.Length; ii++) {
			names[ii] = sprites[ii].name;
		}

		string L = sprites[0].name;
		Debug.Log ("Length of sprite array = "+    names.Length.ToString ());
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
		//RandomizeIndex ();
		//spriteRenderer.sprite = sprites[index];
	}
}
