using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// change sprite image with arrow keys
public class MajorArcana_ArrowKeys : MonoBehaviour { 
	public Sprite[] sprites;
	public Sprite[] Cups;
	public Sprite[] Pentacles;
	public Sprite[] Swords;
	public Sprite[] Wands;


	private SpriteRenderer spriteRenderer;
	public int index = 1;
	// Movement keys (customizable in Inspector)
	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode rightKey;
	public KeyCode leftKey;
	public KeyCode spaceKey;

	private Text someText;
	private Text fText;
	public GameObject fieldTextObject;


	private string[,] pentacles = new string[14,3] {
		{"Ace of pentacles", "A new business venture, the beginning of prosperity. beginning of happiness or pleasure", "Possible greed or misery. money may not be everything"},
		{"Two of pentacles", "The ability to handle multiple situations, harmony is maintained during change, new projects may be difficult, expect a helpful message", "Difficulty with handling problems, expect a discouraging message"} ,  
		{"Three of pentacles","Reward for skills or abilities. approval, success through effort","Quality in workmanship is neglected, good work is expended due to a preoccupation with money, common place ideals or ambitions"} ,  
		{"Four of pentacles", "Love of power or money, a lack of give-and-take, miserly or ungenerous nature", "Some earthly possessions may be lost, obstacles or delays in business affairs, a spendthrift."} ,  
		{"Five of pentacles", "Loneliness, destitution, loss of possessions, poor health, despair due to spiritual impoverishment", "New employment, revived courage, a new interest"} ,  
		{"Six of pentacles", "Sharing of prosperity, one will soon receive what is rightfully theirs, charity, gifts, philanthropy, three-fold",  "Bribes, unfairness, prosperity is threatened, jealousy, miserliness"} ,  
		{"Seven of pentacles", "Effort and hard work will cause growth, a pause during development, reevaluations",  "Little progress, impatience, anxiety, investments may be unprofitable"} ,  
		{"Eight of pentacles", "Learning a trade or profession, employment is coming soon, skill, handiwork, small money gain", "Skills are not being used properly, a dislike of hard work, ambition is void"} ,  
		{"Nine of pentacles", "Well-being, things in life are enjoyed alone, solitude, a green thumb", "Loss is possible, danger from thieves, caution"} ,  
		{"Ten of pentacles", "Stable family, gain in wealth, property is acquired", "Family misfortune, caution, mind is dull, slothfulness"} , 
		{"Page of pentacles", "Scholar, generosity, kindness, a careful person, learning new ideas/opinions", "Wastefulness, luxury, rebellious, opposing ideas/opinions, bad news"} ,  
		{"Knight of pentacles", "Trustworthy, a heavy and dull outlook, patience, accepting of responsibilities, an animal lover, a nature lover, the coming/going of a matter", "Irresponsible, impatience, timidness, carelessness, a standstill in affairs"} , 
		{"Queen of pentacles", "Intelligence, thoughtfulness, a creative person, talents are used well, melancholy", "Too much dependence, neglected duties, mistrust, suspicion, not a very creative person"} ,  
		{"King of pentacles", "A chief of industry or a banker, a reliable person, a married man, solid, steadiness", "Materialistic, slow to anger, `head is on the ground`, bribes"}};
	
	
	private string[,] wands = new string[14,3] {
		{"Ace of wands", "A creative beginning, a new business venture, a profitable journey, an inheritance, a new career, a birth in the family", "Selfishness may spoil the venture, setbacks for a new enterprise, a journey may be put off, a lack of determination"} , 		
		{"Two of wands", "A kind and generous person, an interest in science, patience, creative ability, courage, good things to come", "Caution is advised against impatience, a possible domination by others"} , 		
		{"Three of wands", "A cooperation in business affairs, trade and commerce, success brought by a good partnership, practical help may come from a successful person", "A tendency to scatter energies, mistakes are made through carelessness, disappointment, caution against pride and arrogance"} , 		
		{"Four of wands", "The beauty of the harvest home, perfected work, prosperity, peace, celebration after labor, end of romance in marriage, happy holidays to come", "Learning to appreciate the little things in life, beauty of nature, peace, harmony"} , 		
		{"Five of wands", "Competition, possibility of a lawsuit or quarrel, obstacles, courage", "Harmony, new opportunities, generosity"} , 		
		{"Six of wands", "Good news, victory, success after labor, helpful friends, leadership during journey", "Rewards are delayed, postponed trip, bad news, an insolent winner, pride in riches/success"} , 		
		{"Seven of wands", "The ability to `hold one's own` against adversaries, stiff competition in business, a fight won, a fight one may have to face soon, victory, energy, courage", "The threat will pass by, don't let others take advantage, caution against indecision, patience"} , 		
		{"Eight of wands", "A Goal is approaching, new ideas, a journey by air, love will find its mark, love of open air, gardens, meadows", "Jealousy, violence, quarrels, domestic disputes, a force of courage or boldness is applied to suddenly"} , 		
		{"Nine of wands", "Preparedness, eventual victory, good health, strength in reserve, tendency to obstinacy", "Unpreparedness, refusal to fight, weakness in character, ill health, bending over adversity"} , 		
		{"Ten of wands", "An oppressive load, pain, all plans or projects ruined, complete failure", "Strength, energy, a desire to ruin the happiness of others, a clever person"} , 		
		{"Page of wands", "Brilliance, courage, beauty, sudden anger or love, great enthusiasm, a messenger", "Superficial, theatrical, unstable, a broken heart, bad news to come"} , 		
		{"Knight of wands", "An impetuous nature, generous friend, a lover, haste, a journey, the coming or going of a matter is of much concern", "Discord, work interrupted, jealousy, narrow-mindedness, suspicion, the journey is delayed"} , 		
		{"Queen of wands", "A woman, fondness of nature or of the home, attraction, command, someone who is well liked or honorable", "Strict, domineering, a jealous and revengeful nature, deceit, infidelity"} , 		
		{"King of wands", "A gentlemen, father, passionate, generous, noble, a good leader", "Severe, unyielding, strict, intolerance, prejudice, quarrels"}};
	
