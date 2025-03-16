using System.Collections.ObjectModel;

namespace Cinnabar.GameMath
{
    using IColumnMatrix = IMatrix<Vector3, Vector1, Vector3>;
    using IRowMatrix = IMatrix<Vector3, Vector3, Vector1>;

    public struct Vector3:
        IVector<Vector3>,
        IColumnMatrix,
        IRowMatrix
    {
        private static MatrixOrder _rowMatrixOrder = new MatrixOrder(1, 3);
        private static MatrixOrder _columnMatrixOrder = new MatrixOrder(3, 1);

        private float _x;
        private float _y;
        private float _z;
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

        public float Z {
            get => _z;
            set {
                _isMagnitudeDirty = value != _z;
                _z = value;
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

        public ReadOnlyCollection<float> Components => new float[] { _x, _y, _z }.AsReadOnly();

        public int Dimension => 3;

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
                    2 => _z,
                    _ => throw new IndexOutOfRangeException()
                };
            }
            set {
                if (index == 0) _x = value;
                else if (index == 1) _y = value;
                else if (index == 2) _z = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
            UpdateMagnitude();
        }

        public Vector3(Vector3 other)
            :this(other.X, other.Y, other.Z)
        {}

        private void UpdateMagnitude()
        {
            var firstSquare = Math.FusedMultiplyAdd(_x, _x, _y * _y);
            var squareSum = Math.FusedMultiplyAdd(_z, _z, firstSquare);
            var root = Math.ReciprocalSqrtEstimate(squareSum);
            _magnitude = root * squareSum;
        }

        public Vector3 Negate()
        {
            return new Vector3(-_x, -_y, -_z);
        }

        public Vector3 Add(Vector3 other)
        {
            return new Vector3(
                _x + other.X,
                _y + other.Y,
                _z + other.Z);
        }

        public Vector3 Subtract(Vector3 other)
        {
            return new Vector3(
                _x - other.X,
                _y - other.Y,
                _z - other.Z);
        }

        public Vector3 Multiply(float scalar)
        {
            return new Vector3(
                _x * scalar,
                _y * scalar,
                _z * scalar);
        }

        public Vector3 Divide(float scalar)
        {
            return new Vector3(
                _x / scalar,
                _y / scalar,
                _z / scalar);
        }

        public float Dot(Vector3 other)
        {
            return this.X * other.X + this.Y * other.Y + this.Z * other.Z;
        }

        public static Vector3 operator+(Vector3 self)
        {
            return new Vector3(self.X, self.Y, self.Z);
        }

        public static Vector3 operator-(Vector3 self)
        {
            return self.Negate();
        }

        public static Vector3 operator+(Vector3 self, Vector3 other)
        {
            return self.Add(other);
        }

        public static Vector3 operator-(Vector3 self, Vector3 other)
        {
            return self.Subtract(other);
        }

        public static Vector3 operator*(Vector3 self, float other)
        {
            return self.Multiply(other);
        }

        public static Vector3 operator*(float other, Vector3 self)
        {
            return self.Multiply(other);
        }

        public static Vector3 operator/(Vector3 self, float other)
        {
            return self.Divide(other);
        }

        public static Vector3 Zero()
        {
            return new Vector3(0, 0, 0);
        }

        Vector3 IColumnMatrix.Column(int column)
        {
            ArgumentOutOfRangeException.ThrowIfNotEqual(column, 0, nameof(column));
            return new Vector3(_x, _y, _z);
        }

        Vector1 IColumnMatrix.Row(int row)
        {
            return new Vector1(
                row switch {
                    0 => _x,
                    1 => _y,
                    2 => _z,
                    _ => throw new ArgumentOutOfRangeException(nameof(row))
                });
        }

        Vector1 IRowMatrix.Column(int column)
        {
            return new Vector1(
                column switch {
                    0 => _x,
                    1 => _y,
                    2 => _z,
                    _ => throw new ArgumentOutOfRangeException(nameof(column))
                });
        }

        Vector3 IRowMatrix.Row(int row)
        {
            ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0, nameof(row));
            return new Vector3(_x, _y, _x);
        }
    }
}