using System;
using UnityEngine;

public class Table : WorkPlace
{
    [field: SerializeField] private  int _number;
    [field: SerializeField] private  int _maxGuest = 2;
    [field: SerializeField] private  int _sittingGuest;

    [SerializeField] private GameObject _chairOne;
    [SerializeField] private GameObject _chairTwo;
    [SerializeField] private GameObject _chairForSittingOne;
    [SerializeField] private GameObject _chairForSittingTwo;

    public void Sit()
    {
        if(_sittingGuest + 1 > _maxGuest)
            return;
        _chairOne.SetActive(false);
        _chairForSittingOne.SetActive(true);
        _sittingGuest++;

        if(_sittingGuest >= _maxGuest)
            return;
        _chairTwo.SetActive(false);
        _chairForSittingTwo.SetActive(true);
    }

    public bool CanSit()
        => _sittingGuest < _maxGuest;

    /*
    public void Sit()
    {
        _chairOne.SetActive(false);
        _chairTwo.SetActive(false);
        _chairForSittingOne.SetActive(true);
        _chairForSittingTwo.SetActive(true);
    }
    */

    public void StandUp()
    {
        _chairOne.SetActive(true);
        _chairTwo.SetActive(true);
        _chairForSittingOne.SetActive(false);
        _chairForSittingTwo.SetActive(false);
        _sittingGuest = 0;
    }
}