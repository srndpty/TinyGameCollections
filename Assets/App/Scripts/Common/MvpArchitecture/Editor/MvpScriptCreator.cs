using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace TinyGameCollections
{
	/// <summary>
	/// Mvpスクリプト自動生成用のEditorクラス
	/// </summary>
	public static class MvpScriptCreator
	{
		[MenuItem("Assets/Create/Create MVP Scripts")]
		private static void CreateMvpScript()
		{
			Debug.Log("Creating Mvp Script");
			// 選択中のフォルダ全てに対して処理を行う
			foreach (var obj in Selection.objects)
			{
				//ディレクトリパス
				var directoryPath = AssetDatabase.GetAssetPath(obj);
				//フォルダかどうかを判定
				var isDirectory = File.GetAttributes(directoryPath).HasFlag(FileAttributes.Directory);

				if (isDirectory == false)
				{
					Debug.LogWarning($"`{directoryPath}`はフォルダではありません");
					continue;
				}

				// 半角英字以外を除去する
				var regex = new Regex(@"[^a-zA-Z]");
				var directoryName = regex.Replace(directoryPath.Split('/').LastOrDefault(), "");
				string className = directoryName;
				var settings = MvpSettings.Instance;

				if (settings == null)
				{
					Debug.LogError("Setting file is Null");
					return;
				}

				//テンプレートの文字列を置換
				foreach (TextAsset template in settings.Templates)
				{
					string fileName = template.name.Replace("#CLASS_NAME#", className) + ".cs";
					string classTemplate = template.text;
					classTemplate = classTemplate.Replace("#CLASS_NAME#", className);
					classTemplate = classTemplate.Replace("#NAMESPACE#", typeof(MvpScriptCreator).Namespace);
					string saveDirectoryPath = $"{directoryPath}/{fileName}";
					//スクリプトファイルを生成
					File.WriteAllText(saveDirectoryPath, classTemplate, Encoding.UTF8);
				}
			}

			AssetDatabase.Refresh();
			AssetDatabase.SaveAssets();
		}
	}
}
