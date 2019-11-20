using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class FirstState : State<Target>
{
    private static FirstState _Instance;

    private FirstState()
    {
        if (_Instance != null)
        {
            return;
        }

        _Instance = this;
    }

    public static FirstState Instance
    {
        get
        {
            if (Instance == null)
            {
                new FirstState();
            }

            return _Instance;
        }
    }

    public override void EnterState(Target _owner)
    {
        Debug.Log("Entering First State.");
    }

    public override void ExitState(Target _owner)
    {
        Debug.Log("Exiting First State.");
    }

    public override void UpdateState(Target _owner)
    {
        if (_owner.switchState)
        {
            _owner.stateMachine.ChangeState(SecondState.Instance);
        }
    }
}
