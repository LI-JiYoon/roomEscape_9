using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Key : InteractableObject
    {
        Player player;



        public override string GetInteractPrompt()
        {
            return "[E] 획득";
        }

        
        public override void OnInteract()
        {
           
           
        }
    }
}