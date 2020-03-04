using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;

public class MenuController : MonoBehaviour {
    
    
    private string dbPath;

    // Use this for initialization
    void Start () {
        dbPath = "URI=file:" + Application.persistentDataPath +"/exampleDatabase.db";

        if (Application.platform != RuntimePlatform.Android)
        {

            dbPath = Application.persistentDataPath + "/exampleDatabase.db";
        }
        else
        {

            dbPath = Application.persistentDataPath + "/exampleDatabase.db";
            if (!File.Exists(dbPath))
            {
                WWW load = new WWW("jar:file://" + Application.persistentDataPath + "/exampleDatabase.db");
                while (!load.isDone) { }

                File.WriteAllBytes(dbPath, load.bytes);
            }
        }

        
        
        CreateSchema();
        borrarPlanetas();
        insertarPlaneta("Planeta1", 11, 0,1);
        insertarPlaneta("Planeta2", 11, 0,0);
        insertarPlaneta("Planeta3", 11, 0,0);
        insertarPlaneta("Planeta4", 11, 0,0);
        getPlanetas();

        
    }
    public void borrarPlanetas()
    {
        using (IDbConnection conn = new SqliteConnection("URI=file:" + dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from planetas";

                cmd.ExecuteNonQuery();
            }
        }
    }
    
    public void CreateSchema()
    {
        using (IDbConnection conn = new SqliteConnection("URI=file:" + dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS 'planetas' ( " +
                                  "  'id' INTEGER PRIMARY KEY, " +
                                  "  'name' TEXT NOT NULL, " +
                                  "  'niveles' INTEGER NOT NULL," +
                                  "  'niveles_finalizados' INTEGER NOT NULL," +
                                  "  'estado' INTEGER NOT NULL" +
                                  ");";

                cmd.ExecuteNonQuery();
            }
        }
    }
    public void insertarPlaneta(string name, int niveles,int niveles_finalizados,int estado)
    {
        using (IDbConnection conn = new SqliteConnection("URI=file:" + dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO planetas (name, niveles,niveles_finalizados,estado) " +
                                  "VALUES (@Name, @Niveles,@Niveles_finalizados,@Estado);";

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Name",
                    Value = name
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Niveles",
                    Value = niveles
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Niveles_finalizados",
                    Value = niveles_finalizados
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Estado",
                    Value = estado
                });

                cmd.ExecuteNonQuery();
            }
        }
    }
    public void getPlanetas()
    {
        using (IDbConnection conn = new SqliteConnection("URI=file:" + dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM planetas;";

                
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    var name = reader.GetString(1);
                    var estado = reader.GetInt32(4);

                    
                    if (estado==0)
                    {
                        GameObject.FindGameObjectWithTag(name).GetComponent<Image>().sprite = Resources.Load<Sprite>("Planetas/"+name+"Gris");
                        GameObject.FindWithTag(name).GetComponent<Button>().interactable = false;
                    }

                    else
                    {
                        GameObject.FindGameObjectWithTag(name).GetComponent<Image>().sprite = Resources.Load<Sprite>("Planetas/" + name);
                        GameObject.FindWithTag(name).GetComponent<Button>().interactable = true;
                    }
                    
                }
                
            }
        }
    }
    // Update is called once per frame
}