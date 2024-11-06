using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class PosterUI : MonoBehaviour
{
    [SerializeField] private GameObject poster;
    [SerializeField] public GameObject wanted;
    [SerializeField] public GameObject story;

    [Space(10)]
    public UnityEvent callback;


    public void OnPoster()
    {
        poster.transform.DOLocalMoveY(poster.transform.localPosition.y - 1200f, 1.6f).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            callback.Invoke();
        });
    }

  
}