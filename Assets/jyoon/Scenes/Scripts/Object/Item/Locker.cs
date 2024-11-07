using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : InteractableObject
{
    public Transform hidePosition; // 관물함 내부의 위치를 나타냅니다
    public Transform outPosition;

    Player player;

    // 관물함과 상호작용할 때 표시할 프롬프트 텍스트를 가져옵니다
    public override string GetInteractPrompt()
    {
        return "[E] 숨기";
    }

    // 관물함과의 상호작용을 처리합니다
    public override void OnInteract()
    {
        player = CharacterManager.Instance.Player;
        if (player.controller.isHiding == false)
        {   
            //player.controller.isHiding = true;
            Invoke("SetIsHidingTrue", 0.5f);
            player.transform.position = hidePosition.position;
            player.transform.rotation = hidePosition.rotation;
            player.controller.rigidbody.isKinematic = true;
            player.controller.outPosition = outPosition;
            Debug.Log("Player is hiding in the locker.");
        }
        //else
        //{
        //    //player.controller.isHiding = false;
        //    Invoke("SetIsHidingFalse", 0.5f);
        //    player.transform.position = outPosition.position;
        //    player.transform.rotation = outPosition.rotation;
        //    player.controller.rigidbody.isKinematic = false;
        //    Debug.Log("Player is out from the locker.");
        //}
    }

    void SetIsHidingTrue()
    {
        player.controller.isHiding = true;
    }
//    void SetIsHidingFalse()
//    {
//        player.controller.isHiding = false;
//    }
}