
namespace MatrixAlgorithms
{
    public struct Size
    {
        private static int _mSize;

        public int Width { get; }
        public int Height { get; }
        public bool IsSquare { get; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
            IsSquare = (Width == Height);
            _mSize = Width*Height;
        }

        public static implicit operator int (Size size)
        {
            return _mSize;
        }

        public static bool operator == (Size left, Size right)
        {
            return (left.Width == right.Width && left.Height == right.Height);
        }

        public static bool operator !=(Size left, Size right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Size)) return false;
            var comp = (Size) obj;

            return comp == (int)this;
        }

        public override int GetHashCode()
        {
            return Width ^ Height;
        }
    }
}
