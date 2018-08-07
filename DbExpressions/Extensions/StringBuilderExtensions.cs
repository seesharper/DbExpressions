using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbExpressions
{
    /// <summary>
    /// Extends the <see cref="string"/> class.
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. 
        /// Each format item is replaced by the string representation of a corresponding object argument.        
        /// </summary>
        /// <param name="stringBuilder">The target <see cref="StringBuilder"/> instance.</param>
        /// <param name="indentLevel">The indent level to use</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arguments">An array of objects to format.</param>
        public static void AppendFormat(this StringBuilder stringBuilder, int indentLevel, string format, params object[] arguments)
        {
            for (int i = 0; i < indentLevel; i++)
            {
                stringBuilder.Append("\t");
            }
            stringBuilder.AppendFormat(format, arguments);
        }

        /// <summary>
        /// Appends the default line terminator, or a copy of a specified string and the default line terminator, to the end of this instance.
        /// </summary>
        /// <param name="stringBuilder">The target <see cref="StringBuilder"/> instance.</param>
        /// <param name="indentLevel">The indent level to use</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arguments">An array of objects to format.</param>
        public static void AppendLine(this StringBuilder stringBuilder, int indentLevel, string format, params object[] arguments)
        {
            AppendFormat(stringBuilder, indentLevel, format, arguments);
            stringBuilder.AppendLine();
        }

        /// <summary>
        /// Appends the default line terminator, or a copy of a specified string and the default line terminator, to the end of this instance.
        /// </summary>
        /// <param name="stringBuilder">The target <see cref="StringBuilder"/> instance.</param>
        /// <param name="indentLevel">The indent level to use</param>
        /// <param name="value"></param>
        public static void AppendLine(this StringBuilder stringBuilder, int indentLevel, string value)
        {
            for (int i = 0; i < indentLevel; i++)
            {
                stringBuilder.Append("\t");
            }
            stringBuilder.AppendLine(value);
        }
    }
}
