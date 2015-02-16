// c#
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


// Arrays, comma delimited lists, and UI text in UNITY 
//updates UNITY 4.6+ UI button text and text object text

public class UItextUpdater : MonoBehaviour
{
	private Text someText;
	public GameObject fieldTextObject;

	private  Text fText;

	private string[] CharactersArray = {"Hero", "Pirate", "Fairy", "Guards", "HeadlessMan", "Golem", "Old Man", "Faithful Hound", "Strongman", "Messenger", "Lunatic", "Priest", "Invalid", "Minotaur", "Invalid", "Nudist", "Three Witches", "Monkey", "Knight", "Apparition", "Innkeeper", "Little Man", "Wanderer", "Hermit", "Escapist", "Lover", "Magic Cow", "Gravedigger", "Wanderer", "Corpse", "Talking Shrub", "Vistors", "Sniper", "Husband", "Giant", "Birdman", "Necromancer", "Skeleton", "Genius", "Dandy", "Snake", "Hairy Beast", "Sorcerress", "Broken Man", "Giant Cat", "Tart", "Boy", "Convict", "Urchins", "Metal Man", "Freaks", "Doomsayer", "Ringmaster", "Dancing Bear", "Floating Skull", "Parents", "Devil"};



	
	// Example use of Arrays
	void ArrayExamples () {
		List<string> myList = new List<string>(CharactersArray);
		
		// prints depth of the array
		Debug.Log("Array Count: " + myList.Count);
		
		
		// converts array to single comma delimited string 
		string JoinedListed = string.Join(",", myList.ToArray());
		
		Debug.Log ("string.Join(comma,myList.ToArray())" + "\n" + JoinedListed);
		
		
		//iterates over the array and prints each item i 
		for (int i = 0; i < CharactersArray.Length; i++)
		{
			//string s = CharactersArray[i];
			//Debug.Log (i + " " + s);
		}
		
		//prints random item of list
		int  r =  Random.Range(0, myList.Count);
		string rand = myList[r];
		Debug.Log ("Random item from list = " + rand);
	}
	
	// print all items of an Array 
	public void printArrayItems(string[] anArray) {
		
		for (int i = 0; i < anArray.Length; i++)
		{
			string s = anArray[i];
			Debug.Log (s);
		}
		
	}
	
	
	//prints random item of an array
	public void randomItemOfList(string[] anArray) {
		List<string> aList = new List<string> (anArray);
		int  r =  Random.Range(0, aList.Count);
		string rand = aList[r];
		Debug.Log ("Random item from list = " + rand);
		
	}
	
	//appends  new text to end of Unity UI text object 
	public void AppendToTextObject(string newText){
		fText = fieldTextObject.GetComponent<Text>();
		fText.text = fText.text + "\n" + newText  ;
	}
	
	// random label of UI button text object
	public void randomTextToLabel (){
		// get text object of GameObject
		someText = GetComponent<Text>();

		
		// convert array to List?
		List<string> myList = new List<string>(CharactersArray);
		
		// random number from from list count (length)
		int  r =  Random.Range(0, myList.Count);
		
		// random item of list
		string rand = myList[r];
		
		//Debug.Log (rand);
		
		//set the text of the GameObject 
		someText.text = rand;
		
		AppendToTextObject (rand);

	}


}

