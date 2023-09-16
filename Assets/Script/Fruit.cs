using UnityEngine;
using System.Collections;

namespace ClassFruit
{
    public class Fruit
    {
        public Color color;
        public string fruitType;

        //This is the first constructor for the Fruit class
        //and is not inherited by any derived classes.
        public Fruit()
        {
            color = Color.blue;
            Debug.Log("1st Fruit Constructor Called");
        }

        //This is the second constructor for the Fruit class
        //and is not inherited by any derived classes.
        public Fruit(string fruitType, Color newColor)
        {
            this.fruitType = fruitType;
            color = newColor;
            Debug.Log("2nd Fruit Constructor Called");
        }
        public void CheckColor()
        {
            if (!string.IsNullOrEmpty(fruitType))
            {
                Debug.Log($"{fruitType}, {color.ToString()}");
            }
            else
            {
                Debug.Log($"Unknown fruit, {color.ToString()}");
            }
        }

        public void Chop()
        {
            Debug.Log("The " + color.ToString() + " fruit has been chopped.");
        }

        public void SayHello()
        {
            Debug.Log("Hello, I am a fruit.");
        }
    }
}