using NUnit.Framework;
using UnityEditor.SceneManagement;

public class TestSetup
{

    [SetUp]
    public static void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

}
