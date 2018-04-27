using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace lab.SecurityApp.Helpers.Dapper
{
    public class QueryBuilder<TSource>
    {
        #region Private Class
        private enum QType
        {
            Select,
            Insert,
            Update,
            Delete,
        }

        #endregion

        #region Public Static Method
        public static string Select(Expression<Func<TSource, bool>> whereExpression = null, Expression<Func<TSource, bool>> excludes = null)
        {
            var where = string.Empty;
            var columns = GetColumns(QType.Select).Select(o => string.Format("[{0}]", o)).ToList();
            if (excludes != null)
            {
                var excludeExpression = TrimedExpression(excludes.Body.ToString());
                var updateExcludes = GetExcludes(excludeExpression).Select(o => string.Format("[{0}]", o));
                columns = columns.Except(updateExcludes).ToList();
            }
            if (whereExpression != null)
            {
                var expression = TrimedExpression(whereExpression.Body.ToString());
                where = GetWhereCondition(expression);
            }
            var set = string.Join(",", columns);
            where = where.TrimEnd(',');
            where = string.IsNullOrWhiteSpace(where) ? string.Empty : string.Format(" WHERE {0} ", where);
            return "SELECT " + set + " FROM " + GetTableName() + where;
        }
        public static string SelectByPrimaryKey()
        {
            var where = string.Empty;
            var columns = GetColumns(QType.Select).Select(o => string.Format("[{0}]", o)).ToList();
            var set = string.Join(",", columns);
            var primaryColumn = GetPrimaryKeyColumns();
            if (primaryColumn != null && primaryColumn.Count == 1)
            {
                where = primaryColumn[0] + " = @" + primaryColumn[0];
            }
            where = string.IsNullOrWhiteSpace(where) ? string.Empty : string.Format(" WHERE {0} ", where);
            return "SELECT " + set + " FROM " + GetTableName() + " " + where;
        }

        public static string GetSelectClause()
        {
            var columns = GetColumns(QType.Select).Select(o => string.Format("[{0}]", o)).ToList();
            var set = string.Join(",", columns);
            return "SELECT " + set + " FROM " + GetTableName();
        }

        public static string GetWhereClause()
        {
            var where = string.Empty;
            var primaryColumn = GetPrimaryKeyColumns();
            if (primaryColumn != null && primaryColumn.Count == 1)
            {
                where = primaryColumn[0] + " = @" + primaryColumn[0];
            }
            where = string.IsNullOrWhiteSpace(where) ? string.Empty : string.Format(" WHERE {0} ", where);
            return where;
        }

        public static string Insert()
        {
            var columns = string.Join(",",
                GetColumns(QType.Insert).Select(o => string.Format("[{0}]", o)).ToList());
            var values = string.Join(",", GetColumns(QType.Insert).Select(o => string.Format("@{0}", o)).ToList());
            var query = " INSERT INTO " + GetTableName();
            if (string.IsNullOrWhiteSpace(columns) || string.IsNullOrWhiteSpace(values))
            {
                throw new Exception("No column is found in the model.");
            }
            columns = "( " + columns.TrimStart(',') + " )";
            values = " VALUES ( " + values.TrimStart(',') + " )";
            return query + columns + values + ";  select cast(scope_identity() as int)";
        }
        public static string InsertWithoutIdentityColumn()
        {
            var columns = string.Join(",",
                GetColumns(QType.Insert, false).Select(o => string.Format("[{0}]", o)).ToList());
            var values = string.Join(",", GetColumns(QType.Insert, false).Select(o => string.Format("@{0}", o)).ToList());
            var query = " INSERT INTO " + GetTableName();
            if (string.IsNullOrWhiteSpace(columns) || string.IsNullOrWhiteSpace(values))
            {
                throw new Exception("No column is found in the model.");
            }
            columns = "( " + columns.TrimStart(',') + " )";
            values = " VALUES ( " + values.TrimStart(',') + " )";
            return query + columns + values + ";  select cast(@@ROWCOUNT as int)";
        }
        public static string UpdateColumns(Expression<Func<TSource, bool>> Includes, Expression<Func<TSource, bool>> whereExpression = null)
        {
            var whereExcludes = new List<string>();
            var updateExcludes = new List<string>();
            var primaryKeyColumns = new List<string>();
            var set = string.Empty;
            var where = string.Empty;
            var expression = TrimedExpression(Includes.Body.ToString());
            var columns = GetExcludes(expression);
            if (whereExpression != null)
            {
                var exp = TrimedExpression(whereExpression.Body.ToString());
                whereExcludes = GetExcludes(exp);
                where = GetWhereCondition(exp);
                columns = columns.Except(whereExcludes).ToList();
            }
            else
            {
                primaryKeyColumns = GetPrimaryKeyColumns();
                foreach (var v in primaryKeyColumns)
                {
                    where = string.Format("{0} {1}=@{1} AND", where, v);
                }
                where = where.TrimEnd('D').TrimEnd('N').TrimEnd('A');
            }
            foreach (var v in columns)
            {
                set = string.Format("{0} {1}=@{1},", set, v);
            }
            where = where.TrimEnd(',');
            set = set.TrimEnd(',');
            return "Update " + GetTableName() + " SET " + set + " WHERE " + where + ";  select cast(@@ROWCOUNT as int)";
        }
        public static string Update(Expression<Func<TSource, bool>> whereExpression = null, Expression<Func<TSource, bool>> Excludes = null, bool excludeCreatorInfo = true)
        {
            var whereExcludes = new List<string>();
            var updateExcludes = new List<string>();
            var primaryKeyColumns = new List<string>();
            var set = string.Empty;
            var where = string.Empty;
            var columns = GetColumns(QType.Update);

            if (Excludes != null)
            {
                var expression = TrimedExpression(Excludes.Body.ToString());
                updateExcludes = GetExcludes(expression);
                columns = columns.Except(updateExcludes).ToList();
            }

            if (whereExpression != null)
            {
                var expression = TrimedExpression(whereExpression.Body.ToString());
                whereExcludes = GetExcludes(expression);
                where = GetWhereCondition(expression);
                columns = columns.Except(whereExcludes).ToList();
            }
            else
            {
                primaryKeyColumns = GetPrimaryKeyColumns();
                foreach (var v in primaryKeyColumns)
                {
                    where = string.Format("{0} {1}=@{1} AND", where, v);
                }
                where = where.TrimEnd('D').TrimEnd('N').TrimEnd('A');
            }
            foreach (var v in columns)
            {
                if (excludeCreatorInfo)
                {
                    if (v != "CreatedDate" && v != "CreatedByUserId")
                    {
                        set = string.Format("{0} {1}=@{1},", set, v);
                    }
                }
                else
                {
                    set = string.Format("{0} {1}=@{1},", set, v);
                }

            }
            where = where.TrimEnd(',');
            set = set.TrimEnd(',');

            return "Update " + GetTableName() + " SET " + set + " WHERE " + where + ";  select cast(@@ROWCOUNT as int)";
        }
        public static string Delete(Expression<Func<TSource, bool>> whereExpression = null)
        {
            var excludes = new List<string>();
            var set = string.Empty;
            var where = string.Empty;
            var columns = GetColumns(QType.Delete);
            if (whereExpression != null)
            {
                var expression = TrimedExpression(whereExpression.Body.ToString());
                excludes = GetExcludes(expression);
                where = GetWhereCondition(expression);
                columns = columns.Except(excludes).ToList();
            }
            else
            {
                excludes = GetPrimaryKeyColumns();
                foreach (var v in excludes)
                {
                    where = string.Format("{0} {1}=@{1} AND", where, v);
                }
                where = where.TrimEnd('D').TrimEnd('N').TrimEnd('A');
            }
            foreach (var v in columns)
            {
                set = string.Format("{0} {1}=@{1},", set, v);
            }
            where = where.TrimEnd(',');
            set.TrimEnd(',');

            return "DELETE FROM " + GetTableName() + " WHERE " + where + "; select cast(@@ROWCOUNT as int)";
        }
        public static string GetNewId()
        {
            var primaryColumn = GetPrimaryKeyColumns();
            if (primaryColumn != null && primaryColumn.Count == 1)
            {
                return "SELECT  ISNULL(MAX(" + primaryColumn[0] + ") + 1,1)" + primaryColumn[0] + " FROM " + GetTableName();
            }
            return string.Empty;
        }
        public static List<string> GetPrimaryKeyColumns()
        {
            var properties = typeof(TSource).GetProperties();
            return (from v in properties
                    where IsValidPropertyType(v.PropertyType)
                    let attribute = v.GetCustomAttributes(false)
                    let hasAttrubute = attribute.FirstOrDefault(a => a is KeyAttribute)
                    where hasAttrubute != null
                    select v.Name
                   ).ToList();
        }

        #endregion

        #region Private Method
        private static List<string> GetExcludes(string expression)
        {
            var excludes = new List<string>();
            expression = TrimedExpression(expression);
            var words = expression.Split(' ');
            var reg = new Regex(@"^(([a-z0-9]+)\.[(a-z0-9)]+)$", RegexOptions.IgnoreCase);
            for (int i = 0; i < words.Count(); i++)
            {
                words[i] = words[i].Replace("{", "")
                                    .Replace("(", "")
                                    .Replace(")", "")
                                    .Replace("}", "");

                var match = reg.Match(words[i]);
                if (match.Success)
                {
                    excludes.Add(match.Value.Split('.')[1]);
                }
            }
            excludes = excludes.Distinct().ToList();
            return excludes;
        }
        private static string GetWhereCondition(string text)
        {
            var pattern = @"(\= [a-z]+)(\.)";

            text = Regex.Replace(text, pattern, m => "= @" + m.Groups[3].Value);
            pattern = @"([a-z]+)(\.)";
            text = Regex.Replace(text, pattern, m => m.Groups[3].Value);

            return text;
        }
        private static bool IsValidPropertyType(Type type)
        {
            if (type == typeof(int?) || type == typeof(Int32))
                return true;
            if (type == typeof(bool?) || type == typeof(bool))
                return true;
            if (type == typeof(DateTime?) || type == typeof(DateTime))
                return true;
            if (type == typeof(decimal?) || type == typeof(decimal))
                return true;
            if (type == typeof(double?) || type == typeof(Double))
                return true;
            if (type == typeof(byte?) || type == typeof(Byte))
                return true;

            if (type == typeof(byte?) || type == typeof(Byte[]))
                return true;
            if (type == typeof(string))
                return true;
            if (type.IsGenericType)
                return false;
            if (type.IsArray)
                return false;
            return false;
        }
        private static List<string> GetColumns(QType qType, bool checkIdentity = true)
        {
            var columns = new List<string>();
            var properties = typeof(TSource).GetProperties();
            foreach (var v in properties)
            {
                if (IsValidPropertyType(v.PropertyType))
                {
                    var attribute = v.GetCustomAttributes(false);
                    if (qType == QType.Select)
                    {
                        var hasAttrubute = attribute.FirstOrDefault(a => a.GetType() == typeof(NotMappedAttribute));
                        if (hasAttrubute == null)
                        {
                            columns.Add(v.Name);
                        }
                    }
                    if (qType == QType.Insert || qType == QType.Update || qType == QType.Delete)
                    {
                        object hasAttrubute;
                        if (checkIdentity)
                        {
                            hasAttrubute =
                                attribute.FirstOrDefault(
                                    a => a is KeyAttribute || a.GetType() == typeof(NotMappedAttribute));
                        }
                        else
                        {
                            hasAttrubute = attribute.FirstOrDefault(a => a.GetType() == typeof(NotMappedAttribute));
                        }

                        if (hasAttrubute == null)
                        {
                            columns.Add(v.Name);
                        }

                    }
                }
            }
            return columns;
        }
        private static string GetTableName()
        {
            var modelAttribute = ((TableAttribute[])typeof(TSource).GetCustomAttributes(typeof(TableAttribute), false)).FirstOrDefault();
            return modelAttribute == null
                ? string.Format("[dbo].[{0}]", typeof(TSource).Name)
                : string.Format("[{0}].[{1}]", modelAttribute.Schema, modelAttribute.Name);
        }
        private static string TrimedExpression(string expression)
        {
            return expression.Replace("AndAlso", "AND").Replace("OrElse", "OR").Replace("Convert", "").Replace("==", "=");
        }

        #endregion
    }
}