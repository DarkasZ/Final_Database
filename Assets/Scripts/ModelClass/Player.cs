using System.Collections;
using System.Collections.Generic;


public class Player
{
    protected int id;
    protected string username;
    protected int silver_coin;
    protected int gold_coin;
    protected int diamond;
    
    public int Silver_coin { get => silver_coin; set => silver_coin = value; }
    public int Diamond { get => diamond; set => diamond = value; }
    public string Username { get => username; set => username = value; }
    public int Gold_coin { get => gold_coin; set => gold_coin = value; }
    public int Id { get => id; set => id = value; }

    public Player(int id, string username, int silver_coin, int gold_coin, int diamond)
    {
        this.Id = id;
        this.Username = username;
        this.Silver_coin = silver_coin;
        this.Gold_coin = gold_coin;
        this.Diamond = diamond;
    }

    public int getPlayerID()
    {
        return this.Id;
    }
    public string getUsername()
    {
        return this.Username;
    }

    public void setGold( int gold)
    {
        this.Gold_coin = gold;
    }
    public int getSilver()
    {
        return this.Silver_coin;
    }
    public int getGold()
    {
        return this.Gold_coin;
    }
    public int getDiamond()
    {
        return this.Diamond;
    }

}