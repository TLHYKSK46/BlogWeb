using BlogCore.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlogCore.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheRemoveAspect : OnMethodBoundaryAspect
    {
        private string _pattern;
        private Type _cacheType;
        private ICacheManager _cacheManager;


        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
        }
        public CacheRemoveAspect(string pattern, Type cacheType)
        {
            _cacheType = cacheType;
            _pattern = pattern;
        }
        public override void RuntimeInitialize(MethodBase method)
        {

            if (typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("Yanlış Önbellek Yöneticisi ");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);

            base.RuntimeInitialize(method);
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern)
               ? string.Format("{0}.{1}.*",
                args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name)
                : _pattern);
        }



    }
}
