using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail 
{
    protected int mail_id;
    protected int player_id;
    protected string title;
    protected string reward;
    protected int item_id;

    public Mail(int mail_id, int player_id, string title, string reward, int item_id)
    {
        this.mail_id = mail_id;
        this.player_id = player_id;
        this.title = title;
        this.reward = reward;
        this.item_id = item_id;
    }
    public int getMail_ID()
    {
        return this.mail_id;
    }
    public int getPlayer_ID()
    {
        return this.player_id;
    }
    public string getTitle()
    {
        return this.title;
    }
    public string getReward()
    {
        return this.reward;
    }
    public int getItem_ID()
    {
        return this.item_id;
    }
}
