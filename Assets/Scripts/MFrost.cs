using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFrost : Machine {
    public Frost frost;
    public Cake receivedCake;


    private void Start()
    {
        frost = new Frost(2);
        OnReceivedCake(new Cake(new Shape(2), new Batter(2)));
    }
    public void OnReceivedCake(Cake cake) {
        if (cake.frost == null) {
            receivedCake = cake;
            StartProcess();
        }
    }
    public override void OnProcessComplete<TResult>(TResult result)
    {
        Debug.Log(result);
        receivedCake = null;
    }
    public override void StartProcess()
    {

        Debug.Log("Frosting...");
        Cake result = new Cake(receivedCake.shape, receivedCake.batter, frost);
        OnProcessComplete<Cake>(result);
    }

}
