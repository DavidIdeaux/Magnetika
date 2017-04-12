#region Author
/*
     
     Jones St. Lewis Cropper (caLLow)
     
     Another caLLowCreation
     
     Visit us on Google+ and other social media outlets @caLLowCreation
     
     Thanks for using our product.
     
     Send questions/comments/concerns/requests to 
      e-mail: caLLowCreation@gmail.com
      subject: ValueConstraints
     
*/
#endregion

using BezierAlgorithms;
using System;
using UnityEngine;
using ValueConstraints.Interfaces;
using ValueConstraints.ValueControls;

namespace ValueConstraints.Utils
{
    /// <summary>
    /// Utility variables and methods for Value SmoothWaypoint
    /// </summary>
    public static class ValueSmoothWaypointUtils
    {
        /// <summary>
        /// Represents no movement
        /// </summary>
        public const int DIRECTION_NONE = 0;

        /// <summary>
        /// Represents movement in the -scale direction
        /// </summary>
        public const int DIRECTION_REVERSE = -1;

        /// <summary>
        /// Represents movement in the +scale direction
        /// </summary>
        public const int DIRECTION_FORWARD = 1;


        internal static Func<int, int, bool> _CanIncrement = (val, lmt) =>
        {
            return val < lmt;
        };
        internal static Func<int, int, bool> _CanDecrement = (val, lmt) =>
        {
            return val > lmt;
        };

        internal static Func<int, int> _Add = (val) =>
        {
            return val + 1;
        };

        internal static Func<int, int> _Sub = (val) =>
        {
            return val - 1;
        };


        internal static Func<IValueWaypoint, int, bool> _LessOrEqual = (valueWaypoint, val) =>
        {
            return val <= 0;
        };
        internal static Func<IValueWaypoint, int, bool> _GreaterOrEqual = (valueWaypoint, val) =>
        {
            return val >= valueWaypoint.nodes.Length - 1;
        };

        internal static Func<IValueWaypoint, int, Func<IValueWaypoint, int, bool>, bool> _FlipDirection = (valueWaypoint, currentIndex, doCheck) =>
        {
            if(doCheck.Invoke(valueWaypoint, currentIndex))
            {
                valueWaypoint.direction *= -1;
                return true;
            }
            return false;
        };

