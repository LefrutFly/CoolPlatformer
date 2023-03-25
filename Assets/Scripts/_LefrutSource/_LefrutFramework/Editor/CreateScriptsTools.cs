using System.IO;
using UnityEditor;
using UnityEngine;

namespace Lefrut
{
    public class CreateScriptsTools : EditorWindow
    {
        enum TypeOfScript
        {
            Entity,
            System,
            DataWithProvider,
            Effect,
        }

        string className = "NewClass";
        TypeOfScript type;
        string path = "";
        string fullPath;


        [MenuItem("Lefrut/Scripts")]
        public static void OpenCreateScriptWindow()
        {
            var window = EditorWindow.GetWindow(typeof(CreateScriptsTools));
            window.minSize = new Vector2(300, 150);
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("LEFRUT FRAMEWORK", EditorStyles.boldLabel);
            GUILayout.Label("create script", EditorStyles.boldLabel);

            className = EditorGUILayout.TextField("Class name: ", className);

            type = (TypeOfScript)EditorGUILayout.EnumPopup("Type: ", type);

            if (GUILayout.Button("Select path", GUILayout.Width(100)))
            {
                path = EditorUtility.OpenFolderPanel("Select directory for new class", "", "");
            }

            GUILayout.Label($"path: {path}/", EditorStyles.boldLabel);

            if (GUILayout.Button("Create File", GUILayout.Width(100)))
            {
                CreateFile();
            }
        }

        private void CreateFile()
        {
            if (type == TypeOfScript.Entity)
            {
                CreateEntityClass();
            }
            else if (type == TypeOfScript.System)
            {
                CreateSystemClass();
            }
            else if (type == TypeOfScript.DataWithProvider)
            {
                CreateDataWithProviderClass();
            }
            else if (type == TypeOfScript.Effect)
            {
                CreateEffectClass();
            }
        }

        private void CreateEntityClass()
        {
            fullPath = path + "/" + className + ".cs";

            if (!File.Exists(fullPath))
            {
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    sw.WriteLine("using Lefrut.Framework;");
                    sw.WriteLine();
                    sw.WriteLine($"public class {className} : Entity");
                    sw.WriteLine("{");
                    sw.WriteLine("\t//public SYSTEM_TYPE NAME { get; private set; } = new SYSTEM_TYPE();");
                    sw.WriteLine();
                    sw.WriteLine();
                    sw.WriteLine("\tprotected override void InitData()");
                    sw.WriteLine("\t{");
                    sw.WriteLine("\t\t//AddData(NAME);");
                    sw.WriteLine("\t}");
                    sw.WriteLine();
                    sw.WriteLine("\tprotected override void InitSystems()");
                    sw.WriteLine("\t{");
                    sw.WriteLine("\t\t//AddSystem(NAME);");
                    sw.WriteLine("\t}");
                    sw.WriteLine("}");
                    sw.Close();
                }

                AssetDatabase.Refresh();

                Debug.Log(className + " entity class was created at " + fullPath);
            }
            else
            {
                Debug.LogError("Entity class " + className + " already exists at " + fullPath);
            }
        }

        private void CreateSystemClass()
        {
            fullPath = path + "/" + className + "System" + ".cs";

            if (!File.Exists(fullPath))
            {
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    sw.WriteLine("using Lefrut.Framework;");
                    sw.WriteLine();
                    sw.WriteLine($"public class {className}System : BaseSystem");
                    sw.WriteLine("{");
                    sw.WriteLine("\tpublic override void AddProviders()");
                    sw.WriteLine("\t{");
                    sw.WriteLine("\t\t//NeededProviders.Set(new PROVIDER_TYPE(), this);");
                    sw.WriteLine("\t}");
                    sw.WriteLine();
                    sw.WriteLine("\t//public void DO()");
                    sw.WriteLine("\t//{");
                    sw.WriteLine("\t//\t((DATA)Providers.Get<PROVIDER>().Data).Data");
                    sw.WriteLine("\t//}");
                    sw.WriteLine("}");
                    sw.Close();
                }

                AssetDatabase.Refresh();

                Debug.Log(className + " system class was created at " + fullPath);
            }
            else
            {
                Debug.LogError("System class " + className + " already exists at " + fullPath);
            }
        }

        private void CreateDataWithProviderClass()
        {
            fullPath = path + "/" + className + "Data" + ".cs";

            var dataTypeName = className + "Data";

            if (!File.Exists(fullPath))
            {
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    sw.WriteLine("using Lefrut.Framework;");
                    sw.WriteLine();
                    sw.WriteLine($"public class {className}Data : IData");
                    sw.WriteLine("{");
                    sw.WriteLine("\t//public TYPE NAME;");
                    sw.WriteLine("}");
                    sw.Close();
                }
                AssetDatabase.Refresh();

                Debug.Log(className + " data class was created at " + fullPath);
            }
            else
            {
                Debug.LogError("Data class " + className + " already exists at " + fullPath);
            }

            fullPath = path + "/" + className + "Provider" + ".cs";

            var nameDataVariable = dataTypeName;
            if (!string.IsNullOrEmpty(nameDataVariable))
            {
                nameDataVariable = char.ToLower(nameDataVariable[0]) + nameDataVariable.Substring(1);
            }

            if (!File.Exists(fullPath))
            {
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    sw.WriteLine("using Lefrut.Framework;");
                    sw.WriteLine("using UnityEngine;");
                    sw.WriteLine();
                    sw.WriteLine($"public class {className}Provider : MonoProvider");
                    sw.WriteLine("{");
                    sw.WriteLine($"\t[SerializeField] private {dataTypeName} {nameDataVariable};");
                    sw.WriteLine($"\tpublic override IData Data => {nameDataVariable};");
                    sw.WriteLine("}");
                    sw.Close();
                }
                AssetDatabase.Refresh();

                Debug.Log(className + " provider class was created at " + fullPath);
            }
            else
            {
                Debug.LogError("Provider class " + className + " already exists at " + fullPath);
            }
        }

        private void CreateEffectClass()
        {
            fullPath = path + "/" + className + ".cs";

            if (!File.Exists(fullPath))
            {
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    sw.WriteLine("using Lefrut.Framework;");
                    sw.WriteLine("using System;");
                    sw.WriteLine();
                    sw.WriteLine($"public class {className} : IEffect");
                    sw.WriteLine("{");
                    sw.WriteLine("\tpublic void StartEffect(Entity entity, Action callback = null)");
                    sw.WriteLine("\t{");
                    sw.WriteLine("\t\t// TODO: How the effect starts");
                    sw.WriteLine("\t\t// callback?.Invoke();");
                    sw.WriteLine("\t}");
                    sw.WriteLine();
                    sw.WriteLine("\tpublic void StopEffect(Action callback = null)");
                    sw.WriteLine("\t{");
                    sw.WriteLine("\t\t// TODO: How the effect ends");
                    sw.WriteLine("\t\t// callback?.Invoke();");
                    sw.WriteLine("\t}");
                    sw.WriteLine("}");
                    sw.Close();
                }

                AssetDatabase.Refresh();

                Debug.Log(className + " effect class was created at " + fullPath);
            }
            else
            {
                Debug.LogError("Effect class " + className + " already exists at " + fullPath);
            }
        }
    }
}