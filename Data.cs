using System.Xml;
using System.Collections.Generic;
using System;

public class Data
{
    private static XmlDocument GetSrc()
    {
        var doc = new XmlDocument();
        doc.Load("data.xml");
        return doc;
    }

    public static void Add( String title, String url ) {
        var doc = GetSrc();
        var newNode = doc.CreateElement("article");
        var titleAttr = doc.CreateAttribute("title");
        titleAttr.Value = title;
        var urlAttr = doc.CreateAttribute("url");
        urlAttr.Value = url;
        newNode.Attributes.Append(titleAttr);
        newNode.Attributes.Append(urlAttr);
        doc.DocumentElement.AppendChild(newNode);
        doc.Save("data.xml");
    }

    public static List<(string, string)> GetArticles()
    {
        var result = new List<(string, string)>();
        var doc = GetSrc();
        var articleNodes = doc.GetElementsByTagName("article");
        foreach (XmlNode node in articleNodes)
        {
            var title = node.Attributes["title"].Value;
            var url = node.Attributes["url"].Value;
            result.Add((title, url));
        }
        return result;
    }
}