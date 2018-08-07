namespace DbExpressions
{
    /// <summary>
    /// Describes the node types that represents calling mathematical functions.
    /// </summary>
    public enum DbMathematicalFunctionExpressionType
    {
        /// <summary>
        /// A node that represents returning the absolute (positive) value of the specified numeric expression.
        /// </summary>
        Abs,

        /// <summary>
        /// A node that represents returning the angle, in radians, whose cosine is the specified float expression; also called arccosine.
        /// </summary>
        Acos,

        /// <summary>
        /// A node that represents returning the angle, in radians, whose sine is the specified float expression. This is also called arcsine.
        /// </summary>
        Asin,

        /// <summary>
        /// A node that represents returning the angle in radians whose tangent is a specified float expression. This is also called arctangent.
        /// </summary>
        Atan,

        /// <summary>
        /// A node that represents returning the angle, in radians, between the positive x-axis and the ray from the origin to the point (y, x), 
        /// where x and y are the values of the two specified float expressions.
        /// </summary>
        Atan2,

        /// <summary>
        /// A node that represents returning the smallest integer greater than, or equal to, the specified numeric expression.
        /// </summary>
        Ceiling,

        /// <summary>
        /// A node that represents returning the trigonometric cosine of the specified angle, in radians, in the specified expression.
        /// </summary>
        Cos,

        /// <summary>
        /// A node that represents returning the trigonometric cotangent of the specified angle, in radians, in the specified float expression.
        /// </summary>
        Cot,

        /// <summary>
        /// A node that represents returning the corresponding angle in degrees for an angle specified in radians.
        /// </summary>
        Degrees,

        /// <summary>
        /// A node that represents returning the exponential value of the specified float expression.
        /// </summary>
        Exp,

        /// <summary>
        /// A node that represents returning the largest integer less than or equal to the specified numeric expression.
        /// </summary>
        Floor,
        
        /// <summary>
        /// A node that represents returning the natural logarithm of the specified float expression.
        /// </summary>
        Log,

        /// <summary>
        /// A node that represents returning the base-10 logarithm of the specified float expression.
        /// </summary>
        Log10,

        /// <summary>
        /// A node that represents returning the constant value of PI.
        /// </summary>
        PI,

        /// <summary>
        /// A node that represents returning the value of the specified expression to the specified power.
        /// </summary>
        Power,

        /// <summary>
        /// A node that represents returning the radians of the specified numeric expression.
        /// </summary>
        Radians,

        /// <summary>
        /// A node that represents returning a pseudo-random float value from 0 through 1
        /// </summary>
        Rand,

        /// <summary>
        /// A node that represents returning a pseudo-random float value from 0 through 1 using a seed value.
        /// </summary>
        RandSeed,

        /// <summary>
        /// A node that represents returning a numeric value, rounded to the specified length or precision.
        /// </summary>
        Round,

        /// <summary>
        /// A node that represents returning the positive (+1), zero (0), or negative (-1) sign of the specified expression.
        /// </summary>
        Sign,

        /// <summary>
        /// A node that represents returning the trigonometric sine of the specified angle, in radians, and in an approximate numeric, float, expression.
        /// </summary>
        Sin,

        /// <summary>
        /// A node that represents returning the square root of the specified float value.
        /// </summary>
        Sqrt,

        /// <summary>
        /// A node that represents returning the square of the specified float value.
        /// </summary>
        Square,

        /// <summary>
        /// A node that represents returning the tangent of the input expression.
        /// </summary>
        Tan
    }
}
