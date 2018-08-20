using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagramas
{
    [TestClass]
    public class UnitTest1
    {

        /*
         *Casos de prueba
         * - hector
         * - acosta
         * - pozo
         * - hardtops
         * - potshard
         * - hardwood
         * - SourceFile: wordlist.txt
         * - SourceFile: word.txt
         * - SourceFile: testWordList.txt
         * - crepitus (crepitus cuprites pictures piecrust)
         * 
         */

        [TestMethod]
        public void PassFile()
        {
            Anagrama anagrama = new Anagrama("wordlist.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void PassFileWrong()
        {
            Anagrama anagrama = new Anagrama("word.txt");
        }

        [TestMethod]
        public void ProccessWords()
        {
            Anagrama anagrama = new Anagrama("testWordList.txt");
            Assert.AreEqual("hector", anagrama.dictionary[0]);
        }

        [TestMethod]
        public void ProccessWordsObjects()
        {
            Anagrama anagrama = new Anagrama("testWordList.txt");
            Word word = new Word("hector");
            Assert.AreEqual(word.word, anagrama.words[0].word);
        }

        [TestMethod]
        public void GetAnagrams()
        {
            Anagrama anagrama = new Anagrama("wordlist.txt");
            string[] expectedList = new string[] { "crepitus", "cuprites", "pictures", "piecrust" };
            CollectionAssert.AreEqual(expectedList, anagrama.find("crepitus"));
        }





        [TestMethod]
        public void GetSize()
        {
            Word word = new Word("Hector");
            Assert.AreEqual(6, word.size);
        }

        [TestMethod]
        public void GetLetters()
        {
            char[] letters = new char[6] { 'H', 'e', 'c', 't', 'o', 'r' };
            Word word = new Word("Hector");
            CollectionAssert.AreEqual(letters, word.letters);
        }

        [TestMethod]
        public void CompareWordSizesGood()
        {
            Word word1 = new Word("Hector");
            Word word2 = new Word("Acosta");
            Assert.IsTrue(word1.SameSizeAs(word2));
        }

        [TestMethod]
        public void CompareWordSizesBad()
        {
            Word word1 = new Word("Hector");
            Word word2 = new Word("Pozo");
            Assert.IsFalse(word1.SameSizeAs(word2));
        }

        [TestMethod]
        public void CompareLettersGood()
        {
            Word word1 = new Word("hardtops");
            Word word2 = new Word("potshard");
            Assert.IsTrue(word1.SameLettersAs(word2));
        }

        [TestMethod]
        public void CompareLettersBad()
        {
            Word word1 = new Word("hardtops");
            Word word2 = new Word("hardwood");
            Assert.IsFalse(word1.SameLettersAs(word2));
        }

        [TestMethod]
        public void IsAnagram()
        {
            Word word1 = new Word("hardtops");
            Word word2 = new Word("potshard");
            Assert.IsTrue(word1.IsAnagramOf(word2));
        }

        [TestMethod]
        public void IsNotAnagram()
        {
            Word word1 = new Word("hardtops");
            Word word2 = new Word("hardwood");
            Assert.IsFalse(word1.IsAnagramOf(word2));
        }



    }
}
