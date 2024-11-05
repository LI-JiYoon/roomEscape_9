using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    private bool isMove = false;

    public void OnClickMenuUI()
    {
        if (isMove == false)
        {
            isMove = true;

            if (!menuPanel.activeSelf)
            {
                menuPanel.SetActive(true);
                menuPanel.transform.DOLocalMoveX(menuPanel.transform.localPosition.x + 200f, 0.5f)
                    .SetEase(Ease.OutCubic).OnComplete(() =>
                    {
                        isMove = false;
                    }); 
            }
            else
            {
                menuPanel.transform.DOLocalMoveX(menuPanel.transform.localPosition.x - 200f, 0.5f)
                     .SetEase(Ease.OutCubic)
                     .OnComplete(() =>
                     {
                         menuPanel.SetActive(false);
                         isMove = false;
                     });
            }
        }
    }

}
