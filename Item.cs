using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item  
{
    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug { get; set; }
    public string Description { get; set; }
    public string ActionName { get; set; }
    public string ItemName { get; set; }
    public bool ItemModifier { get; set; }


    public Item(List<BaseStat> _Stats, string _ObejectSlug)
    {
        this.Stats = _Stats;
        this.ObjectSlug = _ObejectSlug;
    }

    public Item(List<BaseStat> _Stats, string _ObejectSlug, string _Description, string _ActionName, string _ItemName, bool _ItemModifier)
    {
        this.Stats = _Stats;
        this.ObjectSlug = _ObejectSlug;
        this.Description = _Description;
        this.ActionName = _ActionName;
        this.ItemName = _ItemName;
        this.ItemModifier = _ItemModifier;
    }
}
