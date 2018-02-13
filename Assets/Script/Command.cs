using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class Command <T>: Singleton  <T> {
    public Dictionary<int, List<Action>> commandSet = new Dictionary<int, List<Action>>();
    protected Action executingCommand;
    public virtual int maxCommand
    {
        get {
            return 10;
        }
    }
    public virtual int maxRepeatCommand {
        get {
            return 2;
        }
    }
    public  void AddCommand(int hash,Action command) {
        if (commandSet.ContainsKey(hash))
        {
            var isAvaiableCommand = commandSet[hash].Count < maxRepeatCommand;

            if (isAvaiableCommand && !isMaxCommand) { 
                commandSet[hash].Add(command);
                //A command was added.
             }
        }
        else
        {
            commandSet.Add(hash, new List<Action>() {command});
            Debug.Log("Add command key: " + hash);
            //foreach (KeyValuePair<int, List<Action>> cmd in commandSet.Reverse())
            //{
            //    Debug.Log(cmd.Key);
            //}
            //Command inited a new key.
        }
    }
    public void NextCommand(int hash) {
        executingCommand = null;
        commandSet[hash].RemoveAt(0);
        if (commandSet[hash].Count > 0) { 
           executingCommand = commandSet[hash][0];
            //Debug.Log("Execute same command: " + hash)
        }
        else
        {
            commandSet.Remove(hash);
            //Debug.Log("Delete command key: " + hash);
        }
    }
    public void ExecuteCommand()
    {
        if (executingCommand != null)
        {
            executingCommand();
            return;
        }


        if (commandSet == null || commandSet.Count == 0 || commandSet.Keys.Count == 0) {
            //Command is executing nothing.
            return;
        }
        
        foreach (KeyValuePair<int,List<Action>> cmd in commandSet)
        {
            var commands = cmd.Value;
            if (commands.Count > 0)
            {
                executingCommand = commands[0];
                return;
            }
        }
       

    }
 

   private bool isMaxCommand
    {
        get {

            int commandCount = 0;
            foreach(KeyValuePair<int,List<Action>> cmd in commandSet)
            {
                commandCount += cmd.Value.Count;
            }
            return commandCount + 1 >= maxCommand;
            
        }

    }

}
