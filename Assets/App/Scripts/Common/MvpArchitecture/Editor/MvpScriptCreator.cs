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
			Debug.Log("Create Mvp Script");
			//選択中のフォルダ全てに対して処理を行う
			foreach (var o in Selection.objects)
			{
				//ディレクトリパス
				var directoryPath = AssetDatabase.GetAssetPath(o);
				//フォルダかどうかを判定
				var isDirectory = File.GetAttributes(directoryPath).HasFlag(FileAttributes.Directory);

				if (isDirectory == false)
				{
					Debug.LogWarningFormat("選択中のオブジェクトはフォルダではありません, Path{0}", directoryPath);
					continue;
				}

				//半半角英字以外を抽出する正規表現
				var regex = new Regex(@"[^a-zA-Z]");
				//ディレクトリ名取得
				var directoryName = regex.Replace(directoryPath.Split('/').LastOrDefault(), "");
				//クラス名
				string className = directoryName;
				//設定ファイルを取得
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
					string saveDirectoryPath = directoryPath + "/" + fileName;
					//スクリプトファイルを生成
					File.WriteAllText(saveDirectoryPath, classTemplate, Encoding.UTF8);
				}
			}

			//refresh
			AssetDatabase.Refresh();
			//save
			AssetDatabase.SaveAssets();
		}
	}
}