        /// <summary>
        /// Initilizes a waypoint interface to start route
        /// </summary>
        /// <param name="valueWaypoint">Interface to initilize</param>
        /// <param name="onClamped">Callback for onClamped event, happens when each node is reached</param>
        public static void InitilizeDirection(IValueWaypoint valueWaypoint, EventHandler onClamped)
        {
            float scaleDirection = Mathf.Sign(valueWaypoint.scale);
            switch(valueWaypoint.actionType)
            {
                case ActionType.PingPong:
                    if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_FORWARD))
                    {
                        valueWaypoint.currentIndex = 0;
                        valueWaypoint.minIndex = 0;
                        valueWaypoint.maxIndex = 1;
                        valueWaypoint.current = 0.0f;
                    }
                    else if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_REVERSE))
                    {
                        valueWaypoint.currentIndex = valueWaypoint.nodes.Length - 1;
                        valueWaypoint.minIndex = valueWaypoint.nodes.Length - 1;
                        valueWaypoint.maxIndex = 0;
                        valueWaypoint.current = 1.0f;
                    }
                    break;
                case ActionType.Wrap:
                    if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_FORWARD))
                    {
                        valueWaypoint.currentIndex = 0;
                        valueWaypoint.minIndex = 0;
                        valueWaypoint.maxIndex = valueWaypoint.minIndex + 1;
                        valueWaypoint.current = 0.0f;
                    }
                    else if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_REVERSE))
                    {
                        valueWaypoint.currentIndex = valueWaypoint.nodes.Length - 1;
                        valueWaypoint.minIndex = valueWaypoint.nodes.Length - 1;
                        valueWaypoint.maxIndex = 0;
                        valueWaypoint.current = 1.0f;
                    }
                    break;
                case ActionType.None:
                case ActionType.Random:
                default:
                    break;
            }
            valueWaypoint.onClamp += onClamped;
        }

        /// <summary>
        /// Responds to OnClamped event from Value Waypoint
        /// </summary>
        /// <param name="valueWaypoint">Value Waypoint sending the event</param>
        public static void OnValueWaypointClamp(IValueWaypoint valueWaypoint)
        {
            float scaleDirection = Mathf.Sign(valueWaypoint.scale);

            switch(valueWaypoint.actionType)
            {
                case ActionType.PingPong:
                    if(!valueWaypoint.loop)
                    {
                        if(!ValueSmoothWaypointUtils.IsRouteCycleCompleted(valueWaypoint))
                        {
                            ValueSmoothWaypointUtils.Shift(valueWaypoint, scaleDirection);
                        }
                    }
                    else
                    {
                        if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_REVERSE) && valueWaypoint.direction.Equals(ValueSmoothWaypointUtils.DIRECTION_REVERSE))
                        {
                            if(!ValueSmoothWaypointUtils._FlipDirection.Invoke(valueWaypoint, valueWaypoint.currentIndex, ValueSmoothWaypointUtils._GreaterOrEqual))
                            {
                                ValueSmoothWaypointUtils.Shift(valueWaypoint, -scaleDirection);
                            }
                        }
                        else if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_REVERSE) && valueWaypoint.direction.Equals(ValueSmoothWaypointUtils.DIRECTION_FORWARD))
                        {
                            if(!ValueSmoothWaypointUtils._FlipDirection.Invoke(valueWaypoint, valueWaypoint.currentIndex, ValueSmoothWaypointUtils._LessOrEqual))
                            {
                                ValueSmoothWaypointUtils.Shift(valueWaypoint, scaleDirection);
                            }
                        }
                        else if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_FORWARD) && valueWaypoint.direction.Equals(ValueSmoothWaypointUtils.DIRECTION_FORWARD))
                        {
                            if(!ValueSmoothWaypointUtils._FlipDirection.Invoke(valueWaypoint, valueWaypoint.currentIndex, ValueSmoothWaypointUtils._GreaterOrEqual))
                            {
                                ValueSmoothWaypointUtils.Shift(valueWaypoint, scaleDirection);
                            }
                        }
                        else if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_FORWARD) && valueWaypoint.direction.Equals(ValueSmoothWaypointUtils.DIRECTION_REVERSE))
                        {
                            if(!ValueSmoothWaypointUtils._FlipDirection.Invoke(valueWaypoint, valueWaypoint.currentIndex, ValueSmoothWaypointUtils._LessOrEqual))
                            {
                                ValueSmoothWaypointUtils.Shift(valueWaypoint, -scaleDirection);
                            }
                        }
                    }
                    break;
                case ActionType.Wrap:
                    if(!valueWaypoint.loop)
                    {
                        if(!ValueSmoothWaypointUtils.IsRouteCycleCompleted(valueWaypoint))
                        {
                            ValueSmoothWaypointUtils.Shift(valueWaypoint, scaleDirection);
                        }
                    }
                    else
                    {
                        ValueSmoothWaypointUtils.Shift(valueWaypoint, scaleDirection);
                    }
                    break;
                case ActionType.None:
                case ActionType.Random:
                default:
                    break;
            }
            valueWaypoint.Prepare();
            ValueWaypointUtils.SetVecsToNode(valueWaypoint);

        }

        /// <summary>
        /// Test current node position to determine end of route
        /// </summary>
        /// <param name="valueWaypoint">Value Waypoint to test for route complete</param>
        /// <returns>True is at end of route false if not</returns>
        public static bool IsRouteCycleCompleted(IValueWaypoint valueWaypoint)
        {
            float scaleDirection = Mathf.Sign(valueWaypoint.scale);
            if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_FORWARD))
            {
                if(ValueSmoothWaypointUtils._GreaterOrEqual.Invoke(valueWaypoint, valueWaypoint.currentIndex))
                {
                    return true;
                }
            }
            else if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_REVERSE))
            {
                if(ValueSmoothWaypointUtils._LessOrEqual.Invoke(valueWaypoint, valueWaypoint.currentIndex))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Shifts the Min and Max Indices to the next set for route movement
        /// </summary>
        /// <param name="valueWaypoint">Value Waypoint interface to modify</param>
        /// <param name="scaleDirection">Direction of shift -1, 0, 1</param>
        public static void Shift(IValueWaypoint valueWaypoint, float scaleDirection)
        {
            if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_FORWARD))
            {
                ValueSmoothWaypointUtils.ShiftMinMaxIndex(valueWaypoint, valueWaypoint.nodes.Length - 1, 0, ValueSmoothWaypointUtils._CanIncrement, _Add, 0.0f);
            }
            else if(scaleDirection.Equals(ValueSmoothWaypointUtils.DIRECTION_REVERSE))
            {
                ValueSmoothWaypointUtils.ShiftMinMaxIndex(valueWaypoint, 0, valueWaypoint.nodes.Length - 1, ValueSmoothWaypointUtils._CanDecrement, _Sub, 1.0f);
            }
            else // ValueSmoothWaypointUtils.DIRECTION_NONE
            {

            }
        }

        /// <summary>
        /// Shifts the Min and Max Indices to the next set for route movement
        /// </summary>
        /// <param name="valueWaypoint">Interface to modify</param>
        /// <param name="limit">Limit/End Index of movement for route section</param>
        /// <param name="begin">Route section begin Index</param>
        /// <param name="canChange">Test for can enter conditional change</param>
        /// <param name="doChange">Method to preform change</param>
        /// <param name="current">Value to set interfaces current value</param>
        internal static void ShiftMinMaxIndex(IValueWaypoint valueWaypoint, int limit, int begin, Func<int, int, bool> canChange, Func<int, int> doChange, float current)
        {
            valueWaypoint.minIndex = doChange.Invoke(valueWaypoint.minIndex);
            if(canChange.Invoke(valueWaypoint.minIndex, limit))
            {
                valueWaypoint.maxIndex = doChange.Invoke(valueWaypoint.minIndex);
            }
            else if(valueWaypoint.minIndex == limit)
            {
                valueWaypoint.maxIndex = begin;
            }
            else
            {
                valueWaypoint.minIndex = begin;
                valueWaypoint.maxIndex = doChange.Invoke(valueWaypoint.minIndex);
            }

            valueWaypoint.current = current;
        }

        /// <summary>
        /// Sets the current index for use in route traversal
        /// </summary>
        /// <param name="valueWaypoint">Interface to modify</param>
        /// <param name="controlSection">Current control section will be set by calculation</param>
        internal static void CalculateCurrentIndex(IValueSmoothWaypoint valueWaypoint, out CurveControlSection controlSection)
        {
            IControlNode[] controlNodes = new IControlNode[valueWaypoint.nodes.Length];
            for(int i = 0; i < valueWaypoint.nodes.Length; i++)
            {
                controlNodes[i] = ControlNode.CreateNode(i, valueWaypoint.nodes[i], Quaternion.identity, valueWaypoint.curveScales[i]);
            }
            CurveControlSection[] controlSections = CurveControlArgs.GetComputedAndSlicedSections(new CurveControlArgs(controlNodes, true));
            controlSection = controlSections[valueWaypoint.minIndex];

            float routeTime = (valueWaypoint.minIndex + valueWaypoint.current) / controlSections.Length;
            valueWaypoint.currentIndex = (int)(controlSections.Length * routeTime);
        }
    }
}