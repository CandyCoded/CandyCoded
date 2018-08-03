/*
 * The MIT License (MIT)
 *
 * Copyright (c) 2018 Scott Doxey
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

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
