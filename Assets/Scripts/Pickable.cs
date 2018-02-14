using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PickType {
    Shape,
    Batter,
    Water,
}
public abstract class Pickable  {

    public Dictionary<string, int> pickSet;
    [SerializeField]
    private int _pickId = -1;
    public int pickId
    {
        get
        {
            return _pickId;
        }
        set
        {
            _pickId = value;
        }
    }
    public Pickable() {
        pickSet = new Dictionary<string, int>();
    }
    public void Render() {
        if(pickSet != null  && pickSet.Count > 0)
        {
            var selectorKey = pickSet.ContainsKey(typeof(Shape).ToString()) ? PickType.Shape : pickSet.ContainsKey(typeof(Batter).ToString()) ? PickType.Batter : PickType.Water;

            switch (selectorKey) {
                case PickType.Shape:
                    if (pickSet.ContainsKey(typeof(Batter).ToString()))
                        Debug.Log("Cake Render");
                    else
                        Debug.Log("Shape Render");

                    
                    break;
                case PickType.Batter:
                    Debug.Log("Batter Render");
                    break;
                case PickType.Water:
                    Debug.Log("Water Render");

                    break;


            }
        }
    }

   
}



