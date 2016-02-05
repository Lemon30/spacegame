using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnStar : MonoBehaviour {

	public GameObject starPrefab;
	public Sprite[] starSprites;
	TextMesh textObject;

	/// <summary>
	/// Creates an instance of star prefab. Stars will be placed according to the info that has been stored 
	/// in this class. If something will be added upon the stars then it should be hook into the star prefab.
	/// </summary>
	/// <param name="createStar">Star information.</param>
	public void CreateStar(Star createStar){
		// int starType = createStar.type;
		int starType = 0; // REMOVE THIS AFTER STAR TYPES ARE ADDED TO DB FOR DIFFERENT ICONS
		Sprite starSprite = starSprites[starType];

		string starName = createStar.starInfo.name;	
		//string starInfo = createStar.info;
		string starInfo = "Tita"; // REMOVE THIS AFTER STAR TYPES ARE ADDED TO DB FOR DIFFERENT ICONS

		int starX = createStar.starInfo.coordinates [0];
		int starY = createStar.starInfo.coordinates[1];

		GameObject newStar = (GameObject)Instantiate (starPrefab, new Vector3 (starX, starY, 0), Quaternion.identity);
		newStar.name = starName;
		//newStar.GetComponent<Starx>().starName = starName; //Obsolete

		// Attached components unto the prefab.
		newStar.GetComponent<Star>().starInfo = createStar.starInfo;
		newStar.GetComponent<SpriteRenderer> ().sprite = starSprite;
		newStar.GetComponent<BoxCollider>().size = starSprite.bounds.size / 2;  //For some reason, this doesn't take scale into account

		textObject = newStar.GetComponentInChildren<TextMesh> ();
		textObject.text = "\t" + newStar.name +
						"\n\t" + starInfo;
		textObject.color = Color.cyan;
	}

	void Start(){
        var stars_iter = GameMaster.gameMaster.stars.GetEnumerator();
		while (stars_iter.MoveNext ()) {
            Star star = gameObject.AddComponent<Star>();

            var db = GameMaster.gameMaster.database;
            var starID = stars_iter.Current.Id;

            star.GetStar(db, starID);
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
		
			Star star = hitTransform.GetComponent<Star> ();

			var db = GameMaster.gameMaster.database;
			var starId = star.starInfo.Id;

			star.GetStar (db, starId);
			GameMaster.gameMaster.selectedStar = star;

			Debug.Log("Opening: " + GameMaster.gameMaster.selectedStar.starInfo.name + " system.");

			hitTransform.GetComponent<SpawnSolarSystem>().Spawn ();
			Camera.main.transform.position = new Vector3 (-500, 0, -10);
			GameObject backButton = GameObject.FindGameObjectWithTag ("BackButton");
			backButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 30);
		}
	}
}
