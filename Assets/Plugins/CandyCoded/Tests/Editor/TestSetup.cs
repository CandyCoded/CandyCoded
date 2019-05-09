using NUnit.Framework;
using UnityEditor.SceneManagement;

namespace CandyCoded.Tests
{

    public class TestSetup
    {

        [SetUp]
        protected static void ResetScene()
        {

            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

        }

    }

}
