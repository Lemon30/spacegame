using UnityEngine;
using Couchbase.Lite;
using System;
using System.Collections.Generic;

public class CouchbaseInit : MonoBehaviour {

    private Database _db;
    private Manager _admiral;
    private string _sync_uri;
    private string _db_name;

    public CouchbaseInit(string sync_server, string db_name)
    {

        _sync_uri = sync_server;
        _db_name = db_name;

        _admiral = Manager.SharedInstance;
        _db = _admiral.GetDatabase(_db_name);
        Console.WriteLine("Db Created #Fagotcan");
    }

    public bool AddDocument(string item_name, string item_desc, string coordinates)
    {
        Dictionary<string, object> props = new Dictionary<string, object>()
        {
            { "name", item_name },
            { "description", item_desc },
            { "coordinates", coordinates }
        };

        Document doc = _db.CreateDocument();
        Revision rev = doc.PutProperties(props);

        if (props == doc.Properties)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Document getDocument(string id)
    {
       return _db.GetExistingDocument(id);
    }

    public bool updateDocument(string id, string item_name, string item_desc, string coordinates)
    {
        Dictionary<string, object> updated_props = new Dictionary<string, object>()
        {
            { "name", item_name },
            { "description", item_desc },
            { "coordinates", coordinates }
        };

        Document updated_doc = getDocument(id);
        updated_doc.PutProperties(updated_props);
        Debug.Assert(updated_doc != null);

        if (updated_doc != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool deleteDocument(string id)
    {
        Document to_be_deleted = getDocument(id);
        to_be_deleted.Delete();

        return to_be_deleted.Deleted;
    }

    public void sync_db()
    {

    }
}
