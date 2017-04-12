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

namespace ValueConstraints.Interfaces
{
    /// <summary>
    /// Defines an interface for the Value classes as Amooth Waypoint value actions
    /// </summary>
    public interface IValueSmoothWaypoint : IValueWaypoint
    {
        /// <summary>
        /// Scale for each node curve
        /// </summary>
        float[] curveScales { get; set; }

        /// <summary>
        /// Copies all source values to the current object.
        /// <para>Use this method to avoid creating a new object or to resuse this object.</para>
        /// </summary>
        /// <param name="source">The source object to copy values from.</param>
        void Copy(IValueSmoothWaypoint source);
    }
}


