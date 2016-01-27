using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnTile : MonoBehaviour {

	public GameObject tilePrefab;
	public Sprite[] tileSprites;
	TextMesh textObject;

	public void CreateTile(Tile createTile){
		int tileType = createTile.type;
		Debug.Log (tileType);
		//int tileType = 0; // REMOVE THIS AFTER STAR TYPES ARE ADDED TO DB FOR DIFFERENT ICONS
		Sprite tileSprite = tileSprites[tileType];

		string tileId = createTile.id;
		//string starInfo = createStar.info;
		//string starInfo = "Tita"; // REMOVE THIS AFTER STAR TYPES ARE ADDED TO DB FOR DIFFERENT ICONS

		int starX = -10 + System.Int32.Parse( createTile.id ) * 2;
		//int starY = System.Int32.Parse( createTile.id ) * 1;
		int starY = 0;

		GameObject newTile = (GameObject)Instantiate (tilePrefab, new Vector3 (starX, starY, 0), Quaternion.identity);

		newTile.name = "tile" + tileId;
		//newStar.GetComponent<Starx>().starName = starName; //Obsolete
		newTile.GetComponent<SpriteRenderer> ().sprite = tileSprite;

		newTile.GetComponent<BoxCollider>().size = tileSprite.bounds.size;
		textObject = newTile.GetComponentInChildren<TextMesh> ();
		textObject.text = newTile.name + "\n";
		if (createTile.building != null) {
			textObject.text += createTile.building.name + "," + createTile.building.level;
		}
		textObject.color = Color.cyan;
	}

	void Start(){
		foreach( Tile tile in GameMaster.gameMaster.myTiles ){
			CreateTile (tile);
			Debug.Log ("Created tita");
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
			// Open buildingMenu!!!!
			// If there is a building menu, open the related menu
			// Else open the building selection menu
		}
	}

}
