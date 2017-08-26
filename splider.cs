using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

public class Splider{
    public static List<(string,string)> GetArticlesTop10() {
            var webRequest = HttpWebRequest.Create("http://www.yinwang.org/");
            var response = webRequest.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var listContent = sr.ReadToEnd();
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