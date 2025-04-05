using UnityEngine;

public class Table : WorkPlace
{
    [field: SerializeField] public int Number { get; private set; }
    [field: SerializeField] public int MaxGuest { get; private set; }
    [field: SerializeField] public int SittingGuest { get; private set; }
}