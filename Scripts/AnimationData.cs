using System;
using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public struct TransformData : IEquatable<TransformData>
    {
        public Vector3 position;
        public Vector3 scale;
        public Quaternion rotation;
        public bool Equals(TransformData transformData)
        {

            return transformData.position == position && transformData.scale == scale && transformData.rotation == rotation;

        }
    }

    public struct MaterialData : IEquatable<MaterialData>
    {
        public Material material;
        public Color startColor;
        public bool Equals(MaterialData materialData)
        {

            return materialData.material == material && materialData.startColor == startColor;

        }
    }

    public class AnimationData : MonoBehaviour
    {

        public TransformData TransformData
        {
            get
            {
                return _transformData;
            }
        }

        private TransformData _transformData = new TransformData();

        public List<MaterialData> Materials
        {
            get
            {
                return _materials;
            }
        }

        private List<MaterialData> _materials = new List<MaterialData>();

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

            _transformData.position = gameObject.transform.localPosition;
            _transformData.scale = gameObject.transform.localScale;
            _transformData.rotation = gameObject.transform.localRotation;

        }

        /// <summary>
        /// Rebuilds all cache material color data.
        /// </summary>
        /// <returns>void</returns>
        public void CacheMaterials()
        {

            _materials = new List<MaterialData>();

            Material[] materialsInChildren = CandyCoded.Materials.GetMaterialsInChildren(gameObject);

            foreach (Material material in materialsInChildren)
            {

                MaterialData materialData = new MaterialData
                {
                    material = material,
                    startColor = material.color
                };

                _materials.Add(materialData);

            }

        }

    }

}
