using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Markup;

namespace Cinnabar.GameMath
{
    using IColumnMatrix = IMatrix<Vector2, Vector1, Vector2>;
    using IRowMatrix = IMatrix<Vector2, Vector2, Vector1>;

    public struct Vector2:
        IVector<Vector2>,
        IColumnMatrix,
        IRowMatrix
    {
        private static readonly MatrixOrder _columnMatrixOrder = new MatrixOrder(2, 1);
        private static readonly MatrixOrder _rowMatrixOrder = new MatrixOrder(1, 2);

        private float _x;
        private float _y;
        private double _magnitude;
        private bool _isMagnitudeDirty = true;

        public float X {
            get => _x;
            set {
                _isMagnitudeDirty = value != _x;
                _x = value;
            }
        }

        public float Y {
            get => _y;
            set {
                _isMagnitudeDirty = value != _y;
                _y = value;
            }
        }

        public double Magnitude {
            get {
                if (_isMagnitudeDirty) {
                    UpdateMagnitude();
                    _isMagnitudeDirty = false;
                }

                return _magnitude;
            }
        }

        public ReadOnlyCollection<float> Components => new float[] { _x, _y }.AsReadOnly();

        public int Dimension => 2;

        MatrixOrder IColumnMatrix.Order => _columnMatrixOrder;

        float IColumnMatrix.this[int column, int row] {
            get {
                ArgumentOutOfRangeException.ThrowIfNotEqual(column, 0, nameof(column));
                return this[row];
            }
            
            set {
                ArgumentOutOfRangeException.ThrowIfNotEqual(column, 0, nameof(column));
                this[row] = value;
            }
        }
        
        MatrixOrder IRowMatrix.Order => _rowMatrixOrder;

        float IRowMatrix.this[int column, int row] {
            get {
                ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0, nameof(row));
                return this[column];
            }
            
            set {
                ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0, nameof(row));
                this[row] = value;
            }
        }

        public float this[int index]
        {
            get {
                return index switch {
                    0 => _x,
                    1 => _y,
                    _ => throw new IndexOutOfRangeException()
                };
            }
            set {
                if (index == 0) _x = value;
                else if (index == 1) _y = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public Vector2(Vector2 other)
            :this(other.X, other.Y)
        {}

        private void UpdateMagnitude()
        {
            var square = Math.FusedMultiplyAdd(_x, _x, _y * _y);
            var root = Math.ReciprocalSqrtEstimate(square);
            _magnitude = root * square;
        }

        public Vector2 Add(Vector2 other)
        {
            return new Vector2(
                _x + other.X,
                _y + other.Y);
        }

        public Vector2 Subtract(Vector2 other)
        {
            return new Vector2(
                _x - other.X,
                _y - other.Y);
        }

        public Vector2 Multiply(float scalar)
        {
            return new Vector2(
                _x * scalar,
                _y * scalar);
        }

        public Vector2 Divide(float scalar)
        {
            return new Vector2(
                _x / scalar,
                _y / scalar);
        }

        public float Dot(Vector2 other)
        {
            return this.X * other.X + this.Y * other.Y;
        }

        public Vector2 Negate()
        {
            return new Vector2(-_x, -_y);
        }

        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }

        Vector2 IColumnMatrix.Column(int column)
        {
            ArgumentOutOfRangeException.ThrowIfNotEqual(column, 0, nameof(column));
            return new Vector2(this);
        }

        Vector1 IColumnMatrix.Row(int row)
        {
            return new Vector1(this[row]);
        }

        Vector1 IRowMatrix.Column(int column)
        {
            return new Vector1(this[column]);
        }

        Vector2 IRowMatrix.Row(int row)
        {
            ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0, nameof(row));
            return new Vector2(this);
        }

        public static Vector2 operator+(Vector2 self)
        {
            return new Vector2(self.X, self.Y);
        }

        public static Vector2 operator-(Vector2 self)
        {
            return new Vector2(-self.X, -self.Y);
        }

        public static Vector2 operator+(Vector2 self, Vector2 other)
        {
            return self.Add(other);
        }

        public static Vector2 operator-(Vector2 self, Vector2 other)
        {
            return self.Subtract(other);
        }

        public static Vector2 operator*(Vector2 self, float other)
        {
            return self.Multiply(other);
        }

        public static Vector2 operator*(float other, Vector2 self)
        {
            return self.Multiply(other);
        }

        public static Vector2 operator/(Vector2 self, float other)
        {
            return self.Divide(other);
        }
    }
}