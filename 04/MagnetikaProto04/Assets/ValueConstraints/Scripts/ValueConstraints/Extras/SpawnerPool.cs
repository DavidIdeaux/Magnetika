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
using UnityEngine;

namespace ValueConstraints.Extras
{
    /// <summary>
    /// Pools and Spawns game objects
    /// </summary>
    [AddComponentMenu("Scripts/Value Constraints/Extras/Spawner Pool")]
    public class SpawnerPool : MonoBehaviour
    {
        [SerializeField]
        ValueBoundsFloat m_DelayRange = new ValueBoundsFloat();

        [SerializeField]
        GameObject[] m_Pickups = null;

        [Tooltip("Do not change at runtime")]
        [SerializeField]
        int m_PoolAmount = 20;

        GameObject[] m_ObjectPool = null;
        int m_CurrentIndex = 0;

        IEnumerator Start()
        {
            var trans = transform;
            Transform container = GameObject.Find("Container").transform;
            m_ObjectPool = new GameObject[m_PoolAmount];
            for(int i = 0; i < m_PoolAmount; i++)
            {
                m_ObjectPool[i] = GameObject.Instantiate(m_Pickups[Random.Range(0, m_Pickups.Length)]) as GameObject;
                m_ObjectPool[i].transform.parent = container;
                m_ObjectPool[i].SetActive(false);
            }

            while(enabled)
            {
                m_ObjectPool[m_CurrentIndex].SetActive(true);
                m_ObjectPool[m_CurrentIndex].transform.position = trans.position;
                m_ObjectPool[m_CurrentIndex].transform.rotation = trans.rotation;
                m_CurrentIndex = (m_CurrentIndex + 1) % m_ObjectPool.Length;
                yield return new WaitForSeconds(m_DelayRange.RandomValue);
            }
        }
    } 
}
