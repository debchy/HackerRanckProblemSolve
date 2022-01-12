using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System;

public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World"[0]+(3%5).ToString());
        Console.WriteLine(checkMagazine(new List<string>{"give", "me", "one", "grand", "today", "night"},
        new List<string>{"give", "one", "today", "night"}));
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
        foreach(string word in note){
            if(!note_dic.ContainsKey(word))note_dic[word]=1; else note_dic[word]++;            
        }
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

}