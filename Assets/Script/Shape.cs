using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shape : Pickable {

    public Shape(int pickId)
    {
        this.pickId = pickId;
        this.pickSet.Add(this.ToString(), pickId);
        this.Render();
    }
    
}
