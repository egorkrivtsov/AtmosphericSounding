using System.Collections;
using System.Runtime.Caching;

namespace WpfUI.Common
{
    /// <summary>
    /// Represents small wrapper for applicatin cache
    /// Catalogs: if you want to add new cached referenced data - 
    /// 1. Add Key Constant(see section constants)
    /// 2. Add your List and Func callback which will be called to fetched data( see region Reference Data)
    /// </summary>
    public static class CacheWrapper
    {
        #region public common methods

        /// <summary>
        /// Add object with specific key to cache
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Object</param>
        public static void Add(string key, object value)
        {
            if (ApplicationCache != null)
                ApplicationCache.Add(key, value,null);
            else
                Hashtable.Add(key, value);
        }

        /// <summary>
        /// Remove object with specific key from cache
        /// </summary>
        /// <param name="key">Key</param>
        public static void Remove(string key)
        {
            if (ApplicationCache != null)
                ApplicationCache.Remove(key);
            else
                Hashtable.Remove(key);
        }

        /// <summary>
        /// Returns object item from cache
        /// </summary>
        /// <typeparam name="T">Type of returned object</typeparam>
        /// <param name="key">Key</param>
        /// <returns>Object Item</returns>
        public static T Get<T>(string key) where T : class
        {
            if (ApplicationCache != null)
                return ApplicationCache.Get(key) as T;
            else
                return Hashtable[key] as T;
        }

        public static void Dispose()
        {
            MemoryCache.Default.Dispose(); 
            Hashtable.Clear();
        }

        #endregion


        #region Private method (for internal use)

        /// <summary>
        /// For internal use: Application Cache
        /// </summary>
        private static ObjectCache ApplicationCache => MemoryCache.Default;

        private static Hashtable hashTable;

        private static Hashtable Hashtable => hashTable ?? (hashTable = new Hashtable());

        #endregion

        #region Public properties for dictionaries

        //public static List<T> ReferenceTable<T>() where T : class
        //{
        //    var key = string.Format(Constants.Cache.DictionaryTemplate, typeof(T));
        //    List<T> cacheValue = Get<List<T>>(key);
        //    if (cacheValue == null)
        //    {
        //        lock (syncRoot)
        //        {
        //            cacheValue = Init<List<T>>(key);
        //            if (cacheValue != null)
        //                return cacheValue;

        //            cacheValue = AddDataToCache<T>(key);
        //        }
        //    }
        //    return cacheValue;
        //}

        //private static List<T> AddDataToCache<T>(string key) where T : class
        //{
        //    using (var caseContext = new CaseContext())
        //    {
        //        // for cache we don't need proxy
        //        caseContext.Configuration.LazyLoadingEnabled = false;
        //        caseContext.Configuration.ProxyCreationEnabled = false;

        //        IQueryable<T> query = caseContext.Set<T>();

        //        if (typeof(T) == typeof(RuleTemplate))
        //            query = (IQueryable<T>)caseContext.Set<RuleTemplate>()
        //                .Include(rt => rt.DataType)
        //                .Include(rt => rt.Formulas)
        //                .Where(rt => rt.IsActive)
        //                .OrderBy(rt => rt.DisplayOrder);

        //        if (typeof(T) == typeof(PlanTemplate))
        //            query = (IQueryable<T>)caseContext.Set<PlanTemplate>()
        //                .Include(pt => pt.PlanTemplateMediaFiles)
        //                .OrderBy(pt => pt.DisplayOrder);

        //        if (typeof(T) == typeof(ConfigurationObject))
        //            query = (IQueryable<T>)caseContext.Set<ConfigurationObject>()
        //                .Include(rt => rt.PlanTemplate)
        //                .Include(x => x.ObjectDataType)
        //                .Include(x => x.ObjectRelations)
        //                .Include(x => x.OtherObjectRelations);

        //        var list = query.ToList();

        //        Add(key, list);

        //        return list;
        //    }
        //}

        #endregion
    }

}
