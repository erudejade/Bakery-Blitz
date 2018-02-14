using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Batter : Pickable{
    public Batter(int pickId)
    {
        this.pickId = pickId;
        this.pickSet.Add(this.ToString(), pickId);
        this.Render();
    }
}

