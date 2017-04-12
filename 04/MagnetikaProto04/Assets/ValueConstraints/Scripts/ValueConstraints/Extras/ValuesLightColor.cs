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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ValueConstraints.Interfaces;

namespace ValueConstraints.Extras
{
    /// <summary>
    /// Test class for Value Float to change the light color
    /// </summary>
    [AddComponentMenu("Scripts/Value Constraints/Extras/Values Light Color")]
    [RequireComponent(typeof(Light))]
    public class ValuesLightColor : MonoBehaviour
    {
        [ValueSingle(0.0f, 1.0f, true)]
        [SerializeField]
        ValueSingleFloat m_ValueFloat = new ValueSingleFloat(0.0f, 1.0f, 0.5f, 1, 0.1f);

        [SerializeField]
        Color m_Start = Color.green;

        [SerializeField]
        Color m_End = Color.red;

        /// <summary>
        /// startColor classes accessor
        /// </summary>
        public Color startColor { get { return m_Start; } }

        /// <summary>
        /// endColor classes accessor
        /// </summary>
        public Color endColor { get { return m_End; } set { m_End = value; } }

        /// <summary>
        /// Value classes accessor
        /// </summary>
        public ValueSingleFloat valueFloat { get { return m_ValueFloat; } }

        IEnumerator Start()
        {
            Light light = GetComponent<Light>();
            
            List<IValueBounds> list = new List<IValueBounds>();            
            list.Add(m_ValueFloat);

            foreach(var item in list)
            {
                IValueLimits limit = item as IValueLimits;
                if(limit != null)
                {
                    limit.Prepare();
                }
            }

            while(enabled)
            {
                m_ValueFloat.PingPong(Time.deltaTime);
                light.color = Color.Lerp(m_Start, m_End, m_ValueFloat.current);
                yield return null;
            }
        }

    } 
}
