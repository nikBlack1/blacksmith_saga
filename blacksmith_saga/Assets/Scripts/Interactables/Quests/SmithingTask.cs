using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmithingTask
{
    // Start is called before the first frame update
    public bool accepted = false;
    public int Reward;
    public int Fame;
    public int ChunksNeeded;
    
    
    public SmithingTask(int reward, int fame, int chunksNeeded)
    {
        Reward = reward;
        Fame = fame;
        ChunksNeeded = chunksNeeded;
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
