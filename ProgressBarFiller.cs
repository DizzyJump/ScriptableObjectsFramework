using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ProgressBarFiller : MonoBehaviour
{
    [SerializeField] private RectTransform.Axis movingAxis;

    private float startSize;

    private RectTransform tr;

    private float currentValue;

    private float targetValue;

    [SerializeField] private float increaseSpeed;

    [SerializeField] private float decreaseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        tr = transform as RectTransform;
        startSize = movingAxis == RectTransform.Axis.Horizontal ? tr.rect.width : tr.rect.height;
        currentValue = 0;
        targetValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetValue > currentValue)
            currentValue = Mathf.MoveTowards(currentValue, targetValue, increaseSpeed * Time.deltaTime);
        else
            currentValue = Mathf.MoveTowards(currentValue, targetValue, decreaseSpeed * Time.deltaTime);
        float newWidth = currentValue * startSize;
        tr.SetSizeWithCurrentAnchors(movingAxis, newWidth);
    }

    [Button]
    public void SetTargetValue(float value)
    {
        targetValue = value;
    }
}
