using NUnit.Framework;
using UnityEditor.SceneManagement;

namespace CandyCoded.Tests
{

    public class TestSetup
    {

        [SetUp]
        protected void ResetScene()
        {

            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

        }

    }

}
