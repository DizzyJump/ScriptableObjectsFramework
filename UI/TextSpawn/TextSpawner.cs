using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    public Transform MessagePrefab;
    public float TimeToDestroy;
    public SpawnTextPipeline Pipeline;
    Camera WorkCamera;
    Dictionary<int, Stack<SpawnedText>> FreeTexts = new Dictionary<int, Stack<SpawnedText>>();
    // Start is called before the first frame update
    void Start()
    {
        WorkCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        Pipeline.AddHandler(OnSpawn);
    }

    void OnDisable()
    {
        Pipeline.RemoveHandler(OnSpawn);
    }

    public void OnFreeText(int id, SpawnedText text)
    {
        FreeTexts[id].Push(text);
    }

    void SpawnText()
    {
        SpawnedText textPrefab = Pipeline.Config.TextPrefab;
        int id = textPrefab.gameObject.GetInstanceID();
        if(!FreeTexts.ContainsKey(id))
            FreeTexts.Add(id, new Stack<SpawnedText>());
        var free_steck = FreeTexts[id];
        if(free_steck.Count == 0)
            free_steck.Push(Instantiate(textPrefab, transform));

        var obj = free_steck.Pop();
        obj.Setup(Pipeline, WorkCamera, this);
    }

    public void OnSpawn()
    {
        SpawnText();
    }
}