	private string[,] cups = new string[14,3] {
		{"Ace of Cups", "The beginning of love, joy, beauty, or good health" , " Hesitancy to accept the things that come from the heart, love under a selfish grasp, egotism"} , 		
		{"Two of Cups", "A new romance, a well balanced friendship is beginning, harmony, cooperation" , " A loss of balance in a relationship, a violent passion, love turning bad, a misunderstanding"} , 		
		{"Three of Cups", "A good fortune in love, a happy conclusion, unknown talents are discovered, a sensitive and sympathetic person, hospitality" , " Pain, gossip, unknown talents remain hidden, overindulgence"} , 		
		{"Four of Cups", "Reevaluation, a dissatisfaction with success, kindness may come from others" , " New relationships possible, new goals, new ambitions, action"} , 		
		{"Five of Cups", "Sorrow, loss of a loved one, a broken marriage, disillusionment, vain regret" , "Return of hope, new relationships are beginning, return of a loved one, courage is summoned from within"} , 		
		{"Six of Cups", "A gift from a childhood acquaintance, happiness and pleasure brought from the past, good memories, a new friendship, a gift from an admirer, new opportunities" , " Living in the past, outworn friendships, disappointment"} , 		
		{"Seven of Cups", "A long-worked imagination, unable to choose one's direction in life, illusory success" , "A good use of determination, will-power, a definite path will be chosen"} , 		
		{"Eight of Cups", "An abandonment of one's current path in life, disappointment in love, misery and repining without cause, desire to leave on'e success for something higher" , "Search for pleasure, seeking joy or success, a new love interest"} , 		
		{"Nine of Cups", "An assured future, physical well-being, a wish may come true" , "A lack in money, overindulgence, illness, a wish may not come true"} , 		
		{"Ten of Cups", "A happy family life, true friendships, lasting happiness" , "A family quarrel, loss of a friendship, children may turn against their parents, waste"} , 		
		{"Page of Cups", "Gentleness, sweetness, kindness, an interest in poetry or art, news" , "Selfishness, little desire to create, a poor imagination"} , 		
		{"Knight of Cups", "Intelligence, romantic dreamer, the coming or going of an emotional matter" , " rickery, fraud, sensuality, idleness, an untruthful person"} , 		
		{"Queen of Cups", "Imagination out-ways one's common sense, a good wife or loving mother, happiness, gentle, a good natured person" , " An over-active imagination, perverse, pleasure and happiness may turn bitter"} , 		
		{"King of Cups", "A business man, a man of law, kindness, a considerate person, a willingness to take on responsibility, and enjoyment of the arts or sciences" , " A powerful man but a double-dealer, crafty, violent, scandal"}};
	
