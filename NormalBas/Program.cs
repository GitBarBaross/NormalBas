using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalBas {
    public class Program {
        static void Main(string[] args) {


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

        public static int[] ShiftBitToR(int[] a)
        {
            int[] res = new int[a.Length];
            for (int i = 0; i < a.Length - 1; i++) {
                res[i + 1] = a[i];
            }
            res[0] = a[a.Length - 1];
            return res;
        }

        public static int Tr(int[] a) {
            int tr = 0;
            for (int i = 0; i < a.Length; i++)
                tr = tr ^ a[i];
            return tr;
        }

       

    }
}
