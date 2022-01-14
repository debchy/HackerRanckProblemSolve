using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System;
namespace HackerRank
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World"[0]+(3%5).ToString());
            checkMagazine(new List<string>{"give", "me", "one", "grand", "today", "night"},
            new List<string>{"give", "one", "today", "night"});
        }
        
        /* checkMagazine    * https://www.hackerrank.com/challenges/ctci-ransom-note/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        * Complete the 'checkMagazine' function below.
        *
        * The function accepts following parameters:
        *  1. STRING_ARRAY magazine
        *  2. STRING_ARRAY note
        */

        public static void checkMagazine(List<string> magazine, List<string> note)
        {
            var answer="Yes";
            Dictionary<string, int> note_dic=new Dictionary<string, int>();
            Dictionary<string, int> mag_dic=new Dictionary<string, int>();
            // foreach(string word in note){
            //     if(!note_dic.ContainsKey(word))note_dic[word]=1; else note_dic[word]++;            
            // }
            note.ForEach(word=>{
                if(!note_dic.ContainsKey(word))note_dic[word]=1; else note_dic[word]++;            
            });
            foreach(string word in magazine){
                if(!mag_dic.ContainsKey(word))mag_dic[word]=1; else mag_dic[word]++;            
            }

            foreach (var word in note)
            {
                if (note_dic[word] > (!mag_dic.ContainsKey(word)?0:mag_dic[word]))
                {
                    answer="No";
                    break;
                }   
            }
            Console.WriteLine( answer);
        }


        /*twoStrings: https://www.hackerrank.com/challenges/two-strings/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        * Complete the 'twoStrings' function below.
        *
        * The function is expected to return a STRING.
        * The function accepts following parameters:
        *  1. STRING s1
        *  2. STRING s2
        */

        public static string twoStrings(string s1, string s2)
        {
            string res="NO";
            var aint=Convert.ToInt32('a');
            var zint=Convert.ToInt32('z');
            
            for(int i=aint;i<=zint;i++){
                char c=Convert.ToChar(i);
                if(s1.IndexOf(c)!=-1 && s2.IndexOf(c)!=-1)return "YES";
            }
        
            return res;
        }

    }

}