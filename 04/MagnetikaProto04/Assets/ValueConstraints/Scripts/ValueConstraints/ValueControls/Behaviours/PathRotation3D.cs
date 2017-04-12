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

using UnityEngine;

namespace ValueConstraints.ValueControls.Behaviours
{
    /// <summary>
    /// Rotates a transform along the minimum and maximum 3D position vectors
    /// </summary>
    [AddComponentMenu("Scripts/Value Constraints/Behaviours/PathRotation 3D", 2020)]
    public class PathRotation3D : PathRotation
    {

        /// <summary>
        /// Rotate object in 3D world space
        /// </summary>
        /// <param name="travelDirection">Current direction of travel</param>
        /// <returns>Quaternion to set object transform rotation value</returns>
        protected override Quaternion DoPathRotation(Vector3 travelDirection)
        {
            return Quaternion.LookRotation(travelDirection);
        }
    }
}
