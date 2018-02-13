using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBehaviour : MonoBehaviour {

	public virtual Vector3 clampedPosition
    {
        get
        {
            return Area.instance.Clamp(transform.position);
        }
    }

    public virtual Vector3 absPosition
    {
        get
        {
            return new Vector3(Mathf.Abs(transform.position.x),Mathf.Abs(transform.position.y),Mathf.Abs(transform.position.z));
        }
    }
}
