using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThinkLib;

namespace MyStringsPartB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        char lower(char x)
        {
            switch (x)
            {
                case 'A': return 'a';
                case 'B': return 'b';
                case 'C': return 'c';
                case 'D': return 'd';
                case 'E': return 'e';
                case 'F': return 'f';
                case 'G': return 'g';
                case 'H': return 'h';
                case 'I': return 'i';
                case 'J': return 'j';
                case 'K': return 'k';
                case 'L': return 'l';
                case 'M': return 'm';
                case 'N': return 'n';
                case 'O': return 'o';
                case 'P': return 'p';
                case 'Q': return 'q';
                case 'R': return 'r';
                case 'S': return 's';
                case 'T': return 't';
                case 'U': return 'u';
                case 'V': return 'v';
                case 'W': return 'w';
                case 'X': return 'x';
                case 'Y': return 'y';
                case 'Z': return 'z';
                default: return x;
            }
        }
        char upper(char x)
        {
            switch (x)
            {
                case 'a': return 'A';
                case 'b': return 'B';
                case 'c': return 'C';
                case 'd': return 'D';
                case 'e': return 'E';
                case 'f': return 'F';
                case 'g': return 'G';
                case 'h': return 'H';
                case 'i': return 'I';
                case 'j': return 'J';
                case 'k': return 'K';
                case 'l': return 'L';
                case 'm': return 'M';
                case 'n': return 'N';
                case 'o': return 'O';
                case 'p': return 'P';
                case 'q': return 'Q';
                case 'r': return 'R';
                case 's': return 'S';
                case 't': return 'T';
                case 'u': return 'U';
                case 'v': return 'V';
                case 'w': return 'W';
                case 'x': return 'X';
                case 'y': return 'Y';
                case 'z': return 'Z';
                default: return x;
            }
        }

        int length(string s)
        {
            int count = 0;
            foreach (char x in s)
            {
                count++;
            }
            return count;
        }

        bool contains(string s, string subs)
        {
            int num = indexOf(s, subs);
            if (num > -1) return true;
            else return false;
        }

        int indexOf(string s, string subs)
        {
            if (length(s) < length(subs)) return -1;
            string testWord = "";
            int i = 0;
            int count = length(subs);// length of subs
            while (testWord != subs)
            {
                while (i < length(s))// loop to find pos of subs[0] in s
                {
                    if (s[i] == subs[0]) break;
                    i++;
                    if (i == length(s))
                    {
                        i--;
                        return -1;
                    }
                }
                int clone = i;
                testWord += s[i];
                if (count > 1)
                {
                    while (i < count + length(s))
                    {
                        testWord += s[clone];
                        clone++;
                    }
                }
                if (testWord == subs)
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }
            return -1;
        }

        string insertSubString(string s, string x, int pos)
        {
            if (pos > length(s)) return "";
            string output = "";
            int i = 0;
            while (i < pos)
            {
                output += s[i];
                i++;
            }
            foreach (char letter in x)
            {
                output += letter;
            }
            while (i < length(s))
            {
                output += s[i];
                i++;
            }
            return output;
        }

        string replaceSubString(string s, string newString, string old)
        {
            int pos = indexOf(s, old);
            string outword = "";
            int i = 0;
            while (i < pos)
            {
                outword += s[1];
                i++;
            }
            foreach (char letter in newString)
            {
                outword += letter;
            }
            i = i + length(old);
            while (i < length(s))
            {
                outword += s[i];
                i++;
            }
            return outword;
        }

        string deleteSubString(string s, string subs)
        {
            int pos = indexOf(s, subs);
            string outword = "";
            int i = 0;
            while (i < pos)
            {
                outword += s[1];
                i++;
            }
            i = i + length(subs);
            while (i < length(s))
            {
                outword += s[i];
                i++;
            }
            return outword;
        }

        List<string> split(string s, char c)
        {
            List<string> output = new List<string>();
            string item = "";
            int i = 0;
            while (i < length(s))
            {
                if (s[i] != c)
                {
                    item += s[i];
                }
                else
                {
                    output.Add(item);
                    item = "";
                }
                i++;
            }
            if (length(item) > 0)
            {
                output.Add(item);
            }
            return output;
        }

        int stringCompare(string s1, string s2)
        {
            int i = 0;
            int num1 = Convert.ToInt32(s1[i]);
            int num2 = Convert.ToInt32(s2[i]);
            while (true)
            {
                if (num1 < num2) return -1;
                else if (num1 > num2) return 1;
                else return 0;
            }
        }

        string toLower(string s)
        {
            string output = "";
            foreach (char letter in s)
            {
                output += lower(letter);
            }
            return output;
        }

        string toUpper(string s)
        {
            string output = "";
            foreach (char letter in s)
            {
                output += upper(letter);
            }
            return output;
        }

        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            Tester.TestEq(length("xxx"), 3);
            Tester.TestEq(contains("xxyxx", "y"), true);
            Tester.TestEq(indexOf("xxyxx", "y"), 2);
            Tester.TestEq(insertSubString("xxxx", "y", 2), "xxyxx");
            Tester.TestEq(replaceSubString("xxyxx", "ooo", "y"), "xxoooxx");
            Tester.TestEq(deleteSubString("xxyxx", "y"), "xxxx");
            Tester.TestEq(split("x xx xxx", ' '), new List<string>() { "x", "xx", "xxx" });
            Tester.TestEq(stringCompare("xxx", "xxx"), 0);
            Tester.TestEq(toLower("HeLLo"), "hello");
            Tester.TestEq(toUpper("HeLLo"), "HELLO");
        }
    }
}
