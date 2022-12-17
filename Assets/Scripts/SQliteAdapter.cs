using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Data; 
using Mono.Data.Sqlite; 

using System;

public class SQliteAdapter
{
    public string DBFileName;
    public string DBFolder;

    private IDbConnection   dbcon;
    private IDbCommand      dbcommd;

    public SQliteAdapter(string DBFileName, string DBFolder)
    {
        this.DBFileName = DBFileName;
        this.DBFolder   = DBFolder;
    }

    public void connectDatabase()
    {
    string connectionString = "URI=file:"+ Application.dataPath +"/"+ this.DBFolder +"/"+ this.DBFileName;

    this.dbcon   = new SqliteConnection(connectionString);
    this.dbcon.Open();


    this.dbcommd = this.dbcon.CreateCommand();
    
    }

    public void disconnectDatabase()
    {
        // Close Command
        this.dbcommd.Dispose();

        // Close Database Connection
        this.dbcon.Close();
        this.dbcon.Dispose();

    }

    public IDataReader query(string sql)
    {
        IDataReader reader;
        try{
                connectDatabase();
                this.dbcommd.CommandText = sql ;
                reader = this.dbcommd.ExecuteReader();

        }catch(Exception excp){
            Debug.Log(excp);
            reader = null;
        }
        return reader;
    }

    public IDataReader select(string table = "", string columes = "*")
    {
        string sql = "SELECT " + columes + " FROM " + table;
        return query(sql);
    }

    public IDataReader insertDeck(int player_id, int card_id, int level, int hp, int atk, int def )
    {
        string sql = "INSERT INTO deck (player_id, card_id, level, hp, atk, def) VALUES (" + player_id +"," + card_id +"," + level +","+ hp +"," + atk + ","+ def + ")";
        return query(sql);
    }

    public IDataReader insertItem(int item_id, string name)
    {
        string sql = "INSERT INTO item (item_id,name) VALUES (" + item_id + ",'" + name + "')";
        return query(sql);
    }
    public IDataReader insertInvenItem(int player_id, int item_id, int amount) //from mail to inven
    {
        string sql = "INSERT INTO inventory (player_id,item_id,amount) VALUES ("+player_id+"," + item_id + "," + amount + ")";
        return query(sql);
    }
    public IDataReader insertItemfromShop(int player_id, int item_id, int amount) //from shop to inven
    {
        string sql = "INSERT INTO inventory ( player_id, item_id, amount) VALUES (" + player_id + "," + item_id + "," + amount + ")";
        return query(sql);
    }


    public IDataReader updatePlayerSilver(int silver)
    {
        string sql = "UPDATE players SET silver_coin = " + silver + " WHERE player_id = 1";
        return query(sql);
    }
    public IDataReader updatePlayerGold(int gold)
    {
        string sql = "UPDATE players SET gold_coin = " + gold + " WHERE player_id = 1";
        return query(sql);
    }
    public IDataReader updatePlayerDiamond(int diamond)
    {
        string sql = "UPDATE players SET diamond = " + diamond + " WHERE player_id = 1";
        return query(sql);
    }
    public IDataReader updateLootboxamount(int amount)
    {
        string sql = "UPDATE inventory SET amount = " + amount + " WHERE player_id = 1, item_id = 1";
        return query(sql);
    }
    public IDataReader updateLootboxflasdriveamount(int amount)
    {
        string sql = "UPDATE inventory SET amount = " + amount + " WHERE player_id = 1, item_id = 2";
        return query(sql);
    }

    

    


}
