using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceService
{
    public IReadOnlyList<Item> Items;

    [SerializeField] private List<Item> _items;
}