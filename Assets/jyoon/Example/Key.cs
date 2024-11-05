using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class Key : Item
    {
        public Inventory target;
        public bool active = false;
        void Update()
        {
            if (active)
            {
                active = false;
                target.아이템넣기(Excute);
            }
        }

        public override void Excute()
        {
            Debug.Log("key 구독 시작!");
        }
    }
}