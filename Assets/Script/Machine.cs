using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Machine: MonoBehaviour {

    public abstract void StartProcess();
    public abstract void OnProcessComplete<TResult>(TResult result) where TResult : Pickable;
    protected virtual void OnMouseDown()
    {
        Player.instance.AddCommand(this.GetHashCode(), OnMachineClicked);
    }
    public virtual void OnMachineClicked()
    {
        bool isEqualPosition =
            transform.position.magnitude > Player.instance.transform.position.magnitude ? 
            Mathf.Abs(transform.position.magnitude) - Mathf.Abs(Player.instance.transform.position.magnitude) < 0.1f:
            Mathf.Abs(transform.position.magnitude) - Mathf.Abs(Player.instance.transform.position.magnitude) > 0.1f; ;

        if (!isEqualPosition)
        {
            Player.instance.Move(transform.position);
            return;
        }
        Player.instance.NextCommand(this.GetHashCode());
          
    }
}
