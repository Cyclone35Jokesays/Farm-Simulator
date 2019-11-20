using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class SecondState : State<Target>
{
    private static SecondState _Instance;

    private SecondState()
    {
        if (_Instance != null)
        {
            return;
        }

        _Instance = this;
    }

    public static SecondState Instance
    {
        get
        {
            if (Instance == null)
            {
                new SecondState();
            }

            return _Instance;
        }
    }

    public override void EnterState(Target _owner)
    {
        Debug.Log("Entering Second State.");
    }

    public override void ExitState(Target _owner)
    {
        Debug.Log("Exiting Second State.");
    }

    public override void UpdateState(Target _owner)
    {
        if (_owner.switchState)
        {
            _owner.stateMachine.ChangeState(FirstState.Instance);
        }
    }
}

