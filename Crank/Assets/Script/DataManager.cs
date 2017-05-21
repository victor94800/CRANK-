using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager
{
	public static void Save(object entity , string filename , string pathname)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = File.Create(pathname + "/" + filename);
		formatter.Serialize(stream, entity);
		stream.Close();
	}
	public static object Load(string filename, string pathname)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = File.Open(pathname + "/" + filename , FileMode.Open);
		Datas entity = (Datas)formatter.Deserialize(stream);
		formatter.Serialize(stream, entity);
		stream.Close();
		return entity;
	}
	
}
