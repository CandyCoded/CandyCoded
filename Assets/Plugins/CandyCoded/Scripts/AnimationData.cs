// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public struct TransformData : IEquatable<TransformData>
    {

        public Vector3 Position { get; set; }

        public Vector3 Scale { get; set; }

        public Quaternion Rotation { get; set; }

        public bool Equals(TransformData other)
        {

            return other.Position == Position && other.Scale == Scale && other.Rotation == Rotation;

        }

    }

    public struct MaterialData : IEquatable<MaterialData>
    {

        public Material Material { get; set; }

        public Color StartColor { get; set; }

        public bool Equals(MaterialData other)
        {

            return other.Material == Material && other.StartColor == StartColor;

        }

    }

    public class AnimationData : MonoBehaviour
    {

        private List<MaterialData> _materials = new List<MaterialData>();

        private TransformData _transformData;

        public TransformData TransformData => _transformData;

        public IEnumerable<MaterialData> Materials => _materials;

#pragma warning disable S1144

        // Disables "Unused private types or members should be removed" warning as method is part of MonoBehaviour.
        private void Awake()
        {

            RebuildCachedData();

        }
#pragma warning restore S1144

        /// <summary>
        ///     Rebuilds all cache material color data.
        /// </summary>
        /// <returns>void</returns>
        public void CacheMaterials()
        {

            _materials = new List<MaterialData>();

            var materialsInChildren = CandyCoded.Materials.GetMaterialsInChildren(gameObject);

            foreach (var material in materialsInChildren)
            {

                var materialData = new MaterialData { Material = material };

                if (material.HasProperty("color"))
                {

                    materialData.StartColor = material.color;

                }

                _materials.Add(materialData);

            }

        }

        /// <summary>
        ///     Rebuilds all cache transform data.
        /// </summary>
        /// <returns>void</returns>
        public void CacheTransformData()
        {

            var localTransform = gameObject.transform;

            _transformData.Position = localTransform.localPosition;
            _transformData.Scale = localTransform.localScale;
            _transformData.Rotation = localTransform.localRotation;

        }

        /// <summary>
        ///     Rebuilds all cache data related to basic animations: initial transform and material color data.
        /// </summary>
        /// <returns>void</returns>
        public void RebuildCachedData()
        {

            CacheTransformData();
            CacheMaterials();

        }

    }

}
