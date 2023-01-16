using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ClothStore
{
    public static class EditorUtils
    {
       	[MenuItem("Tools/Switch scene/Main %#W")]
       	static void SwitchSplashScene()
       	{
       		EditorSceneManager.OpenScene($"Assets/Scenes/Main.unity");
       	}
    }
}
