using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceData {
    [SerializeField]
    private int _value, _max;
    public int Value { get => _value; private set => _value = value; }
    public int Max { get => _max; private set => _max = value; }

    private void Check() {
        if (Value < 0)
            Value = 0;
        else if (Value > Max)
            Value = Max;
    }

    public delegate void ChangedAction(ResourceData source, int oldAmount);
    public event ChangedAction Changed;
    private void Change(int amount) {
        int oldValue = Value;
        Value += amount;
        Changed?.Invoke(this, oldValue);
    }

    public delegate void AddedAction(ResourceData source, int addedAmount);
    public event AddedAction Added;
    public void Add(int amount) {
        Change(amount);
        Added?.Invoke(this, amount);
        Check();
    }

    public delegate void RemovedAction(ResourceData source, int removedAmount);
    public event RemovedAction Removed;
    public void Remove(int amount) {
        Change(-amount);
        Removed?.Invoke(this, amount);
        Check();
    }

    public bool Use(int amount) {
        if (amount > Value)
            return false;
        Remove(amount);
        return true;
    }

    public delegate void IncreasedMaxAction(ResourceData source, int addedAmount);
    public event IncreasedMaxAction IncreasedMax;
    public void IncreaseMax(int amount) {
        Max += amount;
        IncreasedMax?.Invoke(this, amount);
        Check();
    }
}
