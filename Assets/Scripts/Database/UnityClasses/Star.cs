﻿using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Generates Unity3D compatible version of
/// database star objects.
/// </summary>
public class Star : MonoBehaviour {

    // Variables for information gathering from database.
	public StarInfo starInfo;
    public IEnumerable<StarInfo> starDBIter;

    /// <summary>
    /// Default constructor for Star object.
    /// Information data should be initialized before
    /// spawning the object. Defult constructor only 
    /// creates an empty instance of the object.
    /// </summary>
    public Star()
    {
        starInfo = new StarInfo();
    }

    /// <summary>
	/// Initializes a new instance of the <see cref="Star"/> class.
	/// </summary>
	/// <param name="obj">Original Star object.</param>
	public Star(StarInfo obj)
    {
		starInfo = obj;
	}

    /// <summary>
    /// Gathers all star object and return an iterator which
    /// iters thorough the star objects.
    /// </summary>
    /// <param name="dbObject">Database object generated by Divan</param>
    public void GetAllStars(ICouchDatabase dbObject)
    {
        starDBIter = dbObject.GetAllDocuments<StarInfo>();
    }

    /// <summary>
    /// Initializes spawner object using information 
    /// gathered from database.
    /// </summary>
    /// <param name="starID">Document ID of the star.</param>
    public void GetStar(ICouchDatabase dbObject, string starID)
    {
        starInfo = dbObject.GetDocument<StarInfo>(starID);
    }
}
