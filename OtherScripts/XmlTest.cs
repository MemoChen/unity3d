///
///unity中如何将object序列化成xml字符串并保存
///


using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Xml.Serialization;



public class XmlTest {

    /// <summary>
    /// 读取xml文件并反序列化
    /// </summary>
    /// <param name="type"></param>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static object LoadFromXml(System.Type type,string filename)
    {
        XmlReader xRead = new XmlTextReader(filename);
        XmlSerializer sl = new XmlSerializer(type);
        object obj = sl.Deserialize(xRead);
        xRead.Close();
        return obj;
    }
    /// <summary>
    /// 序列化并存储xml文件
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="type"></param>
    /// <param name="target"></param>
    public static void SaveToXml(string filename,System.Type type,object target)
    {
        XmlTextWriter xWrite = new XmlTextWriter(filename,null);
        XmlSerializer sl = new XmlSerializer(type);
        sl.Serialize(xWrite,target);
        xWrite.Close();
    }
}
