using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop 
{
    protected int item_id;
    protected string name;
    protected int silver_coin;
    protected int gold_coin;
    protected int diamond;

    public Shop(int item_id, string name, int silver_coin, int gold_coin, int diamond)
    {
        this.item_id = item_id;
        this.name = name;
        this.silver_coin = silver_coin;
        this.gold_coin = gold_coin;
        this.diamond = diamond;
    }
    public int getItem_ID()
    {
        return this.item_id;
    }
    public string getItem_Name()
    {
        return this.name;
    }
    public int getSilver()
    {
        return this.silver_coin;
    }
    public int getGold()
    {
        return this.gold_coin;
    }
    public int getDiamond()
    {
        return this.diamond;
    }

}
