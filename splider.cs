using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

public class Splider{
    private static String ListContent() {
         var webRequest = HttpWebRequest.Create("http://www.yinwang.org/");
        var response = webRequest.GetResponse();
        var stream = response.GetResponseStream();
        var listContent = string.Empty;
        using( StreamReader sr = new StreamReader(stream) ) {
            listContent = sr.ReadToEnd();
        }
        return listContent;
    }

    public static List<(string,string)> GetArticlesTop10() {
            var listContent =ListContent();
            var regex = new Regex("<li class=\"list-group-item title\">[\\s\\S]+?href=\\\"([^\"]+)\\\">([^<]+)");
            var matches = regex.Matches(listContent);
            var result = new List<(string,string)>();
            foreach(Match match in matches) {
                if( match.Groups.Count == 3) {
                    var title = match.Groups[1].Value;
                    var url = match.Groups[2].Value;
                    result.Add((title,url));
                }
            }
            return result;
    }
}