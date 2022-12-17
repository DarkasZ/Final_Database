using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
   protected int player_id;
   protected int item_id;
   protected int amount;

   public Inventory(int player_id, int item_id, int amount)
   {
        this.player_id = player_id;
        this.item_id = item_id;
        this.amount = amount;
   }
    public int getPlayer_ID()
    {
        return this.player_id;
    }    
    public int getItem_ID()
    {
        return this.item_id;
    }
    public int getAmount()
    {
        return this.amount;
    }
    public void setAmount(int amount)
    {
        this.amount = amount;
    }
}
