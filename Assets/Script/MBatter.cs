using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBatter : Machine {
    public Batter batter;
    public override void StartProcess()
    {
        OnProcessComplete <Batter> (this.batter);
    }
    public override void OnProcessComplete<TResult>(TResult result)
    {
        Debug.Log(this.batter);
    }
}
