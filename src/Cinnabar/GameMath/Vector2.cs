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

        MatrixOrder IMatrix<Vector2, Vector1>.Order => _columnMatrixOrder;

        float IMatrix<Vector2, Vector1>.this[int column, int row] {
            get {
                ArgumentOutOfRangeException.ThrowIfNotEqual(column, 0, nameof(column));
                return this[row];
            }
        }
        
        MatrixOrder IMatrix<Vector1, Vector2>.Order => _rowMatrixOrder;

        float IMatrix<Vector1, Vector2>.this[int column, int row] {
            get {
                ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0, nameof(row));
                return this[column];
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

        Vector2 IMatrix<Vector2, Vector1>.Column(int column)
        {
            ArgumentOutOfRangeException.ThrowIfNotEqual(column, 0, nameof(column));
            return new Vector2(this);
        }

        Vector1 IMatrix<Vector2, Vector1>.Row(int row)
        {
            return new Vector1(this[row]);
        }

        Vector1 IMatrix<Vector1, Vector2>.Column(int column)
        {
            return new Vector1(this[column]);
        }

        Vector2 IMatrix<Vector1, Vector2>.Row(int row)
        {
            ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0, nameof(row));
            return new Vector2(this);
        }

        IMatrix<Vector2, TOtherRowVector> IColumnMatrix.Multiply<TOther, TOtherRowVector>(TOther other)
        {
            var otherRowSize = other.Order.Columns;
            var col1 = other.Column(0).Components;
            var col2 = other.Column(1).Components;
            var col3 = other.Column(2).Components;
            var col4 = other.Column(3).Components;

            // The above is not going to throw for any matrix order other than 2x4. Will need to ditch the switch

            IMatrix<Vector2, TOtherRowVector>? result = otherRowSize switch {
                1 => new Vector1(X * col1[0] + Y * col1[1]) as IMatrix<Vector2, TOtherRowVector>,
                2 => new Vector2(X * col1[0] + Y * col1[1], X * col2[0] + Y * col2[1]) as IMatrix<Vector2, TOtherRowVector>,
                3 => new Vector3(X * col1[0] + Y * col1[1], X * col2[0] + Y * col2[1], X * col3[0] + Y * col3[1]) as IMatrix<Vector2, TOtherRowVector>,
                4 => new Vector4(X * col1[0] + Y * col1[1], X * col2[0] + Y * col2[1], X * col3[0] + Y * col3[1], X * col4[0] + Y * col4[1]) as IMatrix<Vector2, TOtherRowVector>,
                _ => throw new ArgumentException("Unsupported matrix order.", nameof(other))
            };

            return result!;
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