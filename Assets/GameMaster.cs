using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class GameMaster : MonoBehaviour {
	// Database connection details
	const string db_host = "localhost";
	const int db_port = 5984;
	const string db = "universe";

	// Global GameMaster object for data persistance
	// Don't forget to put the GameMaster prefab in every scene
	public static GameMaster gameMaster;

	// Global home planet and its tiles' data
	public Planet myPlanet;
	public List<Tile> myTiles;


	// Use this for initialization
	void Awake () {
		// Singleton
		if (gameMaster == null) {
			DontDestroyOnLoad (gameObject);
			gameMaster = this;
		} else if (gameMaster != this)
			Destroy (gameObject);
		
		// Establish connection with the database
		var server = new CouchServer (db_host, db_port);
		var database = server.GetDatabase (db);

		// Fetch the home planet details from the database
		// and create a global planet object called myPlanet

		// If some attribute which belongs to a star will be called, 
		// then it is necessary that a Star object to be created.
		// starID should be recognized from beginning and it should be 
		// known that which plaet we are on.
		var starID = "star-1";
		var currentStar = database.GetDocument<Star> (starID);

		// Get planet from current selected star.
		var currentPlanet = currentStar.planets [0];
		// Debug log for testing.
		Debug.Log(currentPlanet.name);
	}
}

/*using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Globals : MonoBehaviour {

	public static Globals gameMaster;

	public float gold;
	public float exp;

	public int selectedTile;

	public class myResources{
		public myResource titanium;
		public myResource mineral;
		public myResource luminite;
		public int hp;
	}

	public class myResource{
		public string name;
		public int value;
	}

	public class myTiles{
		public myBuilding building;

		public myTiles(myBuilding newBuilding){
			building = newBuilding;
		}
	}



	public class myBuilding{
		public string name;
		public int type;
		public int level;

		public myBuilding(string newName, int newType, int newLevel){
			name = newName;
			type = newType;
			level = newLevel;
		}
	}


	public myResources resources;
	myResource newTitanium;
	myResource newMineral;
	myResource newLuminite;
	//public myTiles[] tiles;
	List<myTiles> tiles; 
	public myBuilding[] buildings;




	
	// Use this for initialization
	void Awake () {
		if (gameMaster == null) {
			DontDestroyOnLoad (gameObject);
			gameMaster = this;
		} else if (gameMaster != this)
			Destroy (gameObject);
		
		//////////////////////////////////////////////////////////////////////
		//Create resources
		resources = new myResources();
		//Create each resource
		newTitanium = new myResource();
		newMineral = new myResource();
		newLuminite = new myResource();
		//Assing each resource
		resources.titanium = newTitanium;
		resources.mineral = newMineral;
		resources.luminite = newLuminite;
		//Set each resourcce
		resources.titanium.name = "Titanium";
		resources.mineral.name = "Mineral";
		resources.luminite.name = "Luminite";
		resources.titanium.value = 5;
		resources.mineral.value = 6;
		resources.luminite.value = 7;
		//////////////////////////////////////////////////////////////////////
		//Create tiles
		tiles = new List<myTiles>();
		for (int i = 0; i < 5; i++) {
			myBuilding newBuilding = new myBuilding ("titaBuilding", i, 1);
			myTiles newTile = new myTiles (newBuilding);
			tiles.Add (newTile);
		}
		/// 0 = Titanium Mine
		/// 1 = Mineral Mine
		/// 2 = Luminite Mine
		/// 3 = Titanium Depot
		/// 4 = Mineral Depot
		/// 5 = Luminite Depot


	}

	void OnGUI(){
		GUI.Label(new Rect(10,10,100,30), "Gold: " + gold );
		GUI.Label(new Rect(10,40,100,30), "Exp: " + exp );
		GUI.Label(new Rect(10,70,100,30), resources.titanium.name + ": " + resources.titanium.value );
		GUI.Label(new Rect(10,100,100,30), resources.mineral.name + ": " + resources.mineral.value );
		GUI.Label(new Rect(10,130,100,30), resources.luminite.name + ": " + resources.luminite.value );
		for(int i = 0; i<5;i++)
			GUI.Label(new Rect(10,(160+i*30),100,30), tiles[i].building.name + ": " + tiles[i].building.type + ", " + tiles[i].building.level);
	}
}


/*
	//Tile Global Variables
public struct Tile{
	public Building building;
}

//Building Global Variables
public struct Building{
	public string name;
	public int level;
}


public int selectedPlanetOrder = 0;
public int totalTiles;

public struct Resource{
	public string name;
	public int value;
}

public int totalResources = 3;
public Resource[] resource;
public Planet myPlanet;
*/
/*public Globals(){
//Planet
myPlanet = new Planet();
myPlanet.name = "Tita";
myPlanet.ord = selectedPlanetOrder;

//Resources
resource = new Resource[totalResources];
for (int i = 0; i < totalResources; i++) {
	resource[i].value = 0;
}
resource [0].name = "Titanium";
resource [1].name = "Mineral";
resource [2].name = "Luminite";

//Tiles
myPlanet.tile = new Tile[totalTiles];

//Buildings
}*/
/*
//Fetch correct resource values from database
public void fetchResources(){
	//Insert relevant code here
}	

*/