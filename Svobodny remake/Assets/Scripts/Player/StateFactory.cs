using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

namespace Player.Factory
{
    public abstract class State
    {
        public abstract string Name { get; }
        public abstract void EnterState();
        public abstract void Update();
        public abstract void FixedUpdate();
        

    }

    public class IdleState : State
    {
        public override string Name => "Idle";
        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void FixedUpdate()
        {
            throw new System.NotImplementedException();
        }
    }

    public class SneakingState : State
    {
        public override string Name => "Sneaking";
        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void FixedUpdate()
        {
            throw new System.NotImplementedException();
        }
    }

    public class RunningState : State
    {
        public override string Name => "Running";
        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void FixedUpdate()
        {
            throw new System.NotImplementedException();
        }
    }

    public class InactiveState : State
    {
        public override string Name => "Inactive";
        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void FixedUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class StateFactory
    {
        private Dictionary<string, Type> _statesByName;

        public StateFactory()
        {
            var stateTypes = Assembly.GetAssembly(typeof(State)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract);

            _statesByName = new Dictionary<string, Type>();

            foreach (var type in stateTypes)
            {
                var tempState = Activator.CreateInstance(type) as State;
                _statesByName.Add(tempState.Name,type);
            }

        }

        public State GetState(string stateName)
        {
            if (!_statesByName.ContainsKey(stateName)) return null;
            
            Type type = _statesByName[stateName];
            var state = Activator.CreateInstance(type) as State;
            
            return state;
        }
    }


}
