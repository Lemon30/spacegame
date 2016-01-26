using UnityEngine;
using System.Collections;

public class SpawnStar : MonoBehaviour {

	public GameObject starPrefab;
	public Sprite[] starSprites;
	public int minDist = 0;
	public int maxDist = 100;
	public int numberOfStars = 1000;
	TextMesh textObject;

	public void MakeRandomStar(){
		int arrayIdx = Random.Range(0, starSprites.Length);
		Sprite starSprite = starSprites[arrayIdx];
		string starName = starSprite.name;

		int starX = Random.Range (minDist, maxDist);
		int starY = Random.Range (minDist, maxDist);	
		GameObject newStar = (GameObject)Instantiate (starPrefab, new Vector3 (starX, starY, 0), Quaternion.identity);

		newStar.name = starName;
		newStar.GetComponent<Starx>().starName = starName;
		newStar.GetComponent<SpriteRenderer> ().sprite = starSprite;

		newStar.GetComponent<BoxCollider2D>().size = starSprite.bounds.size;
		textObject = newStar.GetComponentInChildren<TextMesh> ();
		textObject.text = "\t" + newStar.name;
		textObject.color = Color.cyan;
	}

	void Start(){
		for (int i = 0; i<numberOfStars; i++)
			MakeRandomStar ();
	}
}