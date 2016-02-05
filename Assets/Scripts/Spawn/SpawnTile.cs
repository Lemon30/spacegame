using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnTile : MonoBehaviour {

	public GameObject tilePrefab;
	public Sprite[] tileSprites;
	TextMesh textObject;

	public void CreateTile(Tile createTile){
		int tileType = createTile.tileInfo.type;
		//int tileType = 0; // REMOVE THIS AFTER STAR TYPES ARE ADDED TO DB FOR DIFFERENT ICONS
		Sprite tileSprite = tileSprites[tileType];

		string tileId = createTile.tileInfo.id;
		//string starInfo = createStar.info;
		//string starInfo = "Tita"; // REMOVE THIS AFTER STAR TYPES ARE ADDED TO DB FOR DIFFERENT ICONS

		int starX = -10 + System.Int32.Parse( createTile.tileInfo.id) * 2;
		//int starY = System.Int32.Parse( createTile.id ) * 1;
		int starY = 0;

		GameObject newTile = (GameObject)Instantiate (tilePrefab, new Vector3 (starX, starY, 0), Quaternion.identity);

		newTile.name = "tile" + tileId;
        //newStar.GetComponent<Starx>().starName = starName; //Obsolete

        newTile.GetComponent<Tile>().tileInfo = createTile.tileInfo;
        newTile.GetComponent<SpriteRenderer> ().sprite = tileSprite;
		newTile.GetComponent<BoxCollider>().size = tileSprite.bounds.size;

		textObject = newTile.GetComponentInChildren<TextMesh> ();
		textObject.text = newTile.name + "\n";

		if (createTile.tileInfo.building != null) {
			textObject.text += createTile.tileInfo.building.name + "," + createTile.tileInfo.building.level;
		}
		textObject.color = Color.cyan;
	}

	void Start(){
        foreach ( Tile t in GameMaster.gameMaster.myTiles ){
            Tile tile = gameObject.AddComponent<Tile>();
            tile.tileInfo = t.tileInfo;
			CreateTile (tile);
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

			Tile tile = hitTransform.GetComponent<Tile> ();
		
			GameMaster.gameMaster.selectedTile = tile;

			if (GameMaster.gameMaster.selectedTile.tileInfo.building == null) {
				GameObject menu = GameObject.FindGameObjectWithTag ("BuildingPanel");
				menu.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			} else {
				GameObject menu = GameObject.FindGameObjectWithTag ("DestroyButton");
				menu.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 50);

			}
		}
	}

}
