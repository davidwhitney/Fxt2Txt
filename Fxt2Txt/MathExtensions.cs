namespace Fxt2Txt
{
    public static class MathExtensions
    {
        public static int Mod(this int x, int m) => (x % m + m) % m;
    }
}