using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnStar : MonoBehaviour {

	public GameObject starPrefab;
	public Sprite[] starSprites;
	TextMesh textObject;
	public SpawnSolarSystem spawnSolarSystem;

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

		newStar.GetComponent<BoxCollider>().size = starSprite.bounds.size / 2;  //For some reason, this doesn't take scale into account
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

	void Update(){
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			if (!Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit))
				return;
			BoxCollider col = hit.collider as BoxCollider;
			if (col == null)
				return;
			Transform hitTransform = hit.collider.transform;
			Debug.Log (hitTransform.name);
			//Application.LoadLevel ("Overview"); //Change to solar system,

			//GameMaster.gameMaster.selectedStar = hitTransform.GetComponentInParent<Star>(); Cant do nothin

		}
	}
}