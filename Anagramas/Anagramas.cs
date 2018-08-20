using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagramas
{
    class Anagrama
    {

        public string source = "";
        public string[] dictionary = new string[0];
        public Word[] words;

        public Anagrama(string source)
        {
            this.source = source;
            LoadFile();
            words = new Word[dictionary.Length];
            ProcessWords();
        }

        public void LoadFile()
        {
            dictionary = System.IO.File.ReadAllLines(source);
        }
        
        public void ProcessWords()
        {
            for(int i = 0; i < words.Length; i++)
            {
                words[i] = new Word(dictionary[i]);
            }
        }

        public string[] find(string v)
        {
            List<string> result = new List<string>();
            Word main = new Word(v);
            foreach(Word w in words)
            {
                if (w.IsAnagramOf(main)) result.Add(w.word);
            }
            return result.ToArray();
        }
    }

    class Word
    {
        public string word;
        public int size = 0;
        public char[] letters = new char[0];

        public Word(string word)
        {
            this.word = word;
            size = word.Length;
            letters = word.ToCharArray();
        }

        public bool SameSizeAs(Word word)
        {
            return size == word.size;
        }

        public bool SameLettersAs(Word word)
        {
            int i = 0; //Indice de esta palabra
            int j = 0; //Indice de word
            while(j < word.size)
            {
                if ((i == word.size - 1) && word.letters[j] != letters[i])
                    return false;
                else if (word.letters[j] == letters[i]) {
                    j++;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            return true;
        }

        public bool IsAnagramOf(Word word)
        {
            if (!SameSizeAs(word)) return false;
            if (!SameLettersAs(word)) return false;
            return true;
        }
    }

}
