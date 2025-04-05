using UnityEngine;

[CreateAssetMenu(menuName = "Game/Inventory/Item", fileName = "Item", order = 0)]
public class Item : ScriptableObject
{
    [field: SerializeField] public string ID { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}