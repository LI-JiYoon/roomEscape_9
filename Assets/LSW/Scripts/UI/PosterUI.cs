using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PosterUI : MonoBehaviour
{
    [SerializeField] private GameObject poster;
    [SerializeField] public GameObject wanted;
    [SerializeField] public GameObject story;


    public void OnPoster()
    {
        poster.transform.DOLocalMoveY(poster.transform.localPosition.y - 1200f, 1.6f).SetEase(Ease.OutCubic).OnComplete(() =>
        {
               
        });
    }

    public void OnClickPoster()
    {
        wanted.SetActive(true);
    }

    public void OnClickWanted()
    {
        wanted.SetActive(false);
        SceneManager.LoadScene("MainScene");
    } 
}