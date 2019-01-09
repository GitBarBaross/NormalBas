using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalBas {
    public class Program {
        static void Main(string[] args) {

            string a = "01100010000100111001110011111111111110101100010011010111001010010100001100011110110001101010111110111111111110111101111010011011001100111100111111001111000000110000001010100101001100101000110001000101000001110111011110101001011011101";
            string b = "10110111001000100010000011010111000101110101001011010011001001110011010010100001011010010100110011111100011011010000111000000100000011001101110111010010110001110100010000001001000100001011001011110001011001111001011010000001001000100";
            string n = "00100000000011000101010101000010111010001111101010111110111101101110010010110011111001110101100000110100110000011110011011000111100101101100111100011110010111000010010010110010110001100000100100001110000001000001100011011001000011010";
            int[] p = new int[1];
            int[] p1 = new int[1];
            int[] p2 = new int[1];
            int[] p3 = new int[1];

            p1 = StrToByt(a);
            p2 = StrToByt(b);
            p3 = StrToByt(n);

            Console.WriteLine(BytToStr(Multi(p1, p2)));
            Console.WriteLine(BytToStr(SQ(p1)));

            Console.ReadKey();
        }

        public static int[] StrToByt(string a) {
            var bit = a.Length;
            int[] n = new int[bit];

            for (var i = 0; i < a.Length; i++) {
                n[a.Length - 1 - i] = Convert.ToByte(a.Substring(a.Length - (i + 1), 1), 2);
            }

            return n;
        }

        public static string BytToStr(int[] a) {
            StringBuilder b = new StringBuilder();

            for (int i = 0; i < a.Length; i++) {
                b.Append(Convert.ToString(a[i], 2));
            }

            return b.ToString();
        }

        public static int[] Add(int[] a, int[] b) {
            int max;
            if (a.Length < b.Length) { max = b.Length; }
            else { max = a.Length; };

            Array.Resize(ref a, max);
            Array.Resize(ref b, max);
            int[] res = new int[a.Length];

            for (int i = 0; i < a.Length; i++) {
                res[i] = (a[i] ^ b[i]);
            }

            return res;
        }

       

        public static int[] ToLeft(int[] a) {
            int[] result = new int[a.Length];
            for (int i = 1; i < a.Length; i++) {
                result[i - 1] = a[i];
            }


            result[a.Length - 1] = a[0];
            return result;
        }


        public static int Tr(int[] a) {
            int tr = 0;
            for (int i = 0; i < a.Length; i++)
                tr = tr ^ a[i];
            return tr;
        }

        

        public static int[,] Matrix(int a) {
            int p = 2 * a + 1;
            int[,] M = new int[a, a];
            int[] pow = new int[a];
            pow[0] = 1;  



            for (int i = 1; i < a; i++)
                pow[i] = (pow[i - 1] * 2) % p;



            int x, y;

            for (int i = 0; i < a; i++) {
                x = pow[i];
                for (int j = 0; j < a; j++) {
                    y = pow[j];
                    if ((((x - y) + p) % p) == 1 || ((x + y) % p) == 1 || (((-x - y) + p) % p) == 1 || ((y - x + p) % p) == 1) {
                        M[i, j] = 1;
                        continue;
                    }
                    M[i, j] = 0;
                }
            }
            return M;
        }

        public static int[] Multi(int[] a, int[] b) {
            int[] res = new int[a.Length];
            int[,] M = Matrix(a.Length);
            for (int n = 0; n < a.Length; n++) {
                int[] p = new int[a.Length];

                for (int j = 0; j < a.Length; j++) {
                    for (int i = 0; i < a.Length; i++)
                        p[j] = (p[j]) ^ (a[i] & M[i, j]);
                }

                int el = 0;

                for (int i = 0; i < a.Length; i++)
                    el = (el) ^ (p[i] & b[i]);
                res[n] = el;
                a = ToLeft(a);
                b = ToLeft(b);
            }

            return res;
        }

        public static int[] SQ(int[] a) {
            int[] res = new int[a.Length];
            for (int i = 0; i < a.Length - 1; i++) {
                res[i + 1] = a[i];
            }
            res[0] = a[a.Length - 1];
            return res;
        }



        public static int[] BP(int[] a, int[] n) {
            int[] res = new int[a.Length];
            string b = "11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";
            res = StrToByt(b);
            for (var i = a.Length - 1; i >= 0; i--) {
                if (n[i] == 1) {
                    res = Multi(res, a);
                }
                a = SQ(a);
            }
            return res;
        }

        public static int[] B(int[] a, int k) {
            int[] Beta = new int[a.Length];
            Beta = a;
            for (int i = 1; i <= k; i++) {
                Beta = SQ(Beta);
            }
            return Beta;
        }
        
        public static int[] Inv(int[] a) {

            string len = "11101000";
            int[] m = new int[len.Length];
            m = StrToByt(len);

            int q = 1;
            int[] b = new int[a.Length];
            b = a;

            for (int i = 1; i < len.Length; i++) {
                b = Multi(B(b, q), b);
                q = 2 * q;
                if (m[i] == 1) {
                    b = Multi(SQ(b), a);
                    q = q + 1;
                }
            }
            b = SQ(b);
            return b;
        }

    }
}