	private string[,] swords = new string[14,3] {
		{"Ace of swords", "Beginning of a victory, ability to love and hate with ardor, a valiant leader may be born" , 		" Caution when trying to use power to gain an ending, obstacles, tyranny"} , 	
		{"Two of swords", "Well balanced emotions are needed, indecision, trouble ahead, in need of direction" , 		" Release, beware when dealing with the unscrupulous"} , 	
		{"Three of swords", "Affections may experience `stormy weather`, lovers separated, possible civil war" , 		" Disorder, confusion, loss, sorrow due to loss"} , 	
		{"Four of swords", "Rest after strife, retreat, temporary exile, a change back to the `active life`" , 		" Renewed activity, social unrest, labor strikes"} , 	
		{"Five of swords", "Failure, defeat, cowardliness, cruelty, an empty victory" , 		" A lesser chance of loss or defeat, an empty victory, unfairness in dealings"} , 	
		{"Six of swords", "A journey, passage away from sorrow, harmony will prevail" , 		" Journey will be postponed, no way out of present obstacles or difficulties"} , 	
		{"Seven of swords", "An unwise attempt, unreliability, betrayal, insolence, spying, possible failure" , 		" Excessive help is given, good advice, counsel, stolen items are returned"} , 	
		{"Eight of swords", "Restricted action, indecision, censure, temporary illness, weakness, a prisoner" , 		" Relaxation, new beginnings possible, freedom"} , 	
		{"Nine of swords", "Suffering, doubt, desolation, illness, injury, death of a loved one, suspicion, cruelty, misery, loss, dishonesty, pitilessness, slander" , 		" Healing over time, unselfishness, patience, good news of a loved one"} , 	
		{"Ten of swords", "Sudden misfortune, ruin of plans, defeat, failure, pain and tears" , 		" Evil forces are overthrown, courage, some success, better health"} , 	
		{"Page of swords", "Dexterity, grace, diplomacy, understanding, an upsetting message" , 		" A cunning person, an imposture, ill health, unexpected events"} , 	
		{"Knight of swords", "A headlong rush into life, a strong man, bravery, a skillful and clever person, an unexpected coming or going of a matter" , 		" Tyranny, a troublemaker, a crafty and secretive person"} , 	
		{"Queen of swords", "A quick and confident decision, a widow, one who can bear their sorrow" , 		" Cruelty due to keen observations, a sly and deceitful person, narrowmindedness, a gossip"} , 	
		{"King of swords", "A judge, a powerful commander, a firm friendship holder but often overcautious, a wise counselor" , 		" Evil intentions, an obstinate person, decisions or judgments may seem unfair"}};
	
	private string[,] majorArcana = new string[22,3]{
		{"The Fool", "New beginnings, new adventures, new opportunities, unlimited possibilities, pleasure, passion, thoughtlessness, rashness" , "A bad decision, indecision, apathy, hesitation, a faulty choice"}, 		
		{"The Magician", "Originality, creativity, skill, will-power, self confidence, dexterity, sleight of hand" , "Weakness in will, insecurity, delay, no imagination"}, 		
		{"The High Priestess", "Wisdom, knowledge, learning, intuition, purity, virtue, a lack of patience, a teacher" , "Ignorance, lack of understanding, selfishness, shallowness"}, 		
		{"The Empress", "Action, development, accomplishment, mother/sister/wife, evolution" , "Vacillation, inaction, lack on concentration, indecision, anxiety, infidelity"}, 		
		{"The Emperor", "Accomplishment, confidence, wealth, stability, leadership, father/brother/husband, achievement, a capable person" , "Immaturity, indecision, feebleness, petty emotions, lack of strength"}, 		
		{"The Hierophant", "A need to conform, social approval, bonded to the conventions of society" , "Unconventionality, unorthodoxy, an inventor"}, 		
		{"The Lovers", "Love, harmony, trust, honor, the beginning of a romance, optimism, a meaningful relationship/affair" , "Unreliability, separation, frustration in love, fickleness, untrustworthy"}, 		
		{"The Chariot", "Perseverance, a journey, a rushed decision, adversity, turmoil, vengeance" , "Unsuccessful, defeat, failure, last minute loss, vanquishment"}, 		
		{"Strength", "Strength, courage, conviction, energy, determination, action, heroism, virility" , "Weakness, pettiness, sickness, tyranny, lack of faith, abuse of power"}, 		
		{"The Hermit", "Counsel, inner strength, prudence, caution, vigilance, patience, withdrawal, annulment, a loner" , "Imprudence, hastiness, rashness, foolish acts, immaturity"}, 		
		{"The Wheel of Fortune", "Destiny, fortune, a special gain, an unusual loss, end of a problem, unexpected events, advancement, progress" , "Failure, bad luck, interruption, outside influences, bad fate, unexpected events"}, 		
		{"Justice", "Harmony, balance, equality, righteousness, virtue, honor, advice, a considerate person" , "Bias, false accusations, intolerance, unfairness, abuse"}, 		
		{"The Hanged Man", "Suspension, change, reversal, boredom, abandonment, sacrifice, readjustment, improvement, rebirth" , "Unwillingness to make an effort, false prophecy, useless sacrifice"}, 		
		{"Death", "Transformation, making way for the new, unexpected change, loss, failure, illness or death, bad luck" , "Stagnation, immobility, slow changes, a narrow escape, cheating death"}, 		
		{"Temperance", "Moderation, temperance, patience, harmony, fusion, good influence, confidence" , "Discord, conflict, disunion, hostility, frustration, impatience"}, 		
		{"The Devil", "Ravage, weird or strange experience, downfall, unexpected failure, controversy, violence, disaster, an ill-tempered person" , "Divorce, release, handicaps are overcome, enlightenment"}, 		
		{"The Tower", "A sudden change, abandonment of past, ending a friendship, unexpected events, disruption, bankruptcy, downfall, loss of money or security" , "Following old ways, a rut, entrapment, caught in a bad situation, imprisonment"}, 		
		{"The Star", "Hope, faith, inspiration, optimism, insight, spiritual love, pleasure, balance" , "Unfulfilled hopes, disappointment, dreams are crushed, bad luck, imbalance"}, 		
		{"The Moon", "Deception, trickery, disillusionment, error, danger, disgrace, double-dealing" , "Deception is discovered before damage can be done, trifling mistakes, taking advantage of someone"}, 		
		{"The Sun", "Satisfaction, accomplishment, success, love, joy, engagement or a happy marriage" , "Unhappiness, loneliness, canceled plans, broken engagement or marriage, a clouded future, a lack of friends"}, 		
		{"Judgment", "Awakening, renewal, a well lived life, better health, a quickened mind" , "Fear of death, failure, possible loss, ill health"}, 		
		{"The World", "Completion, perfection, recognition, honors, the end result, success, fulfillment, triumph, eternal life" , "Imperfection, lack of vision, disappointment"}};
	
