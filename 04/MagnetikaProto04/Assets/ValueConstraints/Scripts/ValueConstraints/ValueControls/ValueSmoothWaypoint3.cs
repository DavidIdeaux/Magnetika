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

using System;
using UnityEngine;
using ValueConstraints.Interfaces;

namespace ValueConstraints.ValueControls
{

    /// <summary>
    /// Class for Value SmoothWaypoint3D references
    /// </summary>
    [Serializable]
    public class ValueSmoothWaypoint3 : ValueWaypoint3, IValueSmoothWaypoint
    {
        /// <summary>
        /// Defines an empty or blank value
        /// </summary>
        public new static readonly ValueSmoothWaypoint3 Empty = new ValueSmoothWaypoint3();

        [SerializeField]
        float[] m_CurveScales;

        /// <summary>
        /// Scale for each node curve
        /// </summary>
        public float[] curveScales
        {
            get { return m_CurveScales; }
            set { m_CurveScales = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ValueSmoothWaypoint3()
            : base()
        { }

        /// <summary>
        /// Copies all source values to the current object.
        /// <para>Use this method to avoid creating a new object or to resuse this object.</para>
        /// </summary>
        /// <param name="source">The source object to copy values from.</param>
        public void Copy(IValueSmoothWaypoint source)
        {
            base.Copy(source);
            Set(source.curveScales);
        }

        void Set(float[] curveScales)
        {
            this.curveScales = curveScales;
        }

        /// <summary>
        /// Flips the current value from minimum and maximum and vice-versa
        /// <para>Overriden to stop flip for waypoint traversal</para>
        /// </summary>
        public override float Flip()
        {
            return base.current;
        }

        /// <summary>
        /// Flips the direction value from -1 and 1 and vice-versa
        /// <para>Overriden to stop flip for waypoint traversal</para>
        /// </summary>
        public override int FlipDirection()
        {
            return base.direction;
        }
    }
}
