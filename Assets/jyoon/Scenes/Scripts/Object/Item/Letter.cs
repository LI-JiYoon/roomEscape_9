using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class Letter : Item
    {
        public Inventory target;
        public bool active = false;
        void Update()
        {
            if (active)
            {
                active = false;
                target.�����۳ֱ�(Excute);
            }
        }


        public override void Excute()
        {
            Debug.Log("letter ���� ����!");
        }
    }
}
