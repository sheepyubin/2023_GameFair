using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesDB : MonoBehaviour
{
    private List<EyesRow> preLoadedEyess = new List<EyesRow>();
    private static EyesDB SingetonInstance = null;
    public static EyesDB GetSingleton()
    {
        if (SingetonInstance == null)
            SingetonInstance = new EyesDB();
        return SingetonInstance;
    }
    public class EyesRow
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
    }
    private bool IsExist(int id)
    {
        foreach (EyesRow mr in preLoadedEyess)
        {
            if (mr.ID == id)
            {
                return true;
            }
        }
        return false;
    }
    private EyesRow GetPreLoadedEyes(int id)
    {
        foreach (EyesRow mr in preLoadedEyess)
        {
            if (mr.ID == id)
            {
                return mr;
            }
        }
        return null;
    }
    public List<EyesRow> GetEyes(int id)
    {
        if (IsExist(id))
        {
            List<EyesRow> result = new List<EyesRow>();
            result.Add(GetPreLoadedEyes(id));

            return result;
        }
        else
        {
            SQLiteConnection conn = GetConnection();
            List<EyesRow> result = null;

            try
            {
                SQLiteCommand command = conn.CreateCommand(string.Format(
                        "SELECT ID, Name, Class, Hp, Attack FROM Eyes WHERE ID={0};", id));

                result = command.ExecuteQuery<EyesRow>();
            }
            catch (Exception ee)
            {
                Debug.LogError(ee.Message);
                Debug.LogError(ee.StackTrace);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
    private SQLiteConnection GetConnection()
    {
        string dbPath = Application.streamingAssetsPath + "/Eyes.db";
        SQLiteConnection conn = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        return conn;
    }
}
