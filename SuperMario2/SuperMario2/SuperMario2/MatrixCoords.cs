namespace SuperMario2
{
    using System;

    public struct MatrixCoords
    {
        public MatrixCoords(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }

        public static MatrixCoords operator +(MatrixCoords a, MatrixCoords b)
        {
            return new MatrixCoords(a.Row + b.Row, a.Col + b.Col);
        }

        public static MatrixCoords operator -(MatrixCoords a, MatrixCoords b)
        {
            return new MatrixCoords(a.Row - b.Row, a.Col - b.Col);
        }

        public override bool Equals(object obj)
        {
            MatrixCoords objAsMatrixCoords = (MatrixCoords)obj;

            return objAsMatrixCoords.Row == this.Row && objAsMatrixCoords.Col == this.Col;
        }

        public override int GetHashCode()
        {
            return this.Row.GetHashCode() * 7 + this.Col;
        }
    }
}
