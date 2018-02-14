using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MShape : Machine {
    public Shape shape;
    public override void StartProcess()
    {
        OnProcessComplete<Shape>(this.shape);
    }
    public override void OnProcessComplete<TResult>(TResult result)
    {
        Debug.Log(result);
    }
  
}
