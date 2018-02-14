using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOven : Machine {
    public Shape shape;
    public Batter batter;

    private void Start()
    {
        OnReceivedShape(new Shape(5));
        OnReceivedBatter(new Batter(3));
    }
    public void OnReceivedShape(Shape shape) {
        ValidateItemReceived<Shape>(ref this.shape, shape);
    }
    public void OnReceivedBatter(Batter batter) {
        ValidateItemReceived<Batter>(ref this.batter, batter);
    }
    private void ValidateItemReceived<ItemReceived>(ref ItemReceived currentItem, ItemReceived itemReceived)  where ItemReceived : Pickable
    {
       if(currentItem == null || currentItem.pickId != itemReceived.pickId)
        {
            currentItem = itemReceived;
   
            if (shape != null && batter != null)
                StartProcess();
        }

    }

    public override void StartProcess()
    {
        Debug.Log("Baking...");
        OnProcessComplete<Cake>(new Cake(shape,this.batter));
    }
    public override void OnProcessComplete<TResult>(TResult result) 
    {

        shape = null;
        batter = null;
    }
}
