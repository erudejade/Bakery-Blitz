using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Machine: AreaBehaviour {
    private float offset = 0.25f;
   
    public abstract void StartProcess();
    public abstract void OnProcessComplete<TResult>(TResult result) where TResult : Pickable;
    protected virtual void OnMouseDown()
    {
        Player.instance.AddCommand(this.GetHashCode(), OnMachineClicked);
    }
    public virtual void OnMachineClicked(Vector3 playerLastPos)
    {
        Vector3 machinePos = Player.instance.clampedPosition;
        Vector3 playerPos = clampedPosition;
      
        bool isEqualPosition =
            machinePos.x > playerPos.x ?
            machinePos.x - playerPos.x < offset : 
            playerPos.x - machinePos.x < offset;
       
        if (!isEqualPosition)
        {
            Player.instance.Move(clampedPosition, playerLastPos);
            return;
        }
        Player.instance.t = 0; //Reset moving
        Player.instance.NextCommand(this.GetInstanceID());
          
    }
}
