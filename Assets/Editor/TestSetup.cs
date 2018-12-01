using NUnit.Framework;
using UnityEditor.SceneManagement;

public class TestSetup
{

    [SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

}
