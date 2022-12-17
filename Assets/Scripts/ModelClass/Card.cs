using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 
{
    protected int character_id;
    protected string name;
    protected int guntype_id;
    protected int level;
    protected int hp;
    protected int atk;
    protected int def;
    protected string grade;

    public Card(int character_id, string name, int guntype_id,int level, int hp, int atk, int def, string grade)
    {
        this.character_id = character_id;
        this.name = name;
        this.guntype_id = guntype_id;
        this.level = level;
        this.hp = hp;
        this.atk = atk;
        this.def = def;
        this.grade = grade;
    }

    public int getCharacter_ID()
    {
        return this.character_id;
    }
     public string getName()
    {
        return this.name;
    }
     public int getType_ID()
    {
        return this.guntype_id;
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
     public string getGrade()
    {
        return this.grade;
    }
}
