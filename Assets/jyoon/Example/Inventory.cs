using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class Inventory : MonoBehaviour
    {
        public Slot prefab;
        public Transform parent;

        public List<Slot> slots = new List<Slot>();


        void Start()
        {
            for (int i = 0; i < 4; i++) 
            {
                slots.Add(Instantiate(prefab, parent));
            }            
        }

        public void �����۳ֱ�(Action act)
        {
            slots[0].useItem = act;
            slots[0].isFull = true;
        }
        public void �����׻���(Action act)
        {

        }
    }
}
