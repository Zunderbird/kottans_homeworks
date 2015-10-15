
using System;

namespace MatrixAlgorithms
{
    public class CoolMatrix
    {
        private readonly int[,] _mMatrix;

        public Size Size{ get; }

        public bool IsSquare { get; }

        public CoolMatrix(int[,] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();

            Size = new Size(matrix.GetUpperBound(0) + 1, matrix.GetUpperBound(1) + 1);

            _mMatrix = new int[Size.Width, Size.Height];

            for (var i = 0; i < Size.Width; i++)
            {
                for (var j = 0; j < Size.Height; j++)
                {
                    _mMatrix[i, j] = matrix[i, j];
                }
            }
            IsSquare = Size.IsSquare;
        }

        public int this[int x, int y]
        {
            get { return _mMatrix[x, y]; }
            set { _mMatrix[x, y] = value; }
        }

        public CoolMatrix Transpose()
        {
            var tempMatrix = new int[Size.Height, Size.Width];

            for (var i = 0; i < Size.Width; i++)
            {
                for (var j = 0; j < Size.Height; j++)
                {
                    tempMatrix[j, i] = this[i, j];
                }
            }
            return new CoolMatrix(tempMatrix);
        }

        public static implicit operator CoolMatrix(int[,] matrix)
        {
            return new CoolMatrix(matrix);
        }

        public static implicit operator int[,](CoolMatrix matrix)
        {
            var tempMatrix = new int[matrix.Size.Width, matrix.Size.Height];

            for (var i = 0; i < matrix.Size.Width; i++)
            {
                for (var j = 0; j < matrix.Size.Height; j++)
                {
                    tempMatrix[i, j] = matrix[i, j];
                }
            }
            return tempMatrix;
        }

        public static CoolMatrix operator +(CoolMatrix leftMatrix, CoolMatrix rightMatrix)
        {
            if (leftMatrix.Size != rightMatrix.Size) throw new ArgumentException();

            var tempMatrix = new CoolMatrix(leftMatrix);

            for (var i = 0; i < leftMatrix.Size.Width; i++)
            {
                for (var j = 0; j < leftMatrix.Size.Height; j++)
                {
                    tempMatrix[i, j] += rightMatrix[i, j];
                }
            }
            return tempMatrix;
        }

        public static CoolMatrix operator -(CoolMatrix leftMatrix, CoolMatrix rightMatrix)
        {
            if (leftMatrix.Size != rightMatrix.Size) throw new ArgumentException();

            var tempMatrix = new CoolMatrix(leftMatrix);

            for (var i = 0; i < leftMatrix.Size.Width; i++)
            {
                for (var j = 0; j < leftMatrix.Size.Height; j++)
                {
                    tempMatrix[i, j] -= rightMatrix[i, j];
                }
            }
            return tempMatrix;
        }

        public static CoolMatrix operator *(CoolMatrix matrix, int number)
        {
            var tempMatrix = new CoolMatrix(matrix);

            for (var i = 0; i < matrix.Size.Width; i++)
            {
                for (var j = 0; j < matrix.Size.Height; j++)
                {
                    tempMatrix[i, j] *= number;
                }
            }
            return tempMatrix;
        }

        public static CoolMatrix operator /(CoolMatrix matrix, int number)
        {
            var tempMatrix = new CoolMatrix(matrix);

            for (var i = 0; i < matrix.Size.Width; i++)
            {
                for (var j = 0; j < matrix.Size.Height; j++)
                {
                    tempMatrix[i, j] /= number;
                }
            }
            return tempMatrix;
        }

        public static bool operator ==(CoolMatrix leftMatrix, CoolMatrix rightMatrix)
        {
            if (leftMatrix.Size != rightMatrix.Size) return false;

            for (var i = 0; i < leftMatrix.Size.Width; i++)
            {
                for (var j = 0; j < leftMatrix.Size.Height; j++)
                {
                    if (leftMatrix[i, j] != rightMatrix[i, j]) return false;
                }
            }
            return true;
        }

        public static bool operator !=(CoolMatrix leftMatrix, CoolMatrix rightMatrix)
        {
            return !(leftMatrix == rightMatrix);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CoolMatrix)) return false;
            var comp = (CoolMatrix)obj;

            return comp == this;
        }

        public override string ToString()
        {
            var text = "";

            for (var i = 0; i < Size.Width; i++)
            {
                text += "[";
                for (var j = 0; j < Size.Height; j++)
                {
                    text += _mMatrix[i, j].ToString();
                    if (j != Size.Height - 1) text += ", ";
                }
                text += "]";
                if (i != Size.Width - 1) text += $@"{Environment.NewLine}";
            }
            return text;
        }
    }
}
