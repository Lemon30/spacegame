using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnStar : MonoBehaviour {

	public GameObject starPrefab;
	public Sprite[] starSprites;
	TextMesh textObject;

	public void CreateStar(Star createStar){
		// int starType = createStar.type;
		int starType = 0; // REMOVE THIS AFTER STAR TYPES ARE ADDED TO DB FOR DIFFERENT ICONS
		Sprite starSprite = starSprites[starType];

		string starName = createStar.name;
		//string starInfo = createStar.info;
		string starInfo = "Tita"; // REMOVE THIS AFTER STAR TYPES ARE ADDED TO DB FOR DIFFERENT ICONS

		int starX = createStar.coordinates [0];
		int starY = createStar.coordinates [1];

		GameObject newStar = (GameObject)Instantiate (starPrefab, new Vector3 (starX, starY, 0), Quaternion.identity);

		newStar.name = starName;
		//newStar.GetComponent<Starx>().starName = starName; //Obsolete
		newStar.GetComponent<SpriteRenderer> ().sprite = starSprite;

		newStar.GetComponent<BoxCollider2D>().size = starSprite.bounds.size;
		textObject = newStar.GetComponentInChildren<TextMesh> ();
		textObject.text = "\t" + newStar.name +
						"\n\t" + starInfo;
		textObject.color = Color.cyan;
	}

	void Start(){

		IEnumerator<Star> stars_iter = GameMaster.gameMaster.stars.GetEnumerator ();
		while (stars_iter.MoveNext ()) {
			Star star = stars_iter.Current;
			CreateStar (star);
		}

	}
}