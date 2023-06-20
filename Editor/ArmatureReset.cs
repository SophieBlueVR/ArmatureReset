using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;


namespace SophieBlue.ArmatureReset.Editor {
    public class ArmatureResetWindow : EditorWindow
    {
        private Vector2 scroll;
        private VRCAvatarDescriptor _avatar;


        [MenuItem ("Tools/SophieBlue/Armature Reset")]
        public static void ShowWindow() {
            // Show existing window instance. If one doesn't exist, make one.
            var window = EditorWindow.GetWindow(typeof(ArmatureResetWindow));
            window.titleContent = new GUIContent("Armature Reset");
            window.Show();
        }

        private void Header() {
            GUIStyle styleTitle = new GUIStyle(GUI.skin.label);
            styleTitle.fontSize = 16;
            styleTitle.margin = new RectOffset(20, 20, 20, 20);
            EditorGUILayout.LabelField("Armature Reset", styleTitle);
            EditorGUILayout.Space();

            // show the version
            GUIStyle styleVersion = new GUIStyle(GUI.skin.label);
            EditorGUILayout.LabelField(Version.VERSION, styleVersion);
            EditorGUILayout.Space();
        }

        private void MainOptions() {
            _avatar = EditorGUILayout.ObjectField(
                "Avatar", _avatar, typeof(VRCAvatarDescriptor), true) as VRCAvatarDescriptor;
        }

        void OnGUI() {
            Header();

            scroll = EditorGUILayout.BeginScrollView(scroll);
            MainOptions();

            if (GUILayout.Button("Reset!")) {
                Apply();
            }

            EditorGUILayout.EndScrollView();
        }

        private void Apply() {

            if (! PrefabUtility.IsOutermostPrefabInstanceRoot(_avatar.gameObject)) {
                Debug.LogError("Avatar is not a prefab, can't reset it!");
                return;
            }

            // find the armature
            Transform armature = _avatar.transform.Find("Armature");

            // find the bones and map them to names
            List<Transform> boneList = new List<Transform>(armature.GetComponentsInChildren<Transform>());
            Dictionary<string, Transform> boneMap = new Dictionary<string, Transform>();

            boneList.ForEach(delegate(Transform bone) {
                boneMap.Add(bone.gameObject.name, bone);
            });

            // find the prefab overrides
            List<ObjectOverride> overrides = PrefabUtility.GetObjectOverrides(_avatar.gameObject, false);
            overrides.ForEach(delegate(ObjectOverride o) {
                if (boneMap.ContainsKey(o.instanceObject.name)) {
                    Debug.Log("resetting transform " + o.instanceObject.name);
                    o.Revert();
                }
            });
        }
    }
}
