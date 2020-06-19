// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

// ReSharper disable RequiredBaseTypesConflict

using UnityEngine;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "GameObjectListReference", menuName = "CandyCoded/GameObjectListReference")]
    [HelpURL(
        "https://github.com/CandyCoded/CandyCoded/blob/master/Documentation/4.%20ScriptableObject/GameObjectList.md")]
    public class GameObjectListReference : ObservableListReference<GameObject>
    {

    }

}
