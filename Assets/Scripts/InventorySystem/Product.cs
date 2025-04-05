using UnityEngine;

[CreateAssetMenu(menuName = "Game/Inventory/Product", fileName = "Product", order = 2)]
public class Product : Item, ICost, INeedLevel
{
    [field: SerializeField] public float TimeCooking { get; private set; }
    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public Item[] CraftingItems { get; private set; }
    [field: SerializeField] public int LevelNeeded { get; private set; }
}