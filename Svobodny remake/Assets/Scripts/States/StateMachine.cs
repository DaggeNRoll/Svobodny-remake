using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


    public class StateMachine
    {
        private IState _currentState;

        private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();

        private List<Transition> _currentTransitions = new List<Transition>();
        private List<Transition> _anyTransitions = new List<Transition>();

        private static List<Transition> _emptyTransitions = new List<Transition>(0);

        public void Update()
        {
            var transition = GetTransition();

            if (transition != null)
            {
                SetState(transition.TargetState);
            }

            _currentState?.Update();
            //Debug.Log(_currentState?.stateName);
        }

        public void FixedUpdate()
        {
            _currentState?.FixedUpdate();
        }

        public void SetState(IState state)
        {
            if (state == _currentState)
                return;

            _currentState?.OnExit();
            _currentState = state;

            _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);

            _currentTransitions ??= _emptyTransitions;
            _currentState.OnEnter();
        }

        public void AddTransition(IState originState, IState targetState, Func<bool> predicate)
        {
            if (!_transitions.TryGetValue(originState.GetType(), out var transitions))
            {
                transitions = new List<Transition>();
                _transitions[originState.GetType()] = transitions;
            }

            transitions.Add(new Transition(targetState, predicate));
        }

        public void AddAnyTransition(IState targetState, Func<bool> predicate)
        {
            _anyTransitions.Add(new Transition(targetState, predicate));
        }

        private Transition GetTransition()
        {
            foreach (var transition in _anyTransitions)
            {
                if (transition.Condition())
                {
                    return transition;
                }
            }

            foreach (var transition in _currentTransitions)
            {
                if (transition.Condition())
                {
                    return transition;
                }
            }

            return null;
        }

        private class Transition
        {
            public Func<bool> Condition { get; }
            public IState TargetState { get; }

            public Transition(IState targetState, Func<bool> condition)
            {
                TargetState = targetState;
                Condition = condition;
            }
        }
    }
