using System;
using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public struct TransformData : IEquatable<TransformData>
    {

        public Vector3 position { get; set; }
        public Vector3 scale { get; set; }
        public Quaternion rotation { get; set; }

        public bool Equals(TransformData other)
        {

            return other.position == position && other.scale == scale && other.rotation == rotation;

        }
    }

    public struct MaterialData : IEquatable<MaterialData>
    {

        public Material material { get; set; }
        public Color startColor { get; set; }

        public bool Equals(MaterialData other)
        {

            return other.material == material && other.startColor == startColor;

        }
    }

    public class AnimationData : MonoBehaviour
    {

        private TransformData _transformData = new TransformData();
        public TransformData TransformData
        {
            get
            {
                return _transformData;
            }
        }

        private List<MaterialData> _materials = new List<MaterialData>();
        public List<MaterialData> Materials
        {
            get
            {
                return _materials;
            }
        }

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

            var materialsInChildren = CandyCoded.Materials.GetMaterialsInChildren(gameObject);

            foreach (Material material in materialsInChildren)
            {

                var materialData = new MaterialData
                {
                    material = material,
                    startColor = material.color
                };

                _materials.Add(materialData);

            }

        }

    }

}
