using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Planet class, unity compatible version of PlanetInfo class. 
/// It contains planet information gathered from db.
/// </summary>
public class Planet : MonoBehaviour
{
    // Planet information.
    public PlanetInfo planetInfo;

    /// <summary>
    /// Default consructor. Only creates an empty instance of the object.
    /// </summary>
    public Planet() { }

    /// <summary>
    /// After object has been created, it should have initialized
    /// through this method.
    /// </summary>
    /// <param name="planetToken"></param>
    public void GetPlanet(JToken planetToken)
    {
        planetInfo = new PlanetInfo(planetToken);
    }
}

