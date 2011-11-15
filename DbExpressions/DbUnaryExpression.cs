using System;

namespace DbExpressions
{
    /// <summary>
    /// Represents a <see cref="DbExpression"/> that has a unary operator.
    /// </summary>
    public class DbUnaryExpression : DbExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DbUnaryExpression"/> class.
        /// </summary>
        /// <param name="unaryExpressionType">The <see cref="DbUnaryExpressionType"/> that this <see cref="DbUnaryExpression"/> represents.</param>
        /// <param name="operand">The <see cref="DbExpression"/> that represents the unary operand.</param>
        internal DbUnaryExpression(DbUnaryExpressionType unaryExpressionType, DbExpression operand)
            :this(unaryExpressionType,operand,null) {}
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DbUnaryExpression"/> class.
        /// </summary>
        /// <param name="unaryExpressionType">The <see cref="DbUnaryExpressionType"/> that this <see cref="DbUnaryExpression"/> represents.</param>
        /// <param name="operand">The <see cref="DbExpression"/> that represents the unary operand.</param>
        /// <param name="targetType">The <see cref="Type"/> that specifies the type to convert to.</param>
        internal DbUnaryExpression(DbUnaryExpressionType unaryExpressionType, DbExpression operand, Type targetType)
        {
            UnaryExpressionType = unaryExpressionType;
            Operand = operand;
            TargetType = targetType;
        }


        /// <summary>
        /// Gets the <see cref="DbExpression"/> that represents the unary operand.
        /// </summary>
        public DbExpression Operand { get; private set; }

        /// <summary>
        /// Gets the <see cref="DbUnaryExpressionType"/> that this <see cref="DbUnaryExpression"/> represents.
        /// </summary>
        public DbUnaryExpressionType UnaryExpressionType { get; private set;}


        /// <summary>
        /// Gets the <see cref="Type"/> that specifies the type to be converted to
        ///  </summary>
        public Type TargetType { get; private set; }
        
            
        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Unary; }
        }
    }
}