	void Awake(){
		// get all images in Resources/myPath
		string myPath = "MajorArcana";

		sprites = Resources.LoadAll<Sprite>(myPath);	
		Cups = Resources.LoadAll<Sprite>("Cups");
		Pentacles = Resources.LoadAll<Sprite>("Pentacles");
		Swords = Resources.LoadAll<Sprite>("Swords");
		Wands = Resources.LoadAll<Sprite>("Wands");
	}
	
	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
		RandomizeIndex ();
	}

	public void RandomizeIndex(){
		index =  Random.Range(0, sprites.Length);
		spriteRenderer.sprite = sprites [index];
			
	}
	public void MajorMinorArcanaDeal (){
	

		int trump = Random.Range (0, 5);
		string[,] myTrumps = new string[22,3];
		if (trump == 0) {
		sprites= Resources.LoadAll<Sprite>("Cups");	
			myTrumps = cups;
		}
		else if (trump == 1) {
			sprites= Resources.LoadAll<Sprite>("Pentacles");	
			myTrumps = pentacles;
		}
		else if (trump == 2) {
			sprites= Resources.LoadAll<Sprite>("Swords");
			myTrumps =swords;
		}
		else if (trump == 3) {
			sprites = Resources.LoadAll<Sprite>("Wands");
			myTrumps = wands;
		}
		else if (trump == 4) {
			sprites = Resources.LoadAll<Sprite>("MajorArcana");	
			myTrumps = majorArcana;
		}
		index =  Random.Range(0, sprites.Length);

		int posneg = Random.Range (1, 2);
		string myFortune = myTrumps[index,0] +"\n"+ myTrumps[index,posneg];
		spriteRenderer.sprite = sprites [index];

		// get text object of GameObject
		someText = GetComponent<Text>();

		AppendToTextObject (myFortune+ "\n");
		//print (myFortune+ "\n");

	}

	//appends  new text to end of Unity UI text object 
	public void AppendToTextObject(string newText){
		fText = fieldTextObject.GetComponent<Text>();
		fText.text = fText.text + "\n" + newText  ;
	}

	public void IncrementIndex(int value){

		index = index + value;
	
		if(index <0){
			index = sprites.Length-1;
		}
		if(index >= sprites.Length){
			index = 0;
		}

		spriteRenderer.sprite = sprites [index];
	}
	
	// Update is called once per frame
	void Update () {
		spriteRenderer.sprite = sprites[index];
	
			// Check for key presses
			if (Input.GetKeyDown(upKey)) {
			IncrementIndex( 1);
				//	rigidbody2D.velocity = Vector2.up * speed;
			}
			else if (Input.GetKeyDown(downKey)) {
				IncrementIndex(-1 ) ;

				//	rigidbody2D.velocity = -Vector2.up * speed;
			}
			else if (Input.GetKeyDown(rightKey)) {
			IncrementIndex( 1);
				//	rigidbody2D.velocity = Vector2.right * speed;
			}
			else if (Input.GetKeyDown(leftKey)) {
			IncrementIndex( -1);
				//	rigidbody2D.velocity = -Vector2.right * speed;
			}
			else if (Input.GetKeyDown(spaceKey)) {

			// get text object of GameObject and clear the text
			fText = fieldTextObject.GetComponent<Text>();
			fText.text = " "  ;
			//deal the cards
			MajorMinorArcanaDeal();
			//	rigidbody2D.velocity = -Vector2.right * speed;
			}
	
	}
}