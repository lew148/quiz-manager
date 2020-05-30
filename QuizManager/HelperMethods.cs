using System;
using System.Collections.Generic;

namespace quizManager.QuizManager
{
    public static class GeneralHelpers
    {
        public static void ThrowIfNull<TEntity>(TEntity obj)
        {
            if (obj == null) throw new ArgumentNullException( typeof(TEntity).Name + " is null or doesnt exist.");
        }
        
        public static void ThrowIfAnyAreNull<TEntity>(IEnumerable<TEntity> objs)
        {
            foreach (var obj in objs) ThrowIfNull(obj);
        }
    }
}