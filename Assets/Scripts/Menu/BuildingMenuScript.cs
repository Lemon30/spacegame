using UnityEngine;
using System.Collections;

public class BuildingMenuScript : MonoBehaviour {

	public void closeMenu(){
		GameObject menu = GameObject.FindGameObjectWithTag ("BuildingPanel");
		menu.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, -1000);
	}

	public bool checkResources(int t, int m, int l){
		if (GameMaster.gameMaster.titaniumVal >= t &&
		    GameMaster.gameMaster.mineralVal >= m &&
		    GameMaster.gameMaster.luminiteVal >= l)
			return true;
		else
			return false;
	}

	public void build(string newName){
		int buildingTitaniumCost = 999999;
		int buildingMineralCost = 999999;
		int buildingLuminiteCost = 999999;
		string buildingId = "?";
		string buildingName = "?";
		string buildingType = "?";
		switch (newName) {
		case "titaniumMine":
			buildingTitaniumCost = 10;
			buildingMineralCost = 5;
			buildingLuminiteCost = 0;
			buildingId = "0";
			buildingName = "Titanium Mine";
			buildingType = "Mine";
			break;
		case "mineralMine":
			buildingTitaniumCost = 20;
			buildingMineralCost = 10;
			buildingLuminiteCost = 0;
			buildingId = "1";
			buildingName = "Mineral Mine";
			buildingType = "Mine";
			break;
		case "luminiteMine":
			buildingTitaniumCost = 30;
			buildingMineralCost = 15;
			buildingLuminiteCost = 0;
			buildingId = "2";
			buildingName = "Luminite Mine";
			buildingType = "Mine";
			break;
		default:
			Debug.Log ("Invalid building selection. Boo!");
			break;
		}
		if (checkResources (buildingTitaniumCost, buildingMineralCost, buildingLuminiteCost)) {
			GameMaster.gameMaster.titaniumVal -= buildingTitaniumCost;
			GameMaster.gameMaster.mineralVal -= buildingMineralCost;
			GameMaster.gameMaster.luminiteVal -= buildingLuminiteCost;

			TileInfo.BuildingInfo building = new TileInfo.BuildingInfo (buildingId, buildingName, buildingType, 1);

			GameMaster.gameMaster.selectedTile.tileInfo.building = building;

			string objName = "tile"+ (GameMaster.gameMaster.selectedTile.tileInfo.id);
			GameObject tileObj = GameObject.Find (objName);
			TextMesh textObject = tileObj.GetComponentInChildren<TextMesh> ();
			textObject.text = tileObj.name + "\n";
			textObject.text += GameMaster.gameMaster.selectedTile.tileInfo.building.name + "," + GameMaster.gameMaster.selectedTile.tileInfo.building.level;

			GameMaster.gameMaster.UpdateResourceGeneration ();
			closeMenu ();
		} else {
			Debug.Log ("Insufficient resources!");
		}
	}
}
