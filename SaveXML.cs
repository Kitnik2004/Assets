/// <summary>
/// Save XML.
/// Разработанно командой Sky Games
/// sgteam.ru
/// </summary>
using UnityEngine;
using System.Collections;
using System.Xml;

public class SaveXML : MonoBehaviour {
	
	void OnGUI () {
		if(GUI.Button(new Rect(0, 0, 100, 100), "Save")) {
			XmlDocument xmlDoc = new XmlDocument();
			XmlNode rootNode = xmlDoc.CreateElement("Information");
			xmlDoc.AppendChild(rootNode);

			XmlNode userNode;
		
			userNode = xmlDoc.CreateElement("Element1");
			userNode.InnerText = "Text1";
			rootNode.AppendChild(userNode);
		
			userNode = xmlDoc.CreateElement("Element2");
			userNode.InnerText = "Text2";
			rootNode.AppendChild(userNode);
		
			userNode = xmlDoc.CreateElement("Element3");
			userNode.InnerText = "Text3";
			rootNode.AppendChild(userNode);

			xmlDoc.Save("Data/Save.xml");
		}
		
		if(GUI.Button(new Rect(110, 0, 100, 100), "Load")) {
			XmlTextReader reader = new XmlTextReader("Data/Save.xml");
			while (reader.Read()) {
				if (reader.IsStartElement("Element1") && !reader.IsEmptyElement) {
					Debug.Log(reader.ReadString());
				}
			}
			reader.Close();
		}
		
		if(GUI.Button(new Rect(220, 0, 100, 100), "Replace")) {
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load("Data/Save.xml");
			xmlDoc.SelectSingleNode("Information/Element1").InnerText = "NewElement";
			xmlDoc.Save("Data/Save.xml");
		}
	}
}
