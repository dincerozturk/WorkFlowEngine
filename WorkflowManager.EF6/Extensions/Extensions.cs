using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using WorkFlowManager.Common.Enums;

namespace WorkFlowManager.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static T GetNext<T>(this IEnumerable<T> list, T current)
        {
            try
            {
                return list.SkipWhile(x => !x.Equals(current)).Skip(1).First();
            }
            catch
            {
                return default(T);
            }
        }

        public static T GetPrevious<T>(this IEnumerable<T> list, T current)
        {
            try
            {
                return list.TakeWhile(x => !x.Equals(current)).Last();
            }
            catch
            {
                return default(T);
            }
        }

        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int groups)
        {
            return source.Select((x, i) => new { Index = i, Value = x }).GroupBy(x => x.Index / groups).Select(x => x.Select(v => v.Value).ToList()).ToList();
        }
    }

    public static class ExpressionBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second,
                                               Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters
                           .Select((f, i) => new { f, s = second.Parameters[i] })
                           .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from 
            // the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
            // apply composition of lambda expression bodies to parameters from 
            // the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        public class ParameterRebinder : ExpressionVisitor
        {
            private readonly Dictionary<ParameterExpression, ParameterExpression> map;

            public ParameterRebinder(
                Dictionary<ParameterExpression,
                ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReplaceParameters(
                Dictionary<ParameterExpression,
                ParameterExpression> map,
                Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                ParameterExpression replacement;
                if (map.TryGetValue(p, out replacement))
                {
                    p = replacement;
                }
                return base.VisitParameter(p);
            }
        }
    }
}
