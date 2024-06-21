using DG.Tweening;
using UnityEngine;

public static class TweenExtensions
{
    public static Tween DoTransform(this Transform current, Transform target, float duration)
    {
        current.DOMove(target.position, duration);
        return current.DORotate(target.rotation.eulerAngles, duration);
    }
}
