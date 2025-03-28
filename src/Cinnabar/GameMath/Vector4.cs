using System.Collections.ObjectModel;

namespace Cinnabar.GameMath
{
    public struct Vector4
    {
        private float _w;
        private float _x;
        private float _y;
        private float _z;

        private double _magnitude;
        private bool _isMagnitudeDirty = true;

        public float Z {
            get => _z;
            set {
                _isMagnitudeDirty = value != _z;
                _z = value;
            }
        }

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

        public float W {
            get => _w;
            set {
                _isMagnitudeDirty = value != _w;
                _w = value;
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

        public ReadOnlyCollection<float> Components => new float[] { _w, _x, _y, _z }.AsReadOnly();

        public int Dimension => 4;

        // MatrixOrder IColumnMatrix.Order => _columnMatrixOrder;

        // float IColumnMatrix.this[int column, int row] {
        //     get {
        //         ArgumentOutOfRangeException.ThrowIfNotEqual(column, 0, nameof(column));
        //         return this[row];
        //     }            
        // }
        
        // MatrixOrder IRowMatrix.Order => _rowMatrixOrder;

        // float IRowMatrix.this[int column, int row] {
        //     get {
        //         ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0, nameof(row));
        //         return this[column];
        //     }
        // }

        public float this[int index]
        {
            get {
                return index switch {
                    0 => _w,
                    1 => _x,
                    2 => _y,
                    3 => _z,
                    _ => throw new IndexOutOfRangeException()
                };
            }
            set {
                if (index == 0) _w = value;
                else if (index == 1) _x = value;
                else if (index == 2) _y = value;
                else if (index == 3) _z = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public Vector4(float w, float x, float y, float z)
        {
            _w = w;
            _x = x;
            _y = y;
            _z = z;
            UpdateMagnitude();
        }

        public Vector4(Vector4 other)
            :this(other.W, other.X, other.Y, other.Z)
        {}

        private void UpdateMagnitude()
        {
            var xy = Math.FusedMultiplyAdd(_x, _x, _y * _y);
            var xyz = Math.FusedMultiplyAdd(_z, _z, xy);
            var squareSum = Math.FusedMultiplyAdd(_w, _w, xyz);
            var root = Math.ReciprocalSqrtEstimate(squareSum);
            _magnitude = root * squareSum;
        }

        public Vector4 Negate()
        {
            return new Vector4(-_w, -_x, -_y, -_z);
        }

        public Vector4 Normalize()
        {
            return new Vector4(
                (float)(_w / Magnitude),
                (float)(_x / Magnitude),
                (float)(_y / Magnitude),
                (float)(_z / Magnitude));
        }

        public static Vector4 Zero()
        {
            return new Vector4(0, 0, 0, 0);
        }

        public static Vector4 UnitW()
        {
            return new Vector4(1, 0, 0, 0);
        }

        public static Vector4 UnitX()
        {
            return new Vector4(0, 1, 0, 0);
        }

        public static Vector4 UnitY()
        {
            return new Vector4(0, 0, 1, 0);
        }

        public static Vector4 UnitZ()
        {
            return new Vector4(0, 0, 0, 1);
        }

        public Vector4 Add(Vector4 other)
        {
            return new Vector4(
                _w + other.W,
                _x + other.X,
                _y + other.Y,
                _z + other.Z);
        }

        public Vector4 Subtract(Vector4 other)
        {
            return new Vector4(
                _w - other.W,
                _x - other.X,
                _y - other.Y,
                _z - other.Z);
        }

        public Vector4 Multiply(float scalar)
        {
            return new Vector4(
                _w * scalar,
                _x * scalar,
                _y * scalar,
                _z * scalar);
        }

        public Vector4 Divide(float scalar)
        {
            return new Vector4(
                _w / scalar,
                _x / scalar,
                _y / scalar,
                _z / scalar);
        }

        public float Dot(Vector4 other)
        {
            return this.W * other.W + this.X * other.X + this.Y * other.Y + this.Z * other.Z;
        }

        // Vector4 IColumnMatrix.Column(int column)
        // {
        //     ArgumentOutOfRangeException.ThrowIfNotEqual(column, 0, nameof(column));
        //     return new Vector4(_w, _x, _y, _z);
        // }

        // Vector1 IColumnMatrix.Row(int row)
        // {
        //     return new Vector1(
        //         row switch {
        //             0 => _w,
        //             1 => _x,
        //             2 => _y,
        //             3 => _z,
        //             _ => throw new ArgumentOutOfRangeException(nameof(row))
        //         });
        // }
        
        // Vector1 IRowMatrix.Column(int column)
        // {
        //     return new Vector1(
        //         column switch {
        //             0 => _w,
        //             1 => _x,
        //             2 => _y,
        //             3 => _z,
        //             _ => throw new ArgumentOutOfRangeException(nameof(column))
        //         });
        // }

        // Vector4 IRowMatrix.Row(int row)
        // {
        //     ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0, nameof(row));
        //     return new Vector4(_w, _x, _y, _z);
        // }

        public static Vector4 operator+(Vector4 self)
        {
            return new Vector4(self.W, self.X, self.Y, self.Z);
        }

        public static Vector4 operator-(Vector4 self)
        {
            return new Vector4(-self.W, -self.X, -self.Y, -self.Z);
        }

        public static Vector4 operator+(Vector4 self, Vector4 other)
        {
            return self.Add(other);
        }

        public static Vector4 operator-(Vector4 self, Vector4 other)
        {
            return self.Subtract(other);
        }

        public static Vector4 operator*(Vector4 self, float other)
        {
            return self.Multiply(other);
        }

        public static Vector4 operator*(float other, Vector4 self)
        {
            return self.Multiply(other);
        }

        public static Vector4 operator/(Vector4 self, float other)
        {
            return self.Divide(other);
        }
    }
}