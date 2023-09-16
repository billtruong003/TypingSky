using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClassFruit;
using NaughtyAttributes;

public class Inherit : MonoBehaviour
{
    public int ids { get; set; }
    bool eneable = true;
    public bool Enable // Sử dụng thuộc tính Enable thay vì eneable
    {
        get
        {
            eneable = false;
            return eneable;
        }
        set
        {
            eneable = value;
            Debug.Log($"Enabling1: {eneable.ToString()}");
        }
    }
    [Button]
    public void checkID()
    {
        ids = 9; // set
        Debug.Log($"ID: {this.ids}"); // get
    }
    [Button]
    public void vuivui()
    {
        Enable = true;
        Debug.Log($"Enabling2: {this.Enable}");
    }
    public class Apple : Fruit
    {
        public Apple()
        {
            color = Color.green;
        }
        public Apple(Color newColor) : base("Apple", newColor)
        {
            //Notice how this constructor doesn't set the color
            //since the base constructor sets the color that
            //is passed as an argument.
            Debug.Log("2nd Apple Constructor Called");
        }
    }
    Fruit apple = new Fruit("Apple", Color.red);

    [Button]
    public void newFruit()
    {
        apple.CheckColor();
    }
}
