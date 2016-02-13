using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileMenuScript : MonoBehaviour {

	/// <summary>
	/// Bring the menu into the game view.
	/// </summary>
	/// <param name="menuTag">Tag of the panel(menu).</param>
	public void openMenu( string menuTag ){
		int amountOfChildren = this.transform.childCount;
		for (int i = 0; i < amountOfChildren; i++) {
			Transform panel = this.transform.GetChild (i);
			if (panel.gameObject.tag == menuTag) {
				panel.position = new Vector3 (0, 0, 0);
			}
		}
	}

	public void destroyBuilding(){
		string objName = "tile"+ (GameMaster.gameMaster.selectedTile.tileInfo.id);
		GameMaster.gameMaster.selectedTile.tileInfo.building = null;
		GameMaster.gameMaster.UpdateResourceGeneration ();
		GameObject tileObj = GameObject.Find (objName);
		TextMesh textObject = tileObj.GetComponentInChildren<TextMesh> ();
		textObject.text = tileObj.name + "\n";
		GameObject menu = GameObject.FindGameObjectWithTag ("DestroyButton");
		menu.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
		menu = GameObject.FindGameObjectWithTag ("UpgradeButton");
		menu.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
	}

	public void upgradeBuilding(){
		string objName = "tile" + (GameMaster.gameMaster.selectedTile.tileInfo.id);
		GameMaster.gameMaster.selectedTile.tileInfo.building.level++;
		GameMaster.gameMaster.UpdateResourceGeneration ();
		GameObject tileObj = GameObject.Find (objName);
		TextMesh textObject = tileObj.GetComponentInChildren<TextMesh> ();
		textObject.text = tileObj.name + "\n";
		textObject.text += GameMaster.gameMaster.selectedTile.tileInfo.building.name + "," + GameMaster.gameMaster.selectedTile.tileInfo.building.level;
	}
}