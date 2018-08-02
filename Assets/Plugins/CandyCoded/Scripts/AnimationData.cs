using System;
using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public struct TransformData : IEquatable<TransformData>
    {
        private Vector3 _position;
        public Vector3 position
        {
            get { return _position; }
            set { _position = value; }
        }

        private Vector3 _scale;
        public Vector3 scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        private Quaternion _rotation;
        public Quaternion rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public bool Equals(TransformData other)
        {

            return other.position == position && other.scale == scale && other.rotation == rotation;

        }
    }

    public struct MaterialData : IEquatable<MaterialData>
    {
        private Material _material;
        public Material material
        {
            get { return _material; }
            set { _material = value; }
        }

        private Color _startColor;
        public Color startColor
        {
            get { return _startColor; }
            set { _startColor = value; }
        }

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
