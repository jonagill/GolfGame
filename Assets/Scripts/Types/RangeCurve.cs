using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class RangeCurve 
{
    [SerializeField]
    private float _minValue = 0;

    [SerializeField]
    private float _maxValue = 1;

    [SerializeField]
    private AnimationCurve _curve = AnimationCurve.Linear(0,0,1,1.0f);

    public float MinValue
    {
        get
        {
            return _minValue;
        }
    }

    public float MaxValue
    {
        get
        {
            return _maxValue;
        }
    }

    public float Evaluate(float t)
    {
        t = _curve.Evaluate(t);
        return Mathf.Lerp(_minValue, _maxValue, t);
    }
}
