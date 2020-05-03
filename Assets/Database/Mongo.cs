
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;

public class Mongo 
{

    private const string MONGO_URI = "mongodb://OculusVRProject:sbyte@cluster0-shard-00-00-rdvnf.gcp.mongodb.net:27017,cluster0-shard-00-01-rdvnf.gcp.mongodb.net:27017,cluster0-shard-00-02-rdvnf.gcp.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";
    private const string DATABASE_NAME = "SpatterDB";

    private static MongoClient client;
    public static MongoClient Client { get { return client; } }
    

    public void Init()
    {
    
    }

    public static MongoClient getConnection()
    {
        if (client != null)
        {

            client = null;

        }
        else
        {

            Debug.Log("Database has been Initialized");

        }
        client = new MongoClient(MONGO_URI);

        return client;
    }












    public void shutDown()
    {
        client = null;
        
        // server.Shutdown();
        ///db = null;
    }

}
