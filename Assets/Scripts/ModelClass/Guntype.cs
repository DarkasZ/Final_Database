using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guntype
{
    protected int guntype_id;
    protected string name;
    protected int reload;

    public Guntype(int guntype_id, string name, int reload)
    {
        this.guntype_id = guntype_id;
        this.name = name;
        this.reload = reload;
    }
    public int getGuntype_ID()
    {
        return this.guntype_id;
    }    
    public string getGunName()
    {
        return this.name;
    }    
    public int getReload()
    {
        return this.reload;
    }
}
