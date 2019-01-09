﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NormalBas;

namespace Tests {
    [TestFixture]
    public class UnitTest1 {
        [Test]
        [TestCase("01100010000100111001110011111111111110101100010011010111001010010100001100011110110001101010111110111111111110111101111010011011001100111100111111001111000000110000001010100101001100101000110001000101000001110111011110101001011011101", "10110111001000100010000011010111000101110101001011010011001001110011010010100001011010010100110011111100011011010000111000000100000011001101110111010010110001110100010000001001000100001011001011110001011001111001011010000001001000100", "11010101001100011011110000101000111011011001011000000100000011100111011110111111101011111110001101000011100101101101000010011111001111110001001000011101110001000100011010101100001000100011111010110100011000001110000100101000010011001")]
        [TestCase("11010000100010011101111111011010110001111010100011100001001001000100101011111111010101001011011010111101010100011101011001001101000011001011000111111110000010110000010001110111101011011111010010001101000100111001001010110101101100101", "00100011000001011100011000011110011000111100100011000001000111000111100100101001100010101111111000111111011000001100100100100001010000110011111010100000001010111011100000100000001001111010011101011111101000100100011001011110111110010", "11110011100011000001100111000100101001000110000000100000001110000011001111010110110111100100100010000010001100010001111101101100010011111000111101011110001000001011110001010111100010100101001111010010101100011101010011101011010010111")]
        [TestCase("10110100110001001100010000110010100100100110010001100101100101111010111111010101110000011010110111010110111010110100010101011101001000010011100110011111111010101111010010101111101110011111110000001100111011101000010110101010111011000", "11010111011010010101000100001001111100010110001100101010010110111000010111000100000100101110000000010010001111000100110010111011101001111000011000110101111111101011010001010000001010110110001000100011110101011011010110000111001000110", "01100011101011011001010100111011011000110000011101001111110011000010101000010001110100110100110111000100110101110000100111100110100001101011111110101010000101000100000011111111100100101001111000101111001110110011000000101101110011110")]
        public void AddTest(string a, string b, string expectedResult) {
            int[] p1 = new int[1];
            int[] p2 = new int[1];
            p1 = Program.StrToByt(a);
            p2 = Program.StrToByt(b);
            var actualResult = Program.BytToStr(Program.Add(p1, p2));
            Assert.AreEqual(expectedResult, actualResult);
        }

        
    }
}