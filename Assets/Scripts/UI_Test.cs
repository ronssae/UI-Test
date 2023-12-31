using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UI_Test : MonoBehaviour
{
    public GameObject Test_UI;
    public Vector3 TargetPos, OriginalPos;
    public float TravelTime;
    public float Fade_Duration;
    public Image TargetImage;
    public Vector3 TargetRotation;
    public float RotateDuration;
    public float ScaleSize;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    public void SequenceTween()
    {
        Sequence sequence = DOTween.Sequence();

        //1st-Task
        sequence.Append(Test_UI.transform.DOLocalMove(TargetPos, TravelTime).SetEase(Ease.InOutBounce));
        //Delay before 2nd-Task
        sequence.AppendInterval(1);
        //2nd-Task
        sequence.Append(Test_UI.transform.DOScale(Vector3.one, TravelTime).SetEase(Ease.InOutBounce));
        //Delay before 3rd-Task
        sequence.AppendInterval(1);
        //3rd-Task
        sequence.Append(Test_UI.transform.DOLocalMove(OriginalPos, TravelTime).SetEase(Ease.InOutBounce));
    }

    public void MoveTween()
    {
        Test_UI.transform.DOLocalMove(TargetPos, TravelTime).SetEase(Ease.Linear).OnComplete(()=> ReturnPos());
    }

    public void ReturnPos()
    {
        Test_UI.transform.DOLocalMove(OriginalPos, TravelTime).SetEase(Ease.Linear);
    }

    public void ScaleToZeroTween()
    {
        Test_UI.transform.DOScale(Vector3.zero, TravelTime).SetEase(Ease.Linear).OnComplete(() => ScaleBackTween());
    }

    public void ScaleBackTween()
    {
        Test_UI.transform.DOScale(ScaleSize, TravelTime).SetEase(Ease.Linear);
    }

    public void FadeTween()
    {
        TargetImage.DOFade(0, Fade_Duration).OnComplete(()=> FadeIn());
    }

    public void FadeIn()
    {
        TargetImage.DOFade(1, Fade_Duration);
    }

    public void Rotation()
    {
        TargetImage.transform.DOLocalRotate(TargetRotation,RotateDuration).SetEase(Ease.Linear).SetLoops(2,LoopType.Incremental);
    }

    public void Flip()
    {
        TargetImage.transform.DOFlip();
    }
}
