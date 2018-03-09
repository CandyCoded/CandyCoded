using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public struct TransformData
    {
        public Vector3 position;
        public Vector3 scale;
        public Quaternion rotation;
    }

    public struct MaterialData
    {
        public Material material;
        public Color startColor;
    }

    public class AnimationData : MonoBehaviour
    {

        public TransformData transformData = new TransformData();

        public List<MaterialData> materials = new List<MaterialData>();

        private void Awake()
        {

            RebuildCachedData();

        }

        /// <summary>
        /// Rebuilds all cache data related to basic animations: initial transform and material color data.
        /// </summary>
        /// <returns>void</returns>
        public void RebuildCachedData()
        {

            CacheTransformData();
            CacheMaterials();

        }

        /// <summary>
        /// Rebuilds all cache transform data.
        /// </summary>
        /// <returns>void</returns>
        public void CacheTransformData()
        {

            transformData.position = gameObject.transform.localPosition;
            transformData.scale = gameObject.transform.localScale;
            transformData.rotation = gameObject.transform.localRotation;

        }

        /// <summary>
        /// Rebuilds all cache material color data.
        /// </summary>
        /// <returns>void</returns>
        public void CacheMaterials()
        {

            materials = new List<MaterialData>();

            Material[] materialsInChildren = CandyCoded.Materials.GetMaterialsInChildren(gameObject);

            foreach (Material material in materialsInChildren)
            {

                MaterialData materialData = new MaterialData
                {
                    material = material,
                    startColor = material.color
                };

                materials.Add(materialData);

            }

        }

    }

}
