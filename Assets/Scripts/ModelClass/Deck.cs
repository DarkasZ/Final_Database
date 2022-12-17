using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    protected int player_id;
    protected int character_id;
    protected int level;
    protected int hp;
    protected int atk;
    protected int def;

    public Deck( int player_id, int character_id, int level, int hp, int atk, int def)
    {
        this.player_id = player_id;
        this.character_id = character_id;
        this.level = level;
        this.hp = hp;
        this.atk = atk;
        this.def = def;
    }
    public int getPlayer_ID()
    {
        return this.player_id;
    }
    public int getCharacter_ID()
    {
        return this.character_id;
    }
    public int getLevel()
    {
        return this.level;
    }
     public int getHp()
    {
        return this.hp;
    }
     public int getAtk()
    {
        return this.atk;
    }
     public int getDef()
    {
        return this.def;
    }

}
