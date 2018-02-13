using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake  : Pickable {
    public Shape shape;
    public Batter batter;
    public Frost frost;
    public Cake(Shape shape,Batter batter ,Frost frost = null) {
        this.shape = shape;
        this.batter = batter;
        this.frost = frost;
        this.pickSet.Add(typeof(Shape).ToString(), shape.pickId);
        this.pickSet.Add(typeof(Batter).ToString(), batter.pickId);
        this.pickSet.Add(typeof(Frost).ToString(),frost != null ? frost.pickId : -1);
        this.Render();
    }
    public override string ToString()
    {
        return string.Format(
            "Cake Status \nShape :{0}, Batter :{1}, Frost : {2}",
              shape.pickId, 
              batter.pickId ,
            frost == null ? - 1 : frost.pickId);
    }
}
