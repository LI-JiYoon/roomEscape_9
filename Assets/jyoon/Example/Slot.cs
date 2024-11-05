using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class Slot : MonoBehaviour
    {
        public Action useItem;

        public bool isFull = false;
        public string itemID = "";

        public void UseItem()
        {
            useItem();
        }
    }
}
